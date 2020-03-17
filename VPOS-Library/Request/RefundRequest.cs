using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Request
{
    public class RefundRequest
    {
        private string _operatorId;
        private string _transactionId;
        private string _orderId;
        private string _amount;
        private string _currency;
        private string _exponent;
        private string _opDescr;

        public RefundRequest() {}

        public RefundRequest(string operatorId, string transactionId, string orderId, string amount, string currency, string exponent, string opDescr)
        {
            this._operatorId = operatorId;
            this._transactionId = transactionId;
            this._orderId = orderId;
            this._amount = amount;
            this._currency = currency;
            this._exponent = exponent;
            this._opDescr = opDescr;
        }

        public string OrderId { get { return _orderId; } set { _orderId = value; } }

        public string TransactionID { get { return _transactionId; } set { _transactionId = value; } }

        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }

        public string Amount { get { return _amount; } set { _amount = value; } }

        public string Currency { get { return _currency; } set { _currency = value; } }

        public string Exponent { get { return _exponent; } set { _exponent = value; } }

        public string OpDescr { get { return _opDescr; } set { _opDescr = value; } }
    }
}
