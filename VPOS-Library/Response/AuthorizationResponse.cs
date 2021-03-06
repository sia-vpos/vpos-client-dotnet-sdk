﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Response
{
    public class AuthorizationResponse
    {
        public string Result { get; set; }
        public string PaymentType { get; set; }
        public string AuthorizationType { get; set; }
        public string TransactionId { get; set; }
        public string Network { get; set; }
        public string OrderId { get; set; }
        public string TransactionAmount { get; set; }
        public string AuthorizedAmount { get; set; }
        public string Currency { get; set; }
        public string Exponent { get; set; }
        public string AccountedAmount { get; set; }
        public string RefundedAmount { get; set; }
        public string TransactionResult { get; set; }
        public string Timestamp { get; set; }
        public string AuthorizationNumber { get; set; }
        public string AcquirerBin { get; set; }
        public string MerchantId { get; set; }
        public string TransactionStatus { get; set; }
        public string ResponseCodeIso { get; set; }
        public string PanTail { get; set; }
        public string PanExpiryDate { get; set; }
        public string PaymentTypePP { get; set; }
        public string RRN { get; set; }
        public string CardType { get; set; }
        public string CardholderInfo {get; set;}
        public string InstallmentsNumber {get; set;}
        public string TicklerMerchantCode {get; set;}
        public string TicklerPlanCode {get; set;}
        public string TicklerSubscriptionCode {get; set;}
    }
}
