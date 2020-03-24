using System.Collections.Generic;
using VPOS_Library.Models;
using VPOS_Library.Request;
using VPOS_Library.Response;
using VPOS_Library.XML.Models;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.Client
{
    public interface Client
    {

        string BuildHtmlPaymentFragment(PaymentInfo paymentInfo);

        bool VerifyMac(string urlDone);

        ThreeDSAuthorization0Response ThreeDSAuthorize0(ThreeDSAuthorization0Request request);

        ThreeDSAuthorization1Response ThreeDSAuthorize1(ThreeDSAuthorization1Request request);

        ThreeDSAuthorization2Response ThreeDSAuthorize2(ThreeDSAuthorization2Request request);

        CaptureResponse Capture(CaptureRequest request);

        RefundResponse Refund(RefundRequest request);

        OrderStatusResponse GetOrderStatus(OrderStatusRequest request);

    }
}