using java.lang;
using System;
using System.Collections.Generic;
using System.Web;
using VPOS_Library.Models;
using VPOS_Library.Request;
using VPOS_Library.Response;
using VPOS_Library.Utils;
using VPOS_Library.Utils.Exception;
using VPOS_Library.Utils.MAC;
using VPOS_Library.XML;
using VPOS_Library.XML.Models;
using Operation = VPOS_Library.XML.Models.Operation;

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

        public VPOSClient(string apiUrl, string apiResultKey, string startKey, string shopId, string redirectUrl)
        {

            _encoder = new MacEncoder();
            _restClient = new RestClient(15);
            _htmlTool = new HtmlTool();
            _urlAPI = apiUrl;
            _apiResultKey = apiResultKey;
            _startKey = startKey;
            _shopId = shopId;
            _urlRedirect = redirectUrl;
        }

        public VPOSClient(Config config)
        {
            ValidateConfig(config);
            _urlAPI = config.ApiUrl;
            _apiResultKey = config.ApiKey;
            _startKey = config.RedirectKey;
            _shopId = config.ShopID;
            _urlRedirect = config.RedirectUrl;

            _encoder = new MacEncoder();
            _htmlTool = new HtmlTool();
            if (config.Certificate != null)
            {
                _restClient = new RestClient(config.Timeout, config.Certificate);
            }
            else {
                _restClient = new RestClient(config.Timeout);
            }
            if (config.ProxyHost != null && !string.IsNullOrEmpty(config.ProxyPort.ToString())) {
                if (config.ProxyUsername != null && config.ProxyPassword != null)
                {
                    SetProxy(config.ProxyHost, config.ProxyPort, config.ProxyUsername, config.ProxyPassword);
                }
                else {
                    SetProxy(config.ProxyHost, config.ProxyPort);
                }
            }

        }

        private void ValidateConfig(Config config)
        {
            List<string> fields = new List<string>();
            if (config.ShopID == null)
            {
                fields.Add("SHOPID");
            }
            else if (config.ApiKey == null)
            {
                fields.Add("APIRESULTKEY");
            }
            else if (config.ApiUrl == null)
            {
                fields.Add("APIURL");
            }
            else if (config.RedirectKey == null)
            {
                fields.Add("REDIRECTKEY");
            }
            else if (config.RedirectUrl == null)
            {
                fields.Add("REDIRECTURL");
            }
            if (fields.Count > 0)
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
            // Build dictionary with input params
            var redirectDictionary = RequestHandler.GetRedirectDictionary(paymentInfo, _apiResultKey, _shopId);
            //Calculate MAC and add to dictionary
            var redirectMac = _encoder.GetMac(redirectDictionary, _startKey);
            redirectDictionary.Add("MAC", redirectMac);
            // Add UrlBack and ShopEmail
            RequestHandler.AddMissingParameter(redirectDictionary, paymentInfo);
            // Build HTML div and return
            return _htmlTool.BuildHtml(_urlRedirect , redirectDictionary);
        }

        public bool VerifyMac(string urlDone)
        { 
            // Extracts params from url
            var paramsDictionary = Utils.Utils.splitQuery(urlDone);
            // Get received MAC
            var receivedMAc = paramsDictionary["MAC"];

            // Calculate MAC
            var ordereDictionary = Utils.Utils.getUrlDoneDictionary(paramsDictionary);
            var redirectMac = _encoder.GetMac(ordereDictionary, _apiResultKey);
            // Compare the received Mac with the calculated one

            return redirectMac.Equals(receivedMAc);
                
        }

        public AuthorizeResponse Authorize(AuthorizeRequest authorize) {
            // Validate request
            RequestValidator.ValidateAuthorizeRequest(authorize);
            // Map input request in the XML Request
            var request = RequestMapper.MapAuthorizeRequest(authorize, _shopId);
            // Calculate and set MAC
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            // Do call to VPOS
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            // Map response
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataAuthorize>>(xmlResponse);
            // Verify Response MAC
            VerifyMacResponse(objectResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            VerifyPanAliasData(objectResponse.Data.PanAliasData);
            //Response Mapping        
            return ResponseMapper.MapAuthorize(objectResponse); ;
        }

        public ThreeDSAuthorization0Response ThreeDSAuthorize0(ThreeDSAuthorization0Request request) {
            // Validate request
            RequestValidator.ValidateThreeDSAuthorize0Request(request);
            // Map input request in the XML Request
            var requestXML = RequestMapper.MapThreeDSAuthorization0Request(request,_shopId, _apiResultKey);
            // Calculate and set MAC
            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            // Url Encode ThreeDSData to correctly send it
            requestXML.Data.RequestTag.ThreeDSData = HttpUtility.UrlEncode(requestXML.Data.RequestTag.ThreeDSData);
            var xmlBody = XmlTool.Serialize(requestXML);
            // Do call
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            // Map response
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DSResponse>>(xmlResponse);
            // Verify Response MAC
            VerifyMacResponse(objectResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            VerifyPanAliasData(objectResponse.Data.PanAliasData);
            VerifyThreeDSChallenge(objectResponse.Data.ThreeDSChallenge);
            VerifyThreeDSMethod(objectResponse.Data.ThreeDSMethod);
            return ResponseMapper.MapThreeDSAuthorization0(objectResponse);
        }

        public ThreeDSAuthorization1Response ThreeDSAuthorize1(ThreeDSAuthorization1Request request)
        {
            // Validate request
            RequestValidator.ValidateThreeDSAuthorize1Request(request);
            // Map input request in the XML Request
            var requestXML = RequestMapper.MapThreeDSAuthorization1Request(request, _shopId);
            // Calculate and set MAC
            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            var xmlBody = XmlTool.Serialize(requestXML);
            // Do call to VPOS
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            // Map response
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DSResponse>>(xmlResponse);
            // Verify Mac Response
            VerifyMacResponse(objectResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            VerifyPanAliasData(objectResponse.Data.PanAliasData);
            VerifyThreeDSChallenge(objectResponse.Data.ThreeDSChallenge);           
            return ResponseMapper.MapThreeDSAuthorization1(objectResponse);
        }

        public ThreeDSAuthorization2Response ThreeDSAuthorize2(ThreeDSAuthorization2Request request)
        {
            // Validate request
            RequestValidator.ValidateThreeDSAuthorize2Request(request);
            // Map input request in the XML Request
            var requestXML = RequestMapper.MapThreeDSAuthorization2Request(request, _shopId);
            // Calculate and set MAC
            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            var xmlBody = XmlTool.Serialize(requestXML);
            // Do call to VPOS
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<Data3DSResponse>>(xmlResponse);
            // Verify Mac Response
            VerifyMacResponse(objectResponse);
            VerifyAuthorization(objectResponse.Data.Authorization);
            VerifyPanAliasData(objectResponse.Data.PanAliasData);
            return ResponseMapper.MapThreeDSAuthorization2(objectResponse);
        }
        
        public CaptureResponse Capture(CaptureRequest captureRequest)
        {
            // Validate request
            RequestValidator.ValidateCaptureRequest(captureRequest);
            // Map input request in the XML Request
            var request = RequestMapper.MapCaptureRequest(captureRequest, _shopId);
            //calculate MAC
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            // Do call to VPOS
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataManageOperation>>(xmlResponse);
            // Verify Mac Response
            VerifyMacResponse(objectResponse);
            VerifyOperation(objectResponse.Data.Operation);
            return ResponseMapper.MapCaptureResponse(objectResponse);
        }

        public RefundResponse Refund(RefundRequest request)
        {
            // Validate Request
            RequestValidator.ValidateRefundRequest(request);
            // Map input request in the XML Request
            var requestXML = RequestMapper.MapRefundRequest(request, _shopId);
            //calculate MAC
            requestXML.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(requestXML), _apiResultKey);
            // Do call to VPOS
            var xmlBody = XmlTool.Serialize(requestXML);
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataManageOperation>>(xmlResponse);
            // Verify Mac Response
            VerifyMacResponse(objectResponse);
            VerifyOperation(objectResponse.Data.Operation);
            return ResponseMapper.MapRefundResponse(objectResponse);
        }

        public OrderStatusResponse GetOrderStatus(OrderStatusRequest orderStatusRequest)
        {
            // Validate Request
            RequestValidator.ValidateOrderStatusRequest(orderStatusRequest);
            // Build Request object
            var request = RequestMapper.MapOrderStatusRequest(orderStatusRequest,_shopId);
            request.Request.MAC = _encoder.GetMac(RequestHandler.GetMacDictionary(request), _apiResultKey);
            var xmlBody = XmlTool.Serialize(request);
            // Do call to VPOS
            var xmlResponse = _restClient.CallApi(_urlAPI, xmlBody);
            // Map response
            var objectResponse = XmlTool.Deserialize<BPWXmlResponse<DataOrderStatus>>(xmlResponse);
            // Verify Mac Response
            VerifyMacResponse(objectResponse);
            VerifyPanAliasData(objectResponse.Data.PanAliasData);
            foreach (var authorization in objectResponse.Data.Authorizations)
                VerifyAuthorization(authorization);

            return ResponseMapper.MapOrderStatusResponse(objectResponse);
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

        private void VerifyMacResponse<T>(BPWXmlResponse<T> response) {
            string BAD_REQUEST = "03";
            string INVALID_MAC = "04";

            if (response != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.ResponseMacList(response), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && String.Equals(BAD_REQUEST, response.Result) && String.Equals(INVALID_MAC, response.Result) && !digest.Equals(response.MAC))
                    throw new IncorrectMacException(
                        "The provided digest not corresponding to the calculated one. Possible data corruption!");
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

        private void VerifyThreeDSMethod(ThreeDSMethod threeDSMethod)
        {
            if (threeDSMethod != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.ThreeDSMethodMacList(threeDSMethod), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(threeDSMethod.MAC))
                    throw new IncorrectMacException(
                        "ThreeDSMethod digest not corresponding to the calculated one. Possible data corruption!");
            }
        }

        private void VerifyThreeDSChallenge(ThreeDSChallenge threeDSChallenge)
        {
            if (threeDSChallenge != null)
            {
                var digest = _encoder.GetMac(ResponseHandler.ThreeDSChallengeMacList(threeDSChallenge), _apiResultKey);
                if (!digest.Equals(MacNeutralValue) && !digest.Equals(threeDSChallenge.MAC))
                    throw new IncorrectMacException(
                        "ThreeDSChallenge digest not corresponding to the calculated one. Possible data corruption!");
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
