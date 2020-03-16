using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace VPOS_Library.XML.Models
{
    public class Printable
    {
        public override string ToString()
        {
            var info = this.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return info.Aggregate("", (current, next) => current + next.Name + "=" + next.GetValue(this) + "\n");
        }
    }

    [XmlRoot("BPWXmlResponse")]
    public class BPWXmlResponse<T> : Printable
    {
        public string Timestamp;
        public string Result;
        public string MAC;
        public T Data;
    }

    public class Data3DS : Printable
    {
        public Authorization Authorization;
        public VBVRedirect VBVRedirect;
        public PanAliasData PanAliasData;
    }

    public class DataOrderStatus : Printable
    {
        public string ProductRef;
        public string NumberOfItems;
        [XmlElement("Authorization")] public List<Authorization> Authorizations;
    }

    public class DataVerify : Printable
    {
        public Verify Verify;
    }

    public class DataManageOperation : Printable
    {
        public Operation Operation;
    }

    public class Operation : Printable
    {
        public string TransactionID;
        public string TimestampReq;
        public string TimestampElab;
        public string SrcType;
        public string Amount;
        public string Result;
        public string Status;
        public string OpDescr;
        public string MAC;
        public Authorization Authorization;
    }

    public class Authorization : Printable
    {
        public string PaymentType;
        public string AuthorizationType;
        public string TransactionID;
        public string Network;
        public string OrderId;
        public string TransactionAmount;
        public string AuthorizedAmount;
        public string Currency;
        public string Exponent;
        public string AccountedAmount;
        public string RefundedAmount;
        public string TransactionResult;
        public string Timestamp;
        public string AuthorizationNumber;
        public string AcquirerBIN;
        public string MerchantID;
        public string TransactionStatus;
        public string ResponseCodeISO;
        public string PanTail;
        public string PanExpiryDate;
        public string PaymentTypePP;
        public string RRN;
        public string CardType;
        public string MAC;
    }

    public class PanAliasData : Printable
    {
        public string PanAlias;
        public string PanAliasRev;
        public string PanAliasExpDate;
        public string PanAliasTail;
        public string MAC;
    }

    public class VBVRedirect : Printable
    {
        public string PaReq;
        public string AcsURL;
        public string MAC;
    }

    public class Verify : Printable
    {
        public string Operation;
        public string Result;
        public string TransactionID;
        public string MAC;
    }
}