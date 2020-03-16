using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;
using VPOS_Library.Models;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.Utils.MAC
{
    public class RequestHandler
    {
        public static OrderedDictionary GetMacDictionary<T>(BPWXmlRequest<T> request) where T : GenericRequest
        {
            var res = GetCommonParameters(request);

            if (request.Data.RequestTag is AuthorizationRequest)
                Auth3DSDictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is AuthorizationRequest3DSStep2)
                Auth3DSStep2Dictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is VerifyRequest)
                VerifyDictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is OrderStatusRequest)
                OrderStatusDictionary(request.Data.RequestTag, res);
            else
                ManageDictionary(request.Data.RequestTag, res);
            return res;
        }

        private static OrderedDictionary GetCommonParameters<T>(BPWXmlRequest<T> request) where T : GenericRequest
        {
            var result = new OrderedDictionary();
            result.Add("OPERATION", request.Request.Operation);
            result.Add("TIMESTAMP", request.Request.Timestamp);
            result.Add("SHOPID", request.Data.RequestTag.Header.ShopID);
            return result;
        }

        public static OrderedDictionary GetRedirectDictionary(PaymentInfo paymentInfo)
        {
            var result = new OrderedDictionary();
            result.Add("URLMS", paymentInfo.UrlMs);
            result.Add("URLDONE", paymentInfo.UrlDone);
            result.Add("ORDERID", paymentInfo.OrderId);
            result.Add("SHOPID", paymentInfo.ShopId);
            result.Add("AMOUNT", paymentInfo.Amount);
            result.Add("CURRENCY", paymentInfo.Currency);
            result.Add("EXPONENT", paymentInfo.Exponent);
            result.Add("ACCOUNTINGMODE", paymentInfo.AccountingMode);
            result.Add("AUTHORMODE", paymentInfo.AuthorMode);
            result.Add("OPTIONS", paymentInfo.GetOptions());
            result.Add("NAME", paymentInfo.Name);
            result.Add("SURNAME", paymentInfo.Surname);
            result.Add("TAXID", paymentInfo.TaxId);
            result.Add("LOCKCARD", paymentInfo.Lockcard);
            result.Add("COMMIS", paymentInfo.Commis);
            result.Add("ORDDESCR", paymentInfo.OrdDescr);
            result.Add("VSID", paymentInfo.Vsid);
            result.Add("OPDESCR", paymentInfo.OpDescr);
            result.Add("REMAININGDURATION", paymentInfo.RemainingDuration);
            result.Add("USERID", paymentInfo.UserId);
            result.Add("BP_POSTEPAY", paymentInfo.BpPostepay);
            result.Add("BP_CARDS", paymentInfo.BpCards);
            result.Add("PHONENUMBER", paymentInfo.PhoneNumber);
            result.Add("CAUSATION", paymentInfo.Causation);
            result.Add("USER", paymentInfo.User);
            result.Add("PRODUCTREF", paymentInfo.ProductRef);
            result.Add("ANTIFRAUD", paymentInfo.AntiFraud);
            result.Add("3DSDATA", paymentInfo.Data3DS);
            return result;
        }

        public static void AddMissingParameter(OrderedDictionary dictionary, PaymentInfo info)
        {
            dictionary.Add("URLBACK", info.UrlBack);
            dictionary.Add("SHOPEMAIL", info.ShopEmail);
        }

        private static void AddCommonParameters(GenericRequest request, OrderedDictionary dictionary)
        {
            dictionary.Add("OPERATORID", request.Header.OperatorID);
            dictionary.Add("REQREFNUM", request.Header.ReqRefNum);
        }

        private static void Auth3DSDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (AuthorizationRequest) request;
            dictionary.Add("ORDERID", specificRequest.OrderID);
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("PAN", specificRequest.PAN);
            dictionary.Add("CVV2", specificRequest.CVV2);
            dictionary.Add("EXPDATE", specificRequest.ExpDate);
            dictionary.Add("AMOUNT", specificRequest.Amount);
            dictionary.Add("CURRENCY", specificRequest.Currency);
            dictionary.Add("EXPONENT", specificRequest.Exponent);
            dictionary.Add("ACCOUNTINGMODE", specificRequest.AccountingMode);
            dictionary.Add("NETWORK", specificRequest.Network);
            dictionary.Add("EMAILCH", specificRequest.EmailCH);
            dictionary.Add("USERID", specificRequest.Userid);
            dictionary.Add("ACQUIRER", specificRequest.Acquirer);
            dictionary.Add("IPADDRESS", specificRequest.IpAddress);
            dictionary.Add("OPDESCR", specificRequest.OpDescr);
            dictionary.Add("USRAUTHFLAG", specificRequest.UsrAuthFlag);
            dictionary.Add("OPTIONS", specificRequest.Options);
            dictionary.Add("ANTIFRAUD", specificRequest.Antifraud);
            dictionary.Add("PRODUCTREF", specificRequest.ProductRef);
            dictionary.Add("NAME", specificRequest.Name);
            dictionary.Add("SURNAME", specificRequest.Surname);
            dictionary.Add("TAXID", specificRequest.TaxID);
            dictionary.Add("INPERSON", specificRequest.InPerson);
            dictionary.Add("MERCHANTURL", specificRequest.MerchantURL);
            dictionary.Add("SERVICE", specificRequest.Data3DS.Service);
            dictionary.Add("XID", specificRequest.Data3DS.Xid);
            dictionary.Add("CAVV", specificRequest.Data3DS.CAVV);
            dictionary.Add("ECI", specificRequest.Data3DS.Eci);
            dictionary.Add("PP_AUTHENTICATEMETHOD", specificRequest.MasterpassData.PP_AuthenticateMethod);
            dictionary.Add("PP_CARDENROLLMETHOD", specificRequest.MasterpassData.PP_CardEnrollMethod);
            dictionary.Add("PARESSTATUS", specificRequest.Data3DS.ParesStaus);
            dictionary.Add("SCENROLLSTATUS", specificRequest.Data3DS.ScEnrollStatus);
            dictionary.Add("SIGNATUREVERIFICATION", specificRequest.Data3DS.SignatureVerifytion);
        }

        private static void Auth3DSStep2Dictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (AuthorizationRequest3DSStep2) request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("ORIGINALREQREFNUM", specificRequest.OriginalReqRefNum);
            dictionary.Add("PARES", specificRequest.Pares);
            dictionary.Add("ACQUIRER", specificRequest.Acquirer);
        }

        private static void VerifyDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (VerifyRequest) request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("ORIGINALREQREFNUM", specificRequest.OriginalReqRefNum);
            dictionary.Add("OPTIONS", specificRequest.Options);
        }

        private static void OrderStatusDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (OrderStatusRequest) request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("ORDERID", specificRequest.OrderID);
            dictionary.Add("OPTIONS", specificRequest.Options);
            dictionary.Add("PRODUCTREF", specificRequest.ProductRef);
        }

        private static void ManageDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (ManageRequest) request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("TRANSACTIONID", specificRequest.TransactionID);
            dictionary.Add("ORDERID", specificRequest.OrderId);
            dictionary.Add("AMOUNT", specificRequest.Amount);
            dictionary.Add("CURRENCY", specificRequest.Currency);
            dictionary.Add("EXPONENT", specificRequest.Exponent);
            dictionary.Add("OPDESCR", specificRequest.OpDescr);
            dictionary.Add("OPTIONS", specificRequest.Options);
        }
    }
}