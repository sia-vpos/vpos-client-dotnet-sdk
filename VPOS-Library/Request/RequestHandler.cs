using System.Collections.Specialized;
using VPOS_Library.Models;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.Utils.MAC
{
    public class RequestHandler
    {
        public static OrderedDictionary GetMacDictionary<T>(BPWXmlRequest<T> request) where T : GenericRequest
        {
            var res = GetCommonParameters(request);

            if (request.Data.RequestTag is AuthorizeRequestXML)
                AuthorizeDictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is OrderStatusRequestXML)
                OrderStatusDictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is ThreeDSAuthorization0RequestXML)
                ThreeDSAuthorization0Dictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is ThreeDSAuthorization1RequestXML)
                ThreeDSAuthorization1Dictionary(request.Data.RequestTag, res);
            else if (request.Data.RequestTag is ThreeDSAuthorization2RequestXML)
                ThreeDSAuthorization2Dictionary(request.Data.RequestTag, res);
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

        public static OrderedDictionary GetRedirectDictionary(PaymentInfo paymentInfo, string apiSecretKey)
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
            if (paymentInfo.GetOptions() != null && paymentInfo.GetOptions().Contains("B"))
            {    
                result.Add("NAME", paymentInfo.Name);
                result.Add("SURNAME", paymentInfo.Surname); 
            }
            result.Add("TAXID", paymentInfo.TaxId);
            result.Add("LOCKCARD", paymentInfo.Lockcard);
            if (paymentInfo.GetOptions() != null && paymentInfo.GetOptions().Contains("F"))
            {
                result.Add("COMMIS", paymentInfo.Commis);
            }
            if (paymentInfo.GetOptions() != null && (paymentInfo.GetOptions().Contains("O")|| paymentInfo.GetOptions().Contains("V")))
            {
                result.Add("ORDDESCR", paymentInfo.OrdDescr);
            }
            result.Add("VSID", paymentInfo.Vsid);
            result.Add("OPDESCR", paymentInfo.OpDescr);
            if (paymentInfo.GetOptions() != null && paymentInfo.GetOptions().Contains("D"))
            {
                result.Add("REMAININGDURATION", paymentInfo.RemainingDuration);
            }
            result.Add("USERID", paymentInfo.UserId);
            result.Add("BP_POSTEPAY", paymentInfo.BpPostepay);
            result.Add("BP_CARDS", paymentInfo.BpCards);
            if (paymentInfo.Network != null && paymentInfo.Network.Equals("91"))
            {
                result.Add("PHONENUMBER", paymentInfo.PhoneNumber);
                result.Add("CAUSATION", paymentInfo.Causation);
                result.Add("USER", paymentInfo.User);
            }
            result.Add("PRODUCTREF", paymentInfo.ProductRef);
            result.Add("ANTIFRAUD", paymentInfo.AntiFraud);
            if (paymentInfo.Data3DS != null)
            {
                result.Add("3DSDATA", AESEncoder.Encode3DSData(apiSecretKey, paymentInfo.Data3DS.ToJSONString()));
            }
            result.Add("TRECURR", paymentInfo.TRecurr);
            result.Add("CRECURR", paymentInfo.CRecurr);
            result.Add("TOKEN", paymentInfo.Token);
            result.Add("EXPDATE", paymentInfo.ExpDate);
            result.Add("NETWORK", paymentInfo.Network);
            result.Add("IBAN", paymentInfo.IBAN);
            return result;
        }

        public static void AddMissingParameter(OrderedDictionary dictionary, PaymentInfo info)
        {
            dictionary.Add("URLBACK", info.UrlBack);
            dictionary.Add("LANG", info.Lang);
            dictionary.Add("SHOPEMAIL", info.ShopEmail);
            dictionary.Add("EMAIL", info.Email);
            dictionary.Add("NAMECH", info.NameCH);
            dictionary.Add("SURNAMECH", info.SurnameCH);

        }

        private static void AddCommonParameters(GenericRequest request, OrderedDictionary dictionary)
        {
            dictionary.Add("OPERATORID", request.Header.OperatorID);
            dictionary.Add("REQREFNUM", request.Header.ReqRefNum);
        }

        private static void Auth3DSDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (AuthorizationRequest)request;
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

        }

        private static void AuthorizeDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (AuthorizeRequestXML)request;
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

        }

        private static void Auth3DSStep2Dictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (AuthorizationRequest3DSStep2)request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("ORIGINALREQREFNUM", specificRequest.OriginalReqRefNum);
            dictionary.Add("PARES", specificRequest.Pares);
            dictionary.Add("ACQUIRER", specificRequest.Acquirer);
        }

        private static void VerifyDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (VerifyRequest)request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("ORIGINALREQREFNUM", specificRequest.OriginalReqRefNum);
            dictionary.Add("OPTIONS", specificRequest.Options);
        }

        private static void OrderStatusDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (OrderStatusRequestXML)request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("ORDERID", specificRequest.OrderID);
            dictionary.Add("OPTIONS", specificRequest.Options);
            dictionary.Add("PRODUCTREF", specificRequest.ProductRef);
        }

        private static void ThreeDSAuthorization0Dictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (ThreeDSAuthorization0RequestXML)request;
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
            dictionary.Add("THREEDSDATA", specificRequest.ThreeDSData);
            dictionary.Add("NAMECH", specificRequest.NameCH);
            dictionary.Add("NOTIFURL", specificRequest.NotifUrl);
            dictionary.Add("THREEDSMTDNOTIFURL", specificRequest.ThreeDSMtdNotifUrl);
            dictionary.Add("CHALLENGEWINSIZE", specificRequest.ChallengeWinSize);
        }
        private static void ThreeDSAuthorization1Dictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (ThreeDSAuthorization1RequestXML)request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("THREEDSTRANSID", specificRequest.ThreeDSTransId);
            dictionary.Add("THREEDSMTDCOMPLIND", specificRequest.ThreeDSMtdComplInd);
        }
        private static void ThreeDSAuthorization2Dictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (ThreeDSAuthorization1RequestXML)request;
            AddCommonParameters(specificRequest, dictionary);
            dictionary.Add("THREEDSTRANSID", specificRequest.ThreeDSTransId);
            
        }
        private static void ManageDictionary(GenericRequest request, OrderedDictionary dictionary)
        {
            var specificRequest = (ManageRequest)request;
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