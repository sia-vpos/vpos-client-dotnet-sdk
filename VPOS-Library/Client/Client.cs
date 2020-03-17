using System.Collections.Generic;
using VPOS_Library.Models;
using VPOS_Library.Request;
using VPOS_Library.XML.Models;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.Client
{
    public interface Client
    {

        string BuildHtmlPaymentFragment(PaymentInfo paymentInfo);

        bool VerifyMac(string urlDone);

        BPWXmlResponse<Data3DSResponse> ThreeDSAuthorize0(ThreeDSAuthorization0Request request);

        BPWXmlResponse<Data3DSResponse> ThreeDSAuthorize1(ThreeDSAuthorization1Request request);

        BPWXmlResponse<Data3DSResponse> ThreeDSAuthorize2(ThreeDSAuthorization2Request request);

        BPWXmlResponse<DataManageOperation> Capture(CaptureRequest request);

        BPWXmlResponse<DataManageOperation> Refund(RefundRequest request);

        BPWXmlResponse<DataOrderStatus> GetOrderStatus(OrderStatusRequest request);

    }
}