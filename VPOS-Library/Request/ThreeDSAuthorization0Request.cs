using System;
using System.Collections.Generic;
using System.Text;
using VPOS_Library.Models;

namespace VPOS_Library.Request
{
    public class ThreeDSAuthorization0Request
    {
        private string _orderId;
        private string _operatorId;
        private string _pan;
        private string _cvv2;
        private string _expDate;
        private string _amount;
        private string _currency;
        private string _exponent;
        private string _accountingMode;
        private string _network;
        private string _emailCh;
        private string _nameCh;

        private string _userId;
        private string _acquirer;
        private string _ipAddress;
        private string _usrAuthFlag;
        private string _opDescr;
        private string _antifraud;
        private string _productRef;
        private string _name;
        private string _surname;
        private string _taxId;
        private string _createPanAlias;
        private Data3DSJSON _threeDSData;
        private string _notifyUrl;
        private string _cProf;
        private string _threeDSMtdNotifyUrl;
        private string _challengeWinSize;
        private string _merchantKey;
        private string _options;

        public string OrderId { get { return _orderId; } set { _orderId = value; } }

        public string Pan { get { return _pan; } set { _pan = value; } }

        public string CVV2 { get { return _cvv2; } set { _cvv2 = value; } }

        public string OperatorID { get { return _operatorId; } set { _operatorId = value; } }

        public string CreatePanAlias { get { return _createPanAlias; } set { _createPanAlias = value; } }

        public string ExpDate { get { return _expDate; } set { _expDate = value; } }

        public string AccountingMode { get { return _accountingMode; } set { _accountingMode = value; } }

        public string Amount { get { return _amount; } set { _amount = value; } }

        public string Currency { get { return _currency; } set { _currency = value; } }

        public string Exponent { get { return _exponent; } set { _exponent = value; } }

        public string Network { get { return _network; } set { _network = value; } }

        public string EmailCh { get { return _emailCh; } set { _emailCh = value; } }

        public string NameCh { get { return _nameCh; } set { _nameCh = value; } }

        public string UserId { get { return _userId; } set { _userId = value; } }

        public string Acquirer { get { return _acquirer; } set { _acquirer = value; } }

        public string IpAddress { get { return _ipAddress; } set { _ipAddress = value; } }

        public string UsrAuthFlag { get { return _usrAuthFlag; } set { _usrAuthFlag = value; } }

        public string ProductRef { get { return _productRef; } set { _productRef = value; } }

        public string OpDescr { get { return _opDescr; } set { _opDescr = value; } }

        public string AntiFraud { get { return _antifraud; } set { _antifraud = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public string Surname { get { return _surname; } set { _surname = value; } }

        public string TaxId { get { return _taxId; } set { _taxId = value; } }

        public string Options { get { return _options; } set { _options = value; } }

        public Data3DSJSON ThreeDSData { get { return _threeDSData; } set { _threeDSData = value; } }

        public string NotifyUrl { get { return _notifyUrl; } set { _notifyUrl = value; } }

        public string CProf { get { return _cProf; } set { _cProf = value; } }

        public string ThreeDSMtdNotifyUrl { get { return _threeDSMtdNotifyUrl; } set { _threeDSMtdNotifyUrl = value; } }

        public string ChallengeWinSize { get { return _challengeWinSize; } set { _challengeWinSize = value; } }

        public string MerchantKey { get { return _merchantKey; } set { _merchantKey = value; } }

    }
}
