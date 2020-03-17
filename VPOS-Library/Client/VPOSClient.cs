using System;
using System.Collections.Generic;
using VPOS_Library.Models;
using VPOS_Library.Utils;
using VPOS_Library.Utils.Exception;
using VPOS_Library.Utils.MAC;
using VPOS_Library.XML;
using VPOS_Library.XML.Models;
using VPOS_Library.XMLModels.Request;
using VPOS_Library.Request;
using Operation = VPOS_Library.XML.Models.Operation;
using java.lang;
using Data3DS = VPOS_Library.Models.Data3DSJSON;

namespace VPOS_Library.Client
{
    public class VPOSClient : Client
    {
        private const string MacNeutralValue = "NULL";

        private readonly string _urlAPI;
        private readonly string _apiResultKey;
        private readonly string _urlRedirect;
        private readonly string _startKey;
        private readonly string _shopId;

        private readonly RestClient _restClient;
        private readonly MacEncoder _encoder;
        private readonly HtmlTool _htmlTool;

        public VPOSClient(string redirectUrl, string apiResultKey, string startKey, string shopId)
        {

            _encoder = new MacEncoder();
            _restClient = new RestClient();
            _htmlTool = new HtmlTool();
            _urlAPI = redirectUrl;
            _apiResultKey = apiResultKey;
            _startKey = startKey;
            _shopId = shopId;
        }

        public VPOSClient(Config config)
        {
            ValidateConfig(config);
            _urlAPI = config.apiUrl;
            _apiResultKey = config.apiKey;
            _startKey = config.redirectKey;
            _shopId = config.shopID;
            _urlRedirect = config.redirectUrl;

            _encoder = new MacEncoder();
            _restClient = new RestClient();
            _htmlTool = new HtmlTool();

            if (config.proxyHost != null && !string.IsNullOrEmpty(config.proxyPort.ToString())) {
                if (config.proxyUsername != null && config.proxyPassword != null)
                {
                    SetProxy(config.proxyHost, config.proxyPort, config.proxyUsername, config.proxyPassword);
                }
                else {
                    SetProxy(config.proxyHost, config.proxyPort);
                }
            }

        }

        private void ValidateConfig(Config config)
        {
            List<string> fields = new List<string>();
            if (config.shopID == null)
            {
                fields.Add("SHOPID");
            }
            else if (config.apiKey == null)
            {
                fields.Add("APIRESULTKEY");
            }
            else if (config.apiUrl == null)
            {
                fields.Add("APIURL");
            }
            else if (config.redirectKey == null)
            {
                fields.Add("REDIRECTKEY");
            }
            else if (config.redirectUrl == null)
            {
                fields.Add("REDIRECTURL");
            }
            if (fields.Count == 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.append("Invalid or missing configuration params: ");
                foreach (string field in fields)
                {
                    sb.append(field);
                    sb.append(" ");
                }
                throw new VPOSClientException("Invalid or missing configuration param: " + sb.toString());
            }
        }

        public string BuildHtmlPaymentFragment(PaymentInfo paymentInfo)
        {
            string  url= "https://atpostest.ssb.it/atpos/pagamenti/main";
            var redirectDictionary = RequestHandler.GetRedirectDictionary(paymentInfo, _apiResultKey);
            var redirectMac = _encoder.GetMac(redirectDictionary, _startKey);
            redirectDictionary.Add("MAC", redirectMac);
            RequestHandler.AddMissingParameter(redirectDictionary, paymentInfo);
            return _htmlTool.BuildHtml(url , redirectDictionary);
        }

        public bool VerifyMac(string urlDone)
        { 
            
            var paramsDictionary = Utils.Utils.splitQuery(urlDone);
            var receivedMAc = paramsDictionary["MAC"];
            var ordereDictionary = Utils.Utils.getUrlDoneDictionary(paramsDictionary);
            var redirectMac = _encoder.GetMac(ordereDictionary, _startKey);
            return redirectMac.Equals(receivedMAc);
                
        }

        public BPWXmlResponse<DataAuthorize> Authorize(AuthorizeRequest authorize) {
            var request = RequestMapper.MapAuthorizeRequest(authorize, _shopId);
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataAuthorize>>(xmlResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            return objectResponse;
        }

        public BPWXmlResponse<Data3DSResponse> ThreeDSAuthorize0(ThreeDSAuthorization0Request request) {
            var requestXML = RequestMapper.MapThreeDSAuthorization0Request(request,_shopId);

            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            var xmlBody = XmlTool.Serialize(requestXML);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DSResponse>>(xmlResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            // TODO: verify challenge and threedsmethod
            return objectResponse;
        }

        public BPWXmlResponse<Data3DSResponse> ThreeDSAuthorize1(ThreeDSAuthorization1Request request)
        {
            var requestXML = RequestMapper.MapThreeDSAuthorization1Request(request, _shopId);

            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            var xmlBody = XmlTool.Serialize(requestXML);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DSResponse>>(xmlResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            // TODO: verify challenge and threedsmethod
            return objectResponse;
        }

        public BPWXmlResponse<Data3DSResponse> ThreeDSAuthorize2(ThreeDSAuthorization2Request request)
        {
            var requestXML = RequestMapper.MapThreeDSAuthorization2Request(request, _shopId);

            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            var xmlBody = XmlTool.Serialize(requestXML);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DSResponse>>(xmlResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            // TODO: verify challenge and threedsmethod
            return objectResponse;
        }
        
        public BPWXmlResponse<DataManageOperation> Capture(CaptureRequest captureRequest)
        {
            var request = RequestMapper.MapCaptureRequest(captureRequest, _shopId);
            //calculate MAC
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataManageOperation>>(xmlResponse);
            VerifyOperation(objectResponse.Data.Operation);
            return objectResponse;
        }

        public BPWXmlResponse<DataManageOperation> Refund(RefundRequest request)
        {
            var requestXML = RequestMapper.MapRefundRequest(request, _shopId);

            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);

            // CALL
            var xmlBody = XmlTool.Serialize(requestXML);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataManageOperation>>(xmlResponse);
            VerifyOperation(objectResponse.Data.Operation);
            return objectResponse;
        }

        public BPWXmlResponse<DataOrderStatus> GetOrderStatus(OrderStatusRequest orderStatusRequest)
        {
            // Build Request object
            var requestData = new OrderStatusRequestXML();
            requestData.OrderID = orderStatusRequest.OrderId;
            requestData.ProductRef = orderStatusRequest.ProductRef;
            var request = new BPWXmlRequest<OrderStatusRequestXML>(requestData);

            request.SetHeaderInfo(_shopId, orderStatusRequest.OperatorID);
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);

            var xmlBody = XmlTool.Serialize(request);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataOrderStatus>>(xmlResponse);

            foreach (var authorization in objectResponse.Data.Authorizations)
                VerifyAuthorization(authorization);

            return objectResponse;
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

        private void SetProxy(string proxyName, int proxyPort)
        {
            _restClient.SetProxy(proxyName, proxyPort, null, null);
        }

        private void SetProxy(string proxyName, int proxyPort, string user, string password)
        {
            _restClient.SetProxy(proxyName, proxyPort, user, password);
        }

    }
}