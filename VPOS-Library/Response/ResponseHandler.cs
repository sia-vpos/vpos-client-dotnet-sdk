﻿using System.Collections.Generic;
using VPOS_Library.XML.Models;

namespace VPOS_Library.Utils.MAC
{
    public class ResponseHandler
    {
        public static List<string> ResponseMacList<T>(BPWXmlResponse<T> response)
        {
            return new List<string>()
            {
                response.Timestamp, response.Result
            };
        }

        public static List<string> AuthorizationMacList(Authorization authorization)
        {
            return new List<string>()
            {
                authorization.AuthorizationType,
                authorization.TransactionID,
                authorization.Network,
                authorization.OrderId,
                authorization.TransactionAmount,
                authorization.AuthorizedAmount,
                authorization.Currency,
                authorization.AccountedAmount,
                authorization.RefundedAmount,
                authorization.TransactionResult,
                authorization.Timestamp,
                authorization.AuthorizationNumber,
                authorization.AcquirerBIN,
                authorization.MerchantID,
                authorization.TransactionStatus,
                authorization.ResponseCodeISO,
                authorization.PanTail,
                authorization.PanExpiryDate,
                authorization.PaymentTypePP,
                authorization.RRN,
                authorization.CardType,
                authorization.CardholderInfo,
                authorization.InstallmentsNumber,
                authorization.TicklerMerchantCode,
                authorization.TicklerPlanCode,
                authorization.TicklerSubscriptionCode
            };
        }

        public static List<string> OperationMacList(Operation operation)
        {
            return new List<string>()
            {
                operation.TransactionID,
                operation.TimestampReq,
                operation.TimestampElab,
                operation.SrcType,
                operation.Amount,
                operation.Result,
                operation.Status,
                operation.OpDescr
            };
        }

        public static List<string> VbvRedirectMacList(VBVRedirect vbvRedirect)
        {
            return new List<string>()
            {
                vbvRedirect.PaReq,
                vbvRedirect.AcsURL
            };
        }

        public static List<string> VerifyMacList(Verify verify)
        {
            return new List<string>()
            {
                verify.Operation,
                verify.Result,
                verify.TransactionID
            };
        }

        public static List<string> PanAliasList(PanAliasData panAliasData)
        {
            return new List<string>
            {
                panAliasData.PanAlias,
                panAliasData.PanAliasRev,
                panAliasData.PanAliasExpDate,
                panAliasData.PanAliasTail
            };
        }

        public static List<string> ThreeDSChallengeMacList(ThreeDSChallenge threeDSChallenge)
        {
            return new List<string>
            {
                threeDSChallenge.ThreeDSTransId,
                threeDSChallenge.CReq,
                threeDSChallenge.ACSUrl
            };
        }

        public static List<string> ThreeDSMethodMacList(ThreeDSMethod threeDSMethod) 
        {
            return new List<string>
            {
                threeDSMethod.ThreeDSTransId,
                threeDSMethod.ThreeDSMethodData,
                threeDSMethod.ThreeDSMethodUrl
            };
        }
    }
}
