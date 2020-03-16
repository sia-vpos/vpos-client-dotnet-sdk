using System;
using System.Runtime.ConstrainedExecution;
using System.Xml.Serialization;

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
            if (Data.RequestTag is AuthorizationRequest)
                return Operation.AUTHORIZATION3DSSTEP1;
            if (Data.RequestTag is AuthorizationRequest3DSStep2)
                return Operation.AUTHORIZATION3DSSTEP2;
            if (Data.RequestTag is RefundRequest)
                return Operation.REFUND;
            if (Data.RequestTag is AccountingRequest)
                return Operation.ACCOUNTING;
            if (Data.RequestTag is OrderStatusRequest)
                return Operation.ORDERSTATUS;
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

    public class RefundRequest : ManageRequest
    {
        private const string TagName = "Refund";

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class AccountingRequest : ManageRequest
    {
        private const string TagName = "Accounting";

        public override string GetRequestTag()
        {
            return TagName;
        }
    }

    public class OrderStatusRequest : GenericRequest
    {
        private const string TagName = "OrderStatus";

        public string OrderID;
        public string ProductRef;

        public OrderStatusRequest() : base()
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
        VERIFY,
        ORDERSTATUS,
        ACCOUNTING,
        AUTHORIZATION3DSSTEP1,
        AUTHORIZATION3DSSTEP2
    }
}