using System;
using System.Collections.Generic;
using System.Text;
using VPOS_Library.XML.Models;

namespace VPOS_Library.Response
{
    class ResponseMapper
    {
        private ResponseMapper (){ }

        public static AuthorizeResponse MapAuthorize(BPWXmlResponse<DataAuthorize> response) {
            AuthorizeResponse authorizationResponse = new AuthorizeResponse();
            authorizationResponse.Result = response.Result;

            if (response.Data != null && response.Data.Authorization != null)
            {
                Authorization auth = response.Data.Authorization;
                authorizationResponse.PaymentType=auth.PaymentType;
                authorizationResponse.AuthorizationType=auth.AuthorizationType;
                authorizationResponse.TransactionId=auth.TransactionID;
                authorizationResponse.Network=auth.Network;
                authorizationResponse.OrderId=auth.OrderId;
                authorizationResponse.TransactionAmount=auth.TransactionAmount;
                authorizationResponse.AuthorizedAmount=auth.AuthorizedAmount;
                authorizationResponse.Currency=auth.Currency;
                authorizationResponse.Exponent=auth.Exponent;
                authorizationResponse.AccountedAmount=auth.AccountedAmount;
                authorizationResponse.RefundedAmount=auth.RefundedAmount;
                authorizationResponse.TransactionResult=auth.TransactionResult;
                authorizationResponse.Timestamp=auth.Timestamp;
                authorizationResponse.AuthorizationNumber=auth.AuthorizationNumber;
                authorizationResponse.AcquirerBin=auth.AcquirerBIN;
                authorizationResponse.MerchantId=auth.MerchantID;
                authorizationResponse.TransactionStatus=auth.TransactionStatus;
                authorizationResponse.ResponseCodeIso=auth.ResponseCodeISO;
                authorizationResponse.PanTail=auth.PanTail;
                authorizationResponse.PanExpiryDate=auth.PanExpiryDate;
                authorizationResponse.PaymentTypePP=auth.PaymentTypePP;
                authorizationResponse.RRN=auth.RRN;
                authorizationResponse.CardType=auth.CardType;
                authorizationResponse.CardholderInfo=auth.CardholderInfo;
                authorizationResponse.InstallmentsNumber=auth.InstallmentsNumber;
                authorizationResponse.TicklerMerchantCode=auth.TicklerMerchantCode;
                authorizationResponse.TicklerPlanCode=auth.TicklerPlanCode;
                authorizationResponse.TicklerSubscriptionCode=auth.TicklerSubscriptionCode;
                return authorizationResponse;
            }
            return authorizationResponse;

        }

        public static ThreeDSAuthorization0Response MapThreeDSAuthorization0(BPWXmlResponse<Data3DSResponse> response) {
            ThreeDSAuthorization0Response resp = new ThreeDSAuthorization0Response();
            resp.Result=response.Result;
            if (response == null || response.Data == null)
            {
                return resp;
            }
            if (response.Data.ThreeDSChallenge != null)
            {
                resp.Creq=response.Data.ThreeDSChallenge.CReq;
                resp.AcsUrl=response.Data.ThreeDSChallenge.ACSUrl;
                resp.ThreeDSTransId=response.Data.ThreeDSChallenge.ThreeDSTransId;

            }
            if (response.Data.ThreeDSMethod != null)
            {
                resp.ThreeDSTransId=response.Data.ThreeDSMethod.ThreeDSTransId;
                resp.ThreeDSMethodData=response.Data.ThreeDSMethod.ThreeDSMethodData;
                resp.ThreeDSMethodUrl=response.Data.ThreeDSMethod.ThreeDSMethodUrl;
            }
            if (response.Data.Authorization != null)
            {
                Authorization authorization = response.Data.Authorization;
                if (authorization != null)
                {
                    resp.PaymentType=authorization.PaymentType;
                    resp.AuthorizationType=authorization.AuthorizationType;
                    resp.TransactionId = authorization.TransactionID;
                    resp.Network = authorization.Network;
                    resp.OrderId = authorization.OrderId;
                    resp.TransactionAmount = authorization.TransactionAmount;
                    resp.AuthorizedAmount = authorization.AuthorizedAmount;
                    resp.Currency = authorization.Currency;
                    resp.AccountedAmount = authorization.AccountedAmount;
                    resp.RefundedAmount = authorization.RefundedAmount;
                    resp.TransactionResult = authorization.TransactionResult;
                    resp.Timestamp = authorization.Timestamp;
                    resp.AuthorizationNumber = authorization.AuthorizationNumber;
                    resp.TransactionStatus = authorization.TransactionStatus;
                    resp.ResponseCodeIso = authorization.ResponseCodeISO;
                    resp.PanTail = authorization.PanTail;
                    resp.PanExpiryDate = authorization.PanExpiryDate;
                }

            }
            if (response.Data.PanAliasData != null)
            {
                PanAliasData pan = response.Data.PanAliasData;
                resp.PanAlias = pan.PanAlias;
                resp.PanAliasExpDate = pan.PanAliasExpDate;
                resp.PanAliasRev = pan.PanAliasRev;
                resp.PanAliasTail = pan.PanAliasTail;
            }
            return resp;
        }

        public static ThreeDSAuthorization1Response MapThreeDSAuthorization1(BPWXmlResponse<Data3DSResponse> response)
        {
            ThreeDSAuthorization1Response resp = new ThreeDSAuthorization1Response();
            resp.Result = response.Result;
            if (response == null || response.Data == null)
            {
                return resp;
            }
            if (response.Data.ThreeDSChallenge != null)
            {
                resp.Creq = response.Data.ThreeDSChallenge.CReq;
                resp.AcsUrl = response.Data.ThreeDSChallenge.ACSUrl;
                resp.ThreeDSTransId = response.Data.ThreeDSChallenge.ThreeDSTransId;

            }            
            if (response.Data.Authorization != null)
            {
                Authorization authorization = response.Data.Authorization;
                if (authorization != null)
                {
                    resp.PaymentType = authorization.PaymentType;
                    resp.AuthorizationType = authorization.AuthorizationType;
                    resp.TransactionId = authorization.TransactionID;
                    resp.Network = authorization.Network;
                    resp.OrderId = authorization.OrderId;
                    resp.TransactionAmount = authorization.TransactionAmount;
                    resp.AuthorizedAmount = authorization.AuthorizedAmount;
                    resp.Currency = authorization.Currency;
                    resp.AccountedAmount = authorization.AccountedAmount;
                    resp.RefundedAmount = authorization.RefundedAmount;
                    resp.TransactionResult = authorization.TransactionResult;
                    resp.Timestamp = authorization.Timestamp;
                    resp.AuthorizationNumber = authorization.AuthorizationNumber;
                    resp.TransactionStatus = authorization.TransactionStatus;
                    resp.ResponseCodeIso = authorization.ResponseCodeISO;
                    resp.PanTail = authorization.PanTail;
                    resp.PanExpiryDate = authorization.PanExpiryDate;
                }

            }
            if (response.Data.PanAliasData != null)
            {
                PanAliasData pan = response.Data.PanAliasData;
                resp.PanAlias = pan.PanAlias;
                resp.PanAliasExpDate = pan.PanAliasExpDate;
                resp.PanAliasRev = pan.PanAliasRev;
                resp.PanAliasTail = pan.PanAliasTail;
            }
            return resp;
        }

        public static ThreeDSAuthorization2Response MapThreeDSAuthorization2(BPWXmlResponse<Data3DSResponse> response)
        {
            ThreeDSAuthorization2Response resp = new ThreeDSAuthorization2Response();
            resp.Result = response.Result;
            if (response == null || response.Data == null)
            {
                return resp;
            }
            if (response.Data.Authorization != null)
            {
                Authorization authorization = response.Data.Authorization;
                if (authorization != null)
                {
                    resp.PaymentType = authorization.PaymentType;
                    resp.AuthorizationType = authorization.AuthorizationType;
                    resp.TransactionId = authorization.TransactionID;
                    resp.Network = authorization.Network;
                    resp.OrderId = authorization.OrderId;
                    resp.TransactionAmount = authorization.TransactionAmount;
                    resp.AuthorizedAmount = authorization.AuthorizedAmount;
                    resp.Currency = authorization.Currency;
                    resp.AccountedAmount = authorization.AccountedAmount;
                    resp.RefundedAmount = authorization.RefundedAmount;
                    resp.TransactionResult = authorization.TransactionResult;
                    resp.Timestamp = authorization.Timestamp;
                    resp.AuthorizationNumber = authorization.AuthorizationNumber;
                    resp.TransactionStatus = authorization.TransactionStatus;
                    resp.ResponseCodeIso = authorization.ResponseCodeISO;
                    resp.PanTail = authorization.PanTail;
                    resp.PanExpiryDate = authorization.PanExpiryDate;
                }

            }
            if (response.Data.PanAliasData != null)
            {
                PanAliasData pan = response.Data.PanAliasData;
                resp.PanAlias = pan.PanAlias;
                resp.PanAliasExpDate = pan.PanAliasExpDate;
                resp.PanAliasRev = pan.PanAliasRev;
                resp.PanAliasTail = pan.PanAliasTail;
            }
            return resp;
        }

        public static CaptureResponse MapCaptureResponse(BPWXmlResponse<DataManageOperation> response) 
        {
            CaptureResponse resp = new CaptureResponse();
            if (response != null && response.Data!= null && response.Data.Operation != null)
            {
                Operation operation = response.Data.Operation;
                resp.TransactionID = operation.TransactionID;
                resp.TimestampReq = operation.TimestampReq;
                resp.TimestampElab = operation.TimestampElab;
                resp.SrcType = operation.SrcType;
                resp.Amount = operation.Amount;
                resp.Result = operation.Result;
                resp.Status = operation.Status;
                resp.OpDesc = operation.OpDescr;

                if (response.Data.Operation.Authorization != null)
                {
                    var element = response.Data.Operation.Authorization;
                    AuthorizationResponse authElement = new AuthorizationResponse();

                    authElement.PaymentType = element.PaymentType;
                    authElement.AuthorizationType = element.AuthorizationType;
                    authElement.TransactionId = element.TransactionID;
                    authElement.Network = element.Network;
                    authElement.OrderId = element.OrderId;
                    authElement.TransactionAmount = element.TransactionAmount;
                    authElement.AuthorizedAmount = element.AuthorizedAmount;
                    authElement.RefundedAmount = element.RefundedAmount;
                    authElement.TransactionResult = element.TransactionResult;
                    authElement.Timestamp = element.Timestamp;
                    authElement.AuthorizationNumber = element.AuthorizationNumber;
                    authElement.AcquirerBin = element.AcquirerBIN;
                    authElement.MerchantId = element.MerchantID;
                    authElement.TransactionStatus = element.TransactionStatus;
                    authElement.ResponseCodeIso = element.ResponseCodeISO;
                    authElement.PanTail = element.PanTail;
                    authElement.PanExpiryDate = element.PanExpiryDate;
                    authElement.PaymentTypePP = element.PaymentTypePP;
                    authElement.RRN = element.RRN;
                    authElement.CardType = element.CardType;
                    resp.Authorization = authElement;
                }

            }
            else
            {
                if (response != null)
                {
                    resp.Result=response.Result;
                    resp.TimestampReq=response.Timestamp;
                }
            }
            return resp;
        }

        public static RefundResponse MapRefundResponse(BPWXmlResponse<DataManageOperation> response)
        {
            RefundResponse resp = new RefundResponse();
            if (response != null && response.Data != null && response.Data.Operation != null)
            {
                Operation operation = response.Data.Operation;
                resp.TransactionID = operation.TransactionID;
                resp.TimestampReq = operation.TimestampReq;
                resp.TimestampElab = operation.TimestampElab;
                resp.SrcType = operation.SrcType;
                resp.Amount = operation.Amount;
                resp.Result = operation.Result;
                resp.Status = operation.Status;
                resp.OpDesc = operation.OpDescr;

                if (response.Data.Operation.Authorization != null) { 
                    var element = response.Data.Operation.Authorization;
                    AuthorizationResponse authElement = new AuthorizationResponse();

                    authElement.PaymentType = element.PaymentType;
                    authElement.AuthorizationType = element.AuthorizationType;
                    authElement.TransactionId = element.TransactionID;
                    authElement.Network = element.Network;
                    authElement.OrderId = element.OrderId;
                    authElement.TransactionAmount = element.TransactionAmount;
                    authElement.AuthorizedAmount = element.AuthorizedAmount;
                    authElement.RefundedAmount = element.RefundedAmount;
                    authElement.TransactionResult = element.TransactionResult;
                    authElement.Timestamp = element.Timestamp;
                    authElement.AuthorizationNumber = element.AuthorizationNumber;
                    authElement.AcquirerBin = element.AcquirerBIN;
                    authElement.MerchantId = element.MerchantID;
                    authElement.TransactionStatus = element.TransactionStatus;
                    authElement.ResponseCodeIso = element.ResponseCodeISO;
                    authElement.PanTail = element.PanTail;
                    authElement.PanExpiryDate = element.PanExpiryDate;
                    authElement.PaymentTypePP = element.PaymentTypePP;
                    authElement.RRN = element.RRN;
                    authElement.CardType = element.CardType;
                    resp.Authorization = authElement;
                }

            }
            else
            {
                if (response != null)
                {
                    resp.Result = response.Result;
                    resp.TimestampReq = response.Timestamp;
                }
            }
            return resp;
        }

        public static OrderStatusResponse MapOrderStatusResponse(BPWXmlResponse<DataOrderStatus> response)
        {
            OrderStatusResponse resp = new OrderStatusResponse();
            if (response == null)
            {
                return resp;
            }
            else
            {
                resp.Result=response.Result;
                resp.Timestamp=response.Timestamp;

            }
            if (response.Data != null && response.Data.Authorizations != null)
            {
                List<Authorization> authorizationList = response.Data.Authorizations;
                List<AuthorizationResponse> authResp = new List<AuthorizationResponse>();
                foreach (Authorization element in authorizationList)
                {
                    AuthorizationResponse authElement = new AuthorizationResponse();

                    authElement.PaymentType=element.PaymentType;
                    authElement.AuthorizationType=element.AuthorizationType;
                    authElement.TransactionId=element.TransactionID;
                    authElement.Network=element.Network;
                    authElement.OrderId=element.OrderId;
                    authElement.TransactionAmount=element.TransactionAmount;
                    authElement.AuthorizedAmount = element.AuthorizedAmount;
                    authElement.RefundedAmount = element.RefundedAmount;
                    authElement.TransactionResult = element.TransactionResult;
                    authElement.Timestamp = element.Timestamp;
                    authElement.AuthorizationNumber = element.AuthorizationNumber;
                    authElement.AcquirerBin = element.AcquirerBIN;
                    authElement.MerchantId = element.MerchantID;
                    authElement.TransactionStatus = element.TransactionStatus;
                    authElement.ResponseCodeIso = element.ResponseCodeISO;
                    authElement.PanTail = element.PanTail;
                    authElement.PanExpiryDate = element.PanExpiryDate;
                    authElement.PaymentTypePP = element.PaymentTypePP;
                    authElement.RRN = element.RRN;
                    authElement.CardType = element.CardType;
                    authResp.Add(authElement);
                    //dtoElement.clearAllIndividualFields();
                }
                resp.Authorizations = authResp;
            }
            if (response.Data != null && response.Data.PanAliasData != null)
            {
                PanAliasData panData = response.Data.PanAliasData;
                resp.PanAlias=panData.PanAlias;
                resp.PanAliasExpDate=panData.PanAliasExpDate;
                resp.PanAliasRev=panData.PanAliasRev;
                resp.PanAliasTail=panData.PanAliasTail;
            }

            if (response.Data != null && response.Data.CardHolderData != null)
            {
                CardHolderData cardHolderData = response.Data.CardHolderData;
                resp.CardHolderName=cardHolderData.CardHolderName;
                resp.CardHolderEmail=cardHolderData.CardHolderEmail;
                resp.BillingAddressPostalcode=cardHolderData.BillingAddressPostalcode;
                resp.BillingAddressCity=cardHolderData.BillingAddressCity;
                resp.BillingAddressLine1=cardHolderData.BillingAddressLine1;
                resp.BillingAddressLine2=cardHolderData.BillingAddressLine2;
                resp.BillingAddressLine3=cardHolderData.BillingAddressLine3;
                resp.BillingAddressState=cardHolderData.BillingAddressState;
                resp.BillingAddressCountry=cardHolderData.BillingAddressCountry;
            }

            return resp;
        }
    }
}
