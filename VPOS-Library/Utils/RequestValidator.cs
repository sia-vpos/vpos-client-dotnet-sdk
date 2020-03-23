using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using VPOS_Library.Request;
using VPOS_Library.Utils.Exception;

namespace VPOS_Library.Utils
{
    public static class RequestValidator
    {
        public static void ValidateRefundRequest(RefundRequest request)
        {
            List<string> fields = new List<string>();

            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            else if (request.TransactionID == null || request.TransactionID.Length != PARAMETERS.TRANSACTIONID.LEN)
            {
                fields.Add(PARAMETERS.TRANSACTIONID.NAME);
            }
            else if (request.OrderId == null || !Regex.IsMatch(request.OrderId, PARAMETERS.ORDERID.PATTERN))
            {
                fields.Add(PARAMETERS.ORDERID.NAME);
            }
            else if (request.Amount == null || !Regex.IsMatch(request.Amount, PARAMETERS.AMOUNT.PATTERN))
            {
                fields.Add(PARAMETERS.AMOUNT.NAME);
            }
            else if (request.Currency == null || !Regex.IsMatch(request.Currency, PARAMETERS.CURRENCY.PATTERN))
            {
                fields.Add(PARAMETERS.CURRENCY.NAME);
            }

            if (fields.Count > 0)
            {
                string message = "";
                foreach (string field in fields)
                    message = message + " " + field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }
        }

        public static void ValidateOrderStatusRequest(OrderStatusRequest request)
        {
            List<string> fields = new List<string>();

            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            if (request.OrderId == null || !Regex.IsMatch(request.OrderId, PARAMETERS.ORDERID.PATTERN))
            {
                fields.Add(PARAMETERS.ORDERID.NAME);
            }
            if (request.ProductRef != null && !Regex.IsMatch(request.ProductRef, PARAMETERS.PRODUCTREF.PATTERN))
            {
                fields.Add(PARAMETERS.PRODUCTREF.NAME);
            }
            if (request.Options != null && !Regex.IsMatch(request.Options, PARAMETERS.OPTIONS.PATTERN))
            {
                fields.Add(PARAMETERS.OPTIONS.NAME);
            }

            if (fields.Count > 0) { 
                string message = "";
                foreach (string field in fields)
                    message = message + " "+ field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }
        }

        public static void ValidateCaptureRequest(CaptureRequest request)
        {
            List<string> fields = new List<string>();

            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            if (request.OrderId == null || !Regex.IsMatch(request.OrderId, PARAMETERS.ORDERID.PATTERN))
            {
                fields.Add(PARAMETERS.ORDERID.NAME);
            }
            if (request.Amount == null || !Regex.IsMatch(request.Amount, PARAMETERS.AMOUNT.PATTERN))
            {
                fields.Add(PARAMETERS.AMOUNT.NAME);
            }
            if (request.Currency == null || !Regex.IsMatch(request.Currency, PARAMETERS.CURRENCY.PATTERN))
            {
                fields.Add(PARAMETERS.CURRENCY.NAME);
            }
            if (request.Exponent == null && request.Currency != PARAMETERS.CURRENCY.EURO)
            {
                fields.Add(PARAMETERS.EXPONENT.NAME);
            }
            if (request.TransactionID == null || request.TransactionID.Length != PARAMETERS.TRANSACTIONID.LEN)
            {
                fields.Add(PARAMETERS.TRANSACTIONID.NAME);
            }

            if (request.Options != null && !Regex.IsMatch(request.Options, PARAMETERS.OPTIONS.PATTERN))
            {
                fields.Add(PARAMETERS.OPTIONS.NAME);
            }

            if (fields.Count > 0)
            {
                string message = "";
                foreach (string field in fields)
                    message = message + " " + field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }
        }

        public static void ValidateThreeDSAuthorize0Request(ThreeDSAuthorization0Request request)
        {
            List<string> fields = new List<string>();

            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            if (request.OrderId == null || !Regex.IsMatch(request.OrderId, PARAMETERS.ORDERID.PATTERN))
            {
                fields.Add(PARAMETERS.ORDERID.NAME);
            }
            if (request.Pan == null || !Regex.IsMatch(request.Pan, PARAMETERS.PAN.PATTERNGENERIC))
            {
                fields.Add(PARAMETERS.PAN.NAME);
            }
            if (request.CVV2 != null && !Regex.IsMatch(request.CVV2, PARAMETERS.CVV2.PATTERN))
            {
                fields.Add(PARAMETERS.CVV2.NAME);
            }
            if (request.ExpDate == null || !Regex.IsMatch(request.ExpDate, PARAMETERS.EXPDATE.PATTERN))
            {
                fields.Add(PARAMETERS.EXPDATE.NAME);
            }
            if (request.Amount == null || !Regex.IsMatch(request.Amount, PARAMETERS.AMOUNT.PATTERN))
            {
                fields.Add(PARAMETERS.AMOUNT.NAME);
            }
            if (request.Currency == null || !Regex.IsMatch(request.Currency, PARAMETERS.CURRENCY.PATTERN))
            {
                fields.Add(PARAMETERS.CURRENCY.NAME);
            }
            if (request.Exponent == null && request.Currency != PARAMETERS.CURRENCY.EURO)
            {
                fields.Add(PARAMETERS.EXPONENT.NAME);
            }
            if (request.AccountingMode == null || !Regex.IsMatch(request.AccountingMode, PARAMETERS.ACCOUNTINGMODE.PATTERN))
            {
                fields.Add(PARAMETERS.ACCOUNTINGMODE.NAME);
            }
            if (request.Network == null || !Regex.IsMatch(request.Network, PARAMETERS.NETWORK.PATTERN))
            {
                fields.Add(PARAMETERS.NETWORK.NAME);
            }
            if (request.EmailCh != null && !Regex.IsMatch(request.EmailCh, PARAMETERS.EMAIL.PATTERN))
            {
                fields.Add(PARAMETERS.EMAIL.NAMECH);
            }
            if (request.UserId != null && !Regex.IsMatch(request.UserId, PARAMETERS.USERID.PATTERN))
            {
                fields.Add(PARAMETERS.USERID.NAME);
            }
            if (request.Acquirer != null && !Regex.IsMatch(request.Acquirer, PARAMETERS.ACQUIRER.PATTERN))
            {
                fields.Add(PARAMETERS.ACQUIRER.NAME);
            }
            if (request.IpAddress != null && !Regex.IsMatch(request.IpAddress, PARAMETERS.IPADDRESS.PATTERN))
            {
                fields.Add(PARAMETERS.IPADDRESS.NAME);
            }
            if (request.UsrAuthFlag != null && !Regex.IsMatch(request.UsrAuthFlag, PARAMETERS.USRAUTHFLAG.PATTERN))
            {
                fields.Add(PARAMETERS.USRAUTHFLAG.NAME);
            }
            if (request.OpDescr != null && !Regex.IsMatch(request.OpDescr, PARAMETERS.OPDESCR.PATTERN))
            {
                fields.Add(PARAMETERS.OPDESCR.NAME);
            }
            if (request.AntiFraud != null && !Regex.IsMatch(request.AntiFraud, PARAMETERS.ANTIFRAUD.PATTERN))
            {
                fields.Add(PARAMETERS.ANTIFRAUD.NAME);
            }
            if (request.ProductRef != null && !Regex.IsMatch(request.ProductRef, PARAMETERS.PRODUCTREF.PATTERN))
            {
                fields.Add(PARAMETERS.PRODUCTREF.NAME);
            }
            if (request.Name != null && !Regex.IsMatch(request.Name, PARAMETERS.NAME_.PATTERN))
            {
                fields.Add(PARAMETERS.NAME_.NAME);
            }
            if (request.Surname != null && !Regex.IsMatch(request.AntiFraud, PARAMETERS.SURNAME.PATTERN))
            {
                fields.Add(PARAMETERS.SURNAME.NAME);
            }
            if (request.TaxId != null && !Regex.IsMatch(request.TaxId, PARAMETERS.TAXID.PATTERN))
            {
                fields.Add(PARAMETERS.TAXID.NAME);
            }
            if (request.CreatePanAlias != null && !Regex.IsMatch(request.CreatePanAlias, PARAMETERS.CREATEPANALIAS.PATTERN))
            {
                fields.Add(PARAMETERS.CREATEPANALIAS.NAME);
            }
            if (request.ThreeDSData == null )
            {
                fields.Add(PARAMETERS.THREEDSDATA.NAME);
            }
            if (request.NotifyUrl == null)
            {
                fields.Add(PARAMETERS.NOTIFURL.NAME);
            }
            if (fields.Count > 0)
            {
                string message = "";
                foreach (string field in fields)
                    message = message + " " + field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }
        }

        public static void ValidateThreeDSAuthorize1Request(ThreeDSAuthorization1Request request) 
        {
            List<string> fields = new List<string>();

            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            if (request.ThreeDSMtdComplInd == null || !Regex.IsMatch(request.ThreeDSMtdComplInd, PARAMETERS.THREEDSMTDCOMPLIND.PATTERN))
            {
                fields.Add(PARAMETERS.THREEDSMTDCOMPLIND.NAME);
            }
            if (request.ThreeDSTransId == null )
            {
                fields.Add(PARAMETERS.THREEDSTRANSID.NAME);
            }
            if (fields.Count > 0)
            {
                string message = "";
                foreach (string field in fields)
                    message = message + " " + field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }

        }
        
        public static void ValidateThreeDSAuthorize2Request(ThreeDSAuthorization2Request request)
        {
            List<string> fields = new List<string>();

            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            if (request.ThreeDSTransId == null)
            {
                fields.Add(PARAMETERS.THREEDSTRANSID.NAME);
            }
            if (fields.Count > 0)
            {
                string message = "";
                foreach (string field in fields)
                    message = message + " " + field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }

        }

        public static void ValidateAuthorizeRequest(AuthorizeRequest request) 
        {
            List<string> fields = new List<string>();
            if (request.OperatorID == null || !Regex.IsMatch(request.OperatorID, PARAMETERS.OPERATORID.PATTERN))
            {
                fields.Add(PARAMETERS.OPERATORID.NAME);
            }
            if (request.OrderId == null || !Regex.IsMatch(request.OrderId, PARAMETERS.ORDERID.PATTERN))
            {
                fields.Add(PARAMETERS.ORDERID.NAME);
            }
            if (request.Pan == null || !Regex.IsMatch(request.Pan, PARAMETERS.PAN.PATTERNGENERIC))
            {
                fields.Add(PARAMETERS.PAN.NAME);
            }
            if (request.CVV2 != null && !Regex.IsMatch(request.CVV2, PARAMETERS.CVV2.PATTERN))
            {
                fields.Add(PARAMETERS.CVV2.NAME);
            }
            if (request.ExpDate == null || !Regex.IsMatch(request.ExpDate, PARAMETERS.EXPDATE.PATTERN))
            {
                fields.Add(PARAMETERS.EXPDATE.NAME);
            }
            if (request.Amount == null || !Regex.IsMatch(request.Amount, PARAMETERS.AMOUNT.PATTERN))
            {
                fields.Add(PARAMETERS.AMOUNT.NAME);
            }
            if (request.Currency == null || !Regex.IsMatch(request.Currency, PARAMETERS.CURRENCY.PATTERN))
            {
                fields.Add(PARAMETERS.CURRENCY.NAME);
            }
            if (request.Exponent == null && request.Currency != PARAMETERS.CURRENCY.EURO)
            {
                fields.Add(PARAMETERS.EXPONENT.NAME);
            }
            if (request.AccountingMode == null || !Regex.IsMatch(request.AccountingMode, PARAMETERS.ACCOUNTINGMODE.PATTERN))
            {
                fields.Add(PARAMETERS.ACCOUNTINGMODE.NAME);
            }
            if (request.Network == null || !Regex.IsMatch(request.Network, PARAMETERS.NETWORK.PATTERN))
            {
                fields.Add(PARAMETERS.NETWORK.NAME);
            }
            if (request.EmailCh != null && !Regex.IsMatch(request.EmailCh, PARAMETERS.EMAIL.PATTERN))
            {
                fields.Add(PARAMETERS.EMAIL.NAMECH);
            }
            if (request.UserId != null && !Regex.IsMatch(request.UserId, PARAMETERS.USERID.PATTERN))
            {
                fields.Add(PARAMETERS.USERID.NAME);
            }
            if (request.Acquirer != null && !Regex.IsMatch(request.Acquirer, PARAMETERS.ACQUIRER.PATTERN))
            {
                fields.Add(PARAMETERS.ACQUIRER.NAME);
            }
            if (request.IpAddress != null && !Regex.IsMatch(request.IpAddress, PARAMETERS.IPADDRESS.PATTERN))
            {
                fields.Add(PARAMETERS.IPADDRESS.NAME);
            }
            if (request.UsrAuthFlag != null && !Regex.IsMatch(request.UsrAuthFlag, PARAMETERS.USRAUTHFLAG.PATTERN))
            {
                fields.Add(PARAMETERS.USRAUTHFLAG.NAME);
            }
            if (request.OpDescr != null && !Regex.IsMatch(request.OpDescr, PARAMETERS.OPDESCR.PATTERN))
            {
                fields.Add(PARAMETERS.OPDESCR.NAME);
            }
            if (request.AntiFraud != null && !Regex.IsMatch(request.AntiFraud, PARAMETERS.ANTIFRAUD.PATTERN))
            {
                fields.Add(PARAMETERS.ANTIFRAUD.NAME);
            }
            if (request.ProductRef != null && !Regex.IsMatch(request.ProductRef, PARAMETERS.PRODUCTREF.PATTERN))
            {
                fields.Add(PARAMETERS.PRODUCTREF.NAME);
            }
            if (request.Name != null && !Regex.IsMatch(request.Name, PARAMETERS.NAME_.PATTERN))
            {
                fields.Add(PARAMETERS.NAME_.NAME);
            }
            if (request.Surname != null && !Regex.IsMatch(request.AntiFraud, PARAMETERS.SURNAME.PATTERN))
            {
                fields.Add(PARAMETERS.SURNAME.NAME);
            }
            if (request.TaxId != null && !Regex.IsMatch(request.TaxId, PARAMETERS.TAXID.PATTERN))
            {
                fields.Add(PARAMETERS.TAXID.NAME);
            }
            if (request.CreatePanAlias != null && !Regex.IsMatch(request.CreatePanAlias, PARAMETERS.CREATEPANALIAS.PATTERN))
            {
                fields.Add(PARAMETERS.CREATEPANALIAS.NAME);
            }
            

            if (fields.Count > 0)
            {
                string message = "";
                foreach (string field in fields)
                    message = message + " " + field;
                throw new VPOSClientException("Invalid Request! The following field/s are not valid or missing:" + message);
            }
        }
    }
}
