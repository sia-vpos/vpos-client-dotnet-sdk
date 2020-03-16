using System.Collections.Generic;
using VPOS_Library.Models;
using VPOS_Library.XML.Models;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.Client
{
    public interface VposClient
    {
        void InjectHtmlTemplate(string base64, int delay);

        string GetHtmlPaymentDocument(PaymentInfo paymentInfo, string urlApos);

        string Tokenize(string shopId, string urlBack, string urlDone, string urlms, string urlApos);

        void VerifyUrl(Dictionary<string, string> values, string receivedMac);

        BPWXmlResponse<Data3DS> Start3DsAuth(BPWXmlRequest<AuthorizationRequest> request);

        BPWXmlResponse<Data3DS> Start3DsAuthStep2(BPWXmlRequest<AuthorizationRequest3DSStep2> request);

        BPWXmlResponse<DataManageOperation> ConfirmTransaction(BPWXmlRequest<AccountingRequest> request);

        BPWXmlResponse<DataManageOperation> RefundPayment(BPWXmlRequest<RefundRequest> request);

        BPWXmlResponse<DataVerify> VerifyRequest(BPWXmlRequest<VerifyRequest> request);

        BPWXmlResponse<DataOrderStatus> GetOrderStatus(BPWXmlRequest<OrderStatusRequest> request);

        void SetProxy(string proxyName, int proxyPort);
    }
}