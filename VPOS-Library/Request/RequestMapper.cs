using VPOS_Library.Request;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.Utils
{
    public class RequestMapper
    {
        private RequestMapper() { }

        public static BPWXmlRequest<AccountingRequestXML> MapCaptureRequest(CaptureRequest captureRequest, string shopId) {
            var requestData = new AccountingRequestXML();
            requestData.Amount = captureRequest.Amount;
            requestData.Currency = captureRequest.Currency;
            requestData.TransactionID = captureRequest.TransactionID;
            requestData.OrderId = captureRequest.OrderId;

            var request = new BPWXmlRequest<AccountingRequestXML>(requestData);
            request.SetHeaderInfo(shopId, captureRequest.OperatorID);
   
            return request;
        }

        public static BPWXmlRequest<ThreeDSAuthorization0RequestXML> MapThreeDSAuthorization0Request(ThreeDSAuthorization0Request request, string shopId) {
            var requestData = new ThreeDSAuthorization0RequestXML
            {
                AccountingMode = request.AccountingMode,
                Acquirer = request.Acquirer,
                Amount = request.Amount,
                Antifraud = request.AntiFraud,
                ChallengeWinSize = request.ChallengeWinSize,
                CProf = request.CProf,
                CreatePanAlias = request.CreatePanAlias,
                Currency = request.Currency,
                CVV2 = request.CVV2,

                ThreeDSData = AESEncoder.Encode3DSData(request.MerchantKey, request.ThreeDSData.ToJSONString()),
                EmailCH = request.EmailCh,
                ExpDate = request.ExpDate,
                Exponent = request.Exponent,
                IpAddress = request.IpAddress,
                Name = request.NameCh,
                NameCH = request.NameCh,
                Network = request.Network,
                NotifUrl = request.NotifyUrl,
                OpDescr = request.OpDescr,
                OrderID = request.OrderId,
                Options = request.Options,
                PAN = request.Pan,
                ProductRef = request.ProductRef,
                Surname = request.Surname,
                TaxID = request.TaxId,
                ThreeDSMtdNotifUrl = request.ThreeDSMtdNotifyUrl,
                Userid = request.UserId,
                UsrAuthFlag = request.UsrAuthFlag
            };
            var requestXML = new BPWXmlRequest<ThreeDSAuthorization0RequestXML>(requestData);
            requestXML.SetHeaderInfo(shopId, request.OperatorID);
            return requestXML;
        }

        public static BPWXmlRequest<ThreeDSAuthorization1RequestXML> MapThreeDSAuthorization1Request(ThreeDSAuthorization1Request request, string shopId) {
            var requestData = new ThreeDSAuthorization1RequestXML
            {
                ThreeDSMtdComplInd = request.ThreeDSMtdComplInd,
                ThreeDSTransId = request.ThreeDSTransId
                
            };
            var requestXML = new BPWXmlRequest<ThreeDSAuthorization1RequestXML>(requestData);
            requestXML.SetHeaderInfo(shopId, request.OperatorID);
            return requestXML;
        }

        public static BPWXmlRequest<ThreeDSAuthorization2RequestXML> MapThreeDSAuthorization2Request(ThreeDSAuthorization2Request request, string shopId)
        {
            var requestData = new ThreeDSAuthorization2RequestXML
            {
                ThreeDSTransId = request.ThreeDSTransId
            };
            var requestXML = new BPWXmlRequest<ThreeDSAuthorization2RequestXML>(requestData);
            requestXML.SetHeaderInfo(shopId, request.OperatorID);
            return requestXML;
        }

        public static BPWXmlRequest<AuthorizeRequestXML> MapAuthorizeRequest(AuthorizeRequest authorize, string shopId) {
            var requestData = new AuthorizeRequestXML();
            requestData.AccountingMode = authorize.AccountingMode;
            requestData.Acquirer = authorize.Acquirer;
            requestData.Amount = authorize.Amount;
            requestData.Antifraud = authorize.AntiFraud;
            requestData.CreatePanAlias = authorize.CreatePanAlias;
            requestData.Currency = authorize.Currency;
            requestData.CVV2 = authorize.CVV2;
            requestData.EmailCH = authorize.EmailCh;
            requestData.ExpDate = authorize.ExpDate;
            requestData.Exponent = authorize.Exponent;
            requestData.IpAddress = authorize.IpAddress;
            requestData.Name = authorize.Name;
            requestData.Network = authorize.Network;
            requestData.OpDescr = authorize.OpDescr;
            requestData.Options = authorize.Options;
            requestData.OrderID = authorize.OrderId;
            requestData.PAN = authorize.Pan;
            requestData.ProductRef = authorize.ProductRef;
            requestData.Surname = authorize.Surname;
            requestData.TaxID = authorize.TaxId;
            requestData.Userid = authorize.UserId;
            requestData.UsrAuthFlag = authorize.UsrAuthFlag;

            var request = new BPWXmlRequest<AuthorizeRequestXML>(requestData);
            request.SetHeaderInfo(shopId, authorize.OperatorID);
            return request;
        }

        public static BPWXmlRequest<RefundRequestXML> MapRefundRequest(RefundRequest request, string shopId) {
            var requestData = new RefundRequestXML();
            requestData.Amount = request.Amount;
            requestData.Currency = request.Currency;
            //"8032112928AT2415xxp7isdz4"
            requestData.TransactionID = request.TransactionID;
            //713739306616251603317204
            requestData.OrderId = request.OrderId;

            var requestXML = new BPWXmlRequest<RefundRequestXML>(requestData);
            requestXML.SetHeaderInfo(shopId, request.OperatorID);
            return requestXML;
        }

        public static BPWXmlRequest<OrderStatusRequestXML> MapOrderStatusRequest(OrderStatusRequest statusRequest, string shopId)
        {
            var requestData = new OrderStatusRequestXML();
            requestData.OrderID = statusRequest.OperatorID;
            requestData.ProductRef = statusRequest.ProductRef;
            var requestXML = new BPWXmlRequest<OrderStatusRequestXML>(requestData);

            requestXML.SetHeaderInfo(shopId, statusRequest.OperatorID);
            return requestXML;
        }

    }
}