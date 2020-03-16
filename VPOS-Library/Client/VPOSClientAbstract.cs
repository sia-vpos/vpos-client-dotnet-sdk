using System;
using System.Collections.Generic;
using VPOS_Library.Models;
using VPOS_Library.Utils;
using VPOS_Library.Utils.Exception;
using VPOS_Library.Utils.MAC;
using VPOS_Library.XML;
using VPOS_Library.XML.Models;
using VPOS_Library.XMLModels.Request;
using Operation = VPOS_Library.XML.Models.Operation;

namespace VPOS_Library.Client
{
    public class VPOSClientAbstract : VposClient
    {
        private const string MacNeutralValue = "NULL";

        private bool _customTemplate;
        private readonly string _urlApos;
        private readonly string _apiResultKey;
        private readonly string _startKey;

        private readonly RestClient _restClient;
        private readonly MacEncoder _encoder;
        private readonly HtmlTool _htmlTool;

        public VPOSClientAbstract(string urlApos, string apiResultKey, string startKey)
        {
            _customTemplate = false;
            _encoder = new MacEncoder();
            _restClient = new RestClient();
            _htmlTool = new HtmlTool();
            _urlApos = urlApos;
            _apiResultKey = apiResultKey;
            _startKey = startKey;
        }

        public void InjectHtmlTemplate(string base64, int delay)
        {
            var html = _htmlTool.Base64ToHtml(base64, delay);
            using (var file = new System.IO.StreamWriter(@Environment.CurrentDirectory + "/custom.html"))
            {
                file.Write(html);
            }

            _customTemplate = true;
        }

        public string GetHtmlPaymentDocument(PaymentInfo paymentInfo, string urlApos)
        {
            var path = @Environment.CurrentDirectory;
            path += _customTemplate ? "/custom.html" : "/default.html";
            var redirectDictionary = RequestHandler.GetRedirectDictionary(paymentInfo);
            var redirectMac = _encoder.GetMac(redirectDictionary, _startKey);
            redirectDictionary.Add("MAC", redirectMac);
            RequestHandler.AddMissingParameter(redirectDictionary, paymentInfo);
            return _htmlTool.HtmlToBase64(path, urlApos, redirectDictionary);
        }

        public string Tokenize(string shopId, string urlBack, string urlDone, string urlms, string urlApos)
        {
            var paymentInfo = new PaymentInfo
            {
                Amount = "10",
                Currency = "978",
                OrderId = new Random().Next(999999999).ToString(),
                ShopId = shopId,
                UrlBack = urlBack,
                UrlDone = urlDone,
                UrlMs = urlms,
                AccountingMode = "D",
                AuthorMode = "I"
            };
            paymentInfo.AddOption('M');

            return GetHtmlPaymentDocument(paymentInfo, urlApos);
        }

        public void VerifyUrl(Dictionary<string, string> values, string receivedMac)
        {
            throw new System.NotImplementedException();
        }

        public BPWXmlResponse<Data3DS> Start3DsAuth(BPWXmlRequest<AuthorizationRequest> request)
        {
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlApos, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DS>>(xmlResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            return objectResponse;
        }

        public BPWXmlResponse<Data3DS> Start3DsAuthStep2(BPWXmlRequest<AuthorizationRequest3DSStep2> request)
        {
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlApos, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DS>>(xmlResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            return objectResponse;
        }

        public BPWXmlResponse<DataManageOperation> ConfirmTransaction(BPWXmlRequest<AccountingRequest> request)
        {
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlApos, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataManageOperation>>(xmlResponse);
            VerifyOperation(objectResponse.Data.Operation);
            return objectResponse;
        }

        public BPWXmlResponse<DataManageOperation> RefundPayment(BPWXmlRequest<RefundRequest> request)
        {
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlApos, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataManageOperation>>(xmlResponse);
            VerifyOperation(objectResponse.Data.Operation);
            return objectResponse;
        }

        public BPWXmlResponse<DataVerify> VerifyRequest(BPWXmlRequest<VerifyRequest> request)
        {
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlApos, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataVerify>>(xmlResponse);
            VerifyResponse(objectResponse.Data.Verify);
            return objectResponse;
        }

        public BPWXmlResponse<DataOrderStatus> GetOrderStatus(BPWXmlRequest<OrderStatusRequest> request)
        {
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlApos, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataOrderStatus>>(xmlResponse);

            foreach (var authorization in objectResponse.Data.Authorizations)
                VerifyAuthorization(authorization);

            return objectResponse;
        }

        public void SetProxy(string proxyName, int proxyPort)
        {
            _restClient.SetProxy("http://proxy-dr.reply.it", proxyPort, null, null);
        }

        public void SetProxy(string proxyName, int proxyPort, string user, string password)
        {
            _restClient.SetProxy("http://proxy-dr.reply.it", proxyPort, user, password);
        }

        private void VerifyAuthorization(Authorization authorization)
        {
            if (authorization != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.AuthorizationMacList(authorization), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(authorization.MAC))
                    throw new IncorrectMacException(
                        "Authorization digest not corresponding to the calculated one. Possible data corruption!");
            }
        }


        private void VerifyOperation(Operation operation)
        {
            if (operation != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.OperationMacList(operation), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(operation.MAC))
                    throw new IncorrectMacException(
                        "Operation digest not corresponding to the calculated one. Possible data corruption!");
                VerifyAuthorization(operation.Authorization);
            }
        }

        private void VerifyResponse(Verify verify)
        {
            if (verify != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.VerifyMacList(verify), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(verify.MAC))
                    throw new IncorrectMacException(
                        "Verify digest not corresponding to the calculated one. Possible data corruption!");
            }
        }

        private void VerifyVbvRedirect(VBVRedirect vbvRedirect)
        {
            if (vbvRedirect != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.VbvRedirectMacList(vbvRedirect), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(vbvRedirect.MAC))
                    throw new IncorrectMacException(
                        "VBVRedirect digest not corresponding to the calculated one. Possible data corruption!");
            }
        }

        private void VerifyPanAliasData(PanAliasData panAliasData)
        {
            if (panAliasData != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.PanAliasList(panAliasData), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(panAliasData.MAC))
                    throw new IncorrectMacException(
                        "PanAliasData digest not corresponding to the calculated one. Possible data corruption!");
            }
        }
    }
}