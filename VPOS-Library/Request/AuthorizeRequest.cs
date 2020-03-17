using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Request
{
    public class AuthorizeRequest
    {
        private string _orderId;
        private string _pan;
        private string _operatorId;
        private string _cvv2;
        private string _createPanAlias;
        private string _expDate;
        private string _amount;
        private string _currency;
        private string _exponent;
        private string _accountingMode;
        private string _network;
        private string _emailCh;
        private string _userId;
        private string _acquirer;
        private string _ipAddress;
        private string _usrAuthFlag;
        private string _opDescr;
        private string _antiFraud;
        private string _productRef;
        private string _name;
        private string _surname;
        private string _taxId;
        private string _options;

        public AuthorizeRequest() { }

        public AuthorizeRequest(string orderId, string operatorId, string pan, string expDate, string amount, string currency, string accountingMode, string network) {
            this._orderId= orderId;
            this._operatorId = operatorId;
            this._pan = pan;
            this._expDate = expDate;
            this._amount = amount;
            this._currency = currency;
            this._accountingMode = accountingMode;
            this._network = network;
        }

        public string OrderId { get { return _orderId; } set { _orderId = value; } }

        public string Pan { get { return _pan; } set { _pan = value; } }

        public string CVV2 { get { return _cvv2; } set { _cvv2 = value; } }

        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }

        public string CreatePanAlias { get { return _createPanAlias; } set { _createPanAlias = value; } }

        public string ExpDate { get { return _expDate; } set { _expDate = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }

        public string Currency { get { return _currency; } set { _currency = value; } }

        public string Exponent { get { return _exponent; } set { _exponent = value; } }
        public string AccountingMode { get { return _accountingMode; } set { _accountingMode = value; } }

        public string OpDescr { get { return _opDescr; } set { _opDescr = value; } }

        public string Network { get { return _network; } set { _network = value; } }

        public string EmailCh { get { return _emailCh; } set { _emailCh = value; } }

        public string UserId { get { return _userId; } set { _userId = value; } }

        public string Acquirer { get { return _acquirer; } set { _acquirer = value; } }
        public string IpAddress { get { return _ipAddress; } set { _ipAddress = value; } }

        public string UsrAuthFlag { get { return _usrAuthFlag; } set { _usrAuthFlag = value; } }

        public string AntiFraud { get { return _antiFraud; } set { _antiFraud = value; } }

        public string ProductRef { get { return _productRef; } set { _productRef = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public string Surname { get { return _surname; } set { _surname = value; } }

        public string TaxId { get { return _taxId; } set { _taxId = value; } }

        public string Options { get { return _options; } set { _options = value; } }

    }


}

