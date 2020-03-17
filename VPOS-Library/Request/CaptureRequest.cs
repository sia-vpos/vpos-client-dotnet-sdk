using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Request
{
    public class CaptureRequest
    {
        private string _operatorId;
        private string _transactionId;
        private string _orderId;
        private string _amount;
        private string _currency;
        private string _exponent;
        private string _opDescr;
        private string _options;

        public CaptureRequest() { 
        }

        public string OrderId { get { return _orderId; } set { _orderId = value; } }

        public string TransactionID { get { return _transactionId; } set { _transactionId = value; } }

        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }

        public string Amount { get { return _amount; } set { _amount = value; } }

        public string Currency { get { return _currency; } set { _currency = value; } }

        public string Exponent { get { return _exponent; } set { _exponent = value; } }

        public string OpDescr { get { return _opDescr; } set { _opDescr = value; } }

        public string Options { get { return _options; } set { _options = value; } }
    }
}
