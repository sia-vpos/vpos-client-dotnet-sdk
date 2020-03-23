using System;
using System.Runtime.ConstrainedExecution;
using System.Xml.Serialization;
using VPOS_Library.Models;

namespace VPOS_Library.XMLModels.Request
{
    [XmlRoot("BPWXmlRequest")]
    public class BPWXmlRequest<T> where T : GenericRequest
    {
        private const string ReleaseValue = "02";
        private const string DateFormat = "yyyyMMdd";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

        public string Release;
        public Request Request;
        public Data<T> Data;

        private BPWXmlRequest()
        {
        }

        public BPWXmlRequest(T data)
        {
            var timestamp = DateTime.UtcNow;
            Data = new Data<T>(data);
            Release = ReleaseValue;
            Request = new Request(GetOperation(), timestamp.ToString(DateTimeFormat));
            SetReqRefNum(timestamp);
        }

        public void SetHeaderInfo(string shopId, string operatorId)
        {
            var header = Data.RequestTag.Header;
            header.OperatorID = operatorId;
            header.ShopID = shopId;
        }

        private Operation GetOperation()
        {
            if (Data.RequestTag is AuthorizeRequestXML)
                return Operation.AUTHORIZATION;
            if (Data.RequestTag is RefundRequestXML)
                return Operation.REFUND;
            if (Data.RequestTag is AccountingRequestXML)
                return Operation.ACCOUNTING;
            if (Data.RequestTag is OrderStatusRequestXML)
                return Operation.ORDERSTATUS;
            if (Data.RequestTag is ThreeDSAuthorization0RequestXML)
                return Operation.THREEDSAUTHORIZATION0;
            if (Data.RequestTag is ThreeDSAuthorization1RequestXML)
                return Operation.THREEDSAUTHORIZATION1;
            if (Data.RequestTag is ThreeDSAuthorization2RequestXML)
                return Operation.THREEDSAUTHORIZATION2;
            return Operation.VERIFY;
        }

        private void SetReqRefNum(DateTime timestamp)
        {
            var random = new Random();
            var reqNum = timestamp.ToString(DateFormat);

            for (var i = 0; i < 24; i++)
                reqNum += random.Next(0, 9).ToString();
            Data.RequestTag.Header.ReqRefNum = reqNum;
        }
    }

    public class Data<T> where T : GenericRequest
    {
        public T RequestTag;

        private Data()
        {
        }

        internal Data(T data)
        {
            RequestTag = data;
        }
    }

    public class Request
    {
        public string Operation;
        public string Timestamp;
        public string MAC;

        private Request()
        {
        }

        internal Request(Operation operation, string timestamp)
        {
            Operation = operation.ToString();
            Timestamp = timestamp;
        }
    }

    public abstract class GenericRequest
    {
        public Header Header;
        public string Options;

        internal GenericRequest()
        {
            Header = new Header();
        }

        public abstract string GetRequestTag();
    }

    public class Header
    {
        public string ShopID;
        public string OperatorID;
        public string ReqRefNum;

        internal Header()
        {
        }
    }

    public class AuthorizationRequest : GenericRequest
    {
        private const string TagName = "AuthorizationRequest";

        public Data3ds Data3DS;
        public MasterpassData MasterpassData;
        public string OrderID;
        public string PAN;
        public string CVV2;
        public string ExpDate;
        public string Amount;
        public string Currency;
        public string Exponent;
        public string AccountingMode;
        public string Network;
        public string EmailCH;
        public string Userid;
        public string OpDescr;
        public string InPerson;
        public string MerchantURL;
        public string IpAddress;
        public string UsrAuthFlag;
        public string Antifraud;
        public string Acquirer;
        public string ProductRef;
        public string Name;
        public string Surname;
        public string TaxID;

        public AuthorizationRequest() : base()
        {
            Data3DS = new Data3ds();
            MasterpassData = new MasterpassData();
        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class Data3ds
    {
        public string Service;
        public string Eci;
        public string Xid;
        public string CAVV;
        public string ParesStaus;
        public string ScEnrollStatus;
        public string SignatureVerifytion;

        internal Data3ds()
        {
        }
    }

    public class MasterpassData
    {
        public string PP_AuthenticateMethod;
        public string PP_CardEnrollMethod;

        internal MasterpassData()
        {
        }
    }

    public class AuthorizationRequest3DSStep2 : GenericRequest
    {
        private const string TagName = "Authorization3DS";
        public string OriginalReqRefNum;
        public string Pares;
        public string Acquirer;

        public AuthorizationRequest3DSStep2() : base()
        {
        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public abstract class ManageRequest : GenericRequest
    {
        public string TransactionID;
        public string OrderId;
        public string Amount;
        public string Exponent;
        public string Currency;
        public string OpDescr;

        public ManageRequest() : base()
        {
        }
    }

    public class ThreeDSAuthorization0RequestXML : GenericRequest 
    {
        private const string TagName = "ThreeDSAuthorizationRequest0";

        public string ThreeDSData;
        public string OrderID;
        public string PAN;
        public string CVV2;
        public string ExpDate;
        public string Amount;
        public string Currency;
        public string Exponent;
        public string AccountingMode;
        public string Network;
        public string EmailCH;
        public string NameCH;
        public string Userid;
        public string Acquirer;
        public string IpAddress;
        public string UsrAuthFlag;
        public string OpDescr;
        public string Antifraud;
        public string ProductRef;
        public string Name;
        public string Surname;
        public string TaxID;
        public string CreatePanAlias;
        public string NotifUrl;
        public string CProf;
        public string ThreeDSMtdNotifUrl;
        public string ChallengeWinSize;
        
        

        public ThreeDSAuthorization0RequestXML() : base()
        {
            
        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }
    public class ThreeDSAuthorization1RequestXML : GenericRequest
    {
        private const string TagName = "ThreeDSAuthorizationRequest1";

        public string ThreeDSTransId;
        public string ThreeDSMtdComplInd;

        public ThreeDSAuthorization1RequestXML() : base()
        {

        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }
    public class ThreeDSAuthorization2RequestXML : GenericRequest
    {
        private const string TagName = "ThreeDSAuthorizationRequest2";

        public string ThreeDSTransId;
        

        public ThreeDSAuthorization2RequestXML() : base()
        {

        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }
    public class RefundRequestXML : ManageRequest
    {
        private const string TagName = "Refund";

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class AccountingRequestXML : ManageRequest
    {
        private const string TagName = "Accounting";

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class AuthorizeRequestXML : GenericRequest
    {
        private const string TagName = "AuthorizationRequest";

       
        public string OrderID;
        public string PAN;
        public string CVV2;
        public string ExpDate;
        public string Amount;
        public string Currency;
        public string Exponent;
        public string AccountingMode;
        public string Network;
        public string EmailCH;
        public string Userid;
        public string Acquirer;
        public string UsrAuthFlag;
        public string IpAddress;
        public string OpDescr;
        public string CreatePanAlias;
        public string Antifraud;
        public string ProductRef;
  
        public string Name;
        public string Surname;
        public string TaxID;

        public AuthorizeRequestXML() : base() { }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class OrderStatusRequestXML : GenericRequest
    {
        private const string TagName = "OrderStatus";

        public string OrderID;
        public string ProductRef;

        public OrderStatusRequestXML() : base()
        {
        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class VerifyRequest : GenericRequest
    {
        private const string TagName = "Verify";

        public string OriginalReqRefNum;

        public VerifyRequest() : base()
        {
        }

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    internal enum Operation
    {
        REFUND,
        AUTHORIZATION,
        VERIFY,
        ORDERSTATUS,
        ACCOUNTING,
        AUTHORIZATION3DSSTEP1,
        AUTHORIZATION3DSSTEP2,
        THREEDSAUTHORIZATION0,
        THREEDSAUTHORIZATION1, 
        THREEDSAUTHORIZATION2
    }
}