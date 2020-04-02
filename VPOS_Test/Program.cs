using System;
using System.Xml.Serialization;
using VPOS_Library.Client;
using VPOS_Library.Models;
using VPOS_Library.Request;
using VPOS_Library.Utils;
using VPOS_Library.XML;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Test
{
    class Program
    {
        private const string SHOP_ID = "129289999900002";
        private const string PAN_ALIAS = "0000409500729966732";

        private const string MAC_KEY_VPOS =
            "au-PA-B2AAHsQSG-UuaVNcHFpBk3GJBNWqR3--Tyf-Fa-wav--ySqz9f24-yvP-RvbMQx-VYz9jVDNe-uMwTSt3-tvPukbJTTt-U";

        private const string API_RESULT_KEY =
            "hSAc7sg-z-vZ-296FuwwUaqHmzQ-eQ-E--2pXV-mEGh6YQtBdDK-NH9KeCyQrtBtmwFv-m6kEUtn27-6ATfkB-x2Dy3F4G-9t4sp";

        private const string URL_REDIRECT = "https://atpostest.ssb.it/atpos/pagamenti/main";
        private const string URL_DONE = "http://localhost:8080/payment-gateway/vpos/tokenize";
        private const string URL_BACK = "http://localhost:8080/payment-gateway/vpos/tokenize";

        private const string URLMS =
            "https://te.t-frutta.eu/TImooneyWS/app_api/v10/payment/cardData?consumerId=3b350c34-d923-4552-91bf-67bc4f99da92";

        private const string URL_WEB_API = "https://atpostest.ssb.it/atpos/apibo/apiBOXML.app";
        private const string OPERATOR_ID = "JohnDoeee";

        private const string PARES =
            "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";

        private const string PROXYNAME = "proxy-dr.reply.it";
        private const int PROXYPORT = 8080;

        static void Main(string[] args)
        {

            //TestAccounting();
            //TestAuth3ds();
            //TestOrderStatus();
            //TestVerify();
            //TestRefund();
            //TestAuthorize();
            //TestThreeDSAuthorize0();
            //TestThreeDSAuthorize1();
            //TestGetHtmlDocument();
            TestGetHtmlDocumentTOKEN();
        }

        static void TestRestClient()
        {
            var restClient = new RestClient();
            restClient.SetProxy("http://proxy-dr.reply.it", 8080, null, null);
            var response = restClient.CallApi("https://atpostest.ssb.it/atpos/apibo/apiBOXML.app", "dsf");
            Console.WriteLine(response);
        }

        static void TestTimeFormat()
        {
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
        }

        static void TestXMLSerializer()
        {
            var request = new BPWXmlRequest<AuthorizationRequest>(new AuthorizationRequest());
            var serializer = new XmlSerializer(typeof(BPWXmlRequest<AuthorizationRequest>));
            request.SetHeaderInfo("shopId", "operatorId");
            Console.WriteLine(XmlTool.Serialize(request));
        }

        static void TestRefund()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);

            var requestData = new RefundRequest();
            requestData.Amount = "10";
            requestData.Currency = "978";
            requestData.TransactionID = "8032112928AT2415xxp7isdz4";
            requestData.OrderId = "713739306616251603317204";
            requestData.OperatorID = OPERATOR_ID;
            var response = vposClient.Refund(requestData);
            Console.WriteLine(response.ToString());
        }

        static void TestAccounting()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var requestData = new CaptureRequest();
            requestData.Amount = "10";
            requestData.Currency = "978";
            requestData.TransactionID = "8032112928AT2415xxp7isdz4";
            requestData.OrderId = "713739306616251603317204";
            requestData.OperatorID = OPERATOR_ID;
            var response = vposClient.Capture(requestData);
            Console.WriteLine(response.ToString());
        }

        static void TestOrderStatus()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var requestData = new OrderStatusRequest(SHOP_ID,OPERATOR_ID, "AUTH123456769123246");
            
            var response = vposClient.GetOrderStatus(requestData);
            Console.WriteLine(response);
        }

        static void TestAuthorize() {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var requestData = new AuthorizeRequest("12345676912", "OPERATOR", "4598250000000027", "2112", "6000", "978", "I", "93");
            requestData.CVV2 = "111";
            requestData.EmailCh = "asd@gmail.it";
            var response = vposClient.Authorize(requestData);
            Console.WriteLine(response);
        }

        static void TestGetHtmlDocument()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var paymentInfo = new PaymentInfo();
            paymentInfo.Amount = "1000";
            paymentInfo.Currency = "978";
            paymentInfo.OrderId = new Random().Next(999999999).ToString();
            paymentInfo.ShopId = SHOP_ID;
            paymentInfo.UrlBack = URL_BACK;
            paymentInfo.UrlDone = URL_DONE;
            paymentInfo.UrlMs = URLMS;
            paymentInfo.AccountingMode = "D";
            paymentInfo.AuthorMode = "I";
            //paymentInfo.AddOption('M');
            paymentInfo.Data3DS = build3DSData();
            
            Console.WriteLine(vposClient.BuildHtmlPaymentFragment(paymentInfo));
        }
        static void TestGetHtmlDocumentTOKEN()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var paymentInfo = new PaymentInfo();
            paymentInfo.Amount = "1000";
            paymentInfo.Currency = "978";
            paymentInfo.OrderId = new Random().Next(999999999).ToString();
            paymentInfo.ShopId = SHOP_ID;
            paymentInfo.UrlBack = URL_BACK;
            paymentInfo.UrlDone = URL_DONE;
            paymentInfo.UrlMs = URLMS;
            paymentInfo.AccountingMode = "D";
            paymentInfo.AuthorMode = "I";
            //paymentInfo.AddOption('M');
            paymentInfo.Data3DS = build3DSData();
            paymentInfo.Token = "0000500550493297466";
            paymentInfo.ExpDate = "2112";
            paymentInfo.TRecurr = "U";
            paymentInfo.CRecurr = "899107067200401";
            paymentInfo.NameCH = "Mario";
            paymentInfo.SurnameCH = "Rossi";
            paymentInfo.Network = "98";
            paymentInfo.Email = "test@tes.it";
            paymentInfo.Exponent = "2";
            paymentInfo.ShopEmail = "test@tes.it";

            Console.WriteLine(vposClient.BuildHtmlPaymentFragment(paymentInfo));
        }

        static void TestThreeDSAuthorize0() {
            var vposClient = new VPOSClient(URL_WEB_API,
               API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var test = new ThreeDSAuthorization0Request();
            test.Amount="6600";
            test.AccountingMode="D";
            test.Pan="4118830900940017";
            test.ExpDate="2112";
            test.CVV2="111";
            test.Currency="978";

            test.Network="01";
            test.EmailCh="asdas@fgd.id";
            Random rand = new Random();

            test.OrderId = "12345676912345649" + rand.Next(1000);
            test.OperatorID = "JohnDoee";
            test.Exponent = "2";
            //test.Name="Mario";
            //test.Surname="Rossi";
            test.NameCh="Mario";
            test.NotifyUrl="https://atpostest.ssb.it/atpos/apibo/en/3ds-notification.html";
            test.ThreeDSMtdNotifyUrl="https://atpostest.ssb.it/atpos/apibo/en/3ds-notification.html";           
            test.ThreeDSData = build3DSData3DS2();
            test.MerchantKey = API_RESULT_KEY;
            var response = vposClient.ThreeDSAuthorize0(test);
            Console.WriteLine(response);

        }

        static void TestThreeDSAuthorize1() {
            var vposClient = new VPOSClient(URL_WEB_API,
              API_RESULT_KEY, MAC_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var test = new ThreeDSAuthorization1Request();
            test.OperatorID = "Operator id";
            test.ThreeDSMtdComplInd = "N";
            test.ThreeDSTransId = "b6e2d973-a32a-4e75-bbf7-32a426c358ac";
            var response = vposClient.ThreeDSAuthorize1(test);
            Console.WriteLine(response);
        }

        static Data3DSJSON build3DSData() {
            var data3DS = new Data3DSJSON();

            data3DS.addrMatch = "N";
            data3DS.chAccAgeInd = "04";
            data3DS.chAccChange = "20190211";
            data3DS.chAccChangeInd = "03";
            data3DS.chAccDate = "20190210";
            data3DS.chAccPwChange = "20190214";
            data3DS.chAccPwChangeInd = "04";
            data3DS.nbPurchaseAccount = "1000";
            data3DS.txnActivityDay = "100";
            data3DS.txnActivityYear = "100";
            data3DS.shipAddressUsage = "20181220";
            data3DS.shipAddressUsageInd = "03";
            data3DS.shipNameIndicator = "01";
            data3DS.billAddrCity = "billAddrCity";
            data3DS.billAddrCountry = "004";
            data3DS.billAddrLine1 = "billAddrLine1";
            data3DS.billAddrLine2 = "billAddrLine2";
            data3DS.billAddrLine3 = "billAddrLine3";
            data3DS.billAddrPostCode = "billAddrPostCode";
            data3DS.billAddrState = "MI";

            data3DS.homePhone = "39-321818198";
            data3DS.mobilePhone = "33-312";
            data3DS.shipAddrCity = "zio";
            data3DS.shipAddrCountry = "008";
            data3DS.shipAddrLine1 = "shipAddrLine1";
            data3DS.shipAddrLine2 = "shipAddrLine2";
            data3DS.shipAddrLine3 = "shipAddrLine3";
            data3DS.shipAddrPostCode = "shipAddrPostCode";
            data3DS.shipAddrState = "222";
            data3DS.workPhone = "39-0321818198";
            data3DS.deliveryEmailAddress = "a-b@example.com";
            data3DS.deliveryTimeframe = "02";
            data3DS.preOrderDate = "20181220";
            data3DS.preOrderPurchaseInd = "01";
            data3DS.shipNameIndicator = "01";
            return data3DS;
        }

        static Data3DSJSON build3DSData3DS2()
        {
            var data3DS = new Data3DSJSON();

            data3DS.browserAcceptHeader = "text / html,application / xhtml + xml,application / xml; ";
            data3DS.browserIP = "10.42.195.152";
            data3DS.browserJavaEnabled="true";
            data3DS.browserLanguage = "it-IT";
            data3DS.browserColorDepth = "16";
            data3DS.browserScreenHeight = "1024";
            data3DS.browserScreenWidth = "1920";
            data3DS.browserTZ = "-120";
            data3DS.browserUserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            data3DS.addrMatch = "N";
            data3DS.chAccAgeInd = "04";
            data3DS.chAccChange = "20190211";
            data3DS.chAccChangeInd = "03";
            data3DS.chAccDate = "20190210";
            data3DS.chAccPwChange = "20190214";
            data3DS.chAccPwChangeInd = "04";
            data3DS.nbPurchaseAccount = "1000";
            data3DS.txnActivityDay = "100";
            data3DS.txnActivityYear = "100";
            data3DS.shipAddressUsage = "20181220";
            data3DS.shipAddressUsageInd = "03";
            data3DS.shipNameIndicator = "01";
            data3DS.billAddrCity = "billAddrCity";
            data3DS.billAddrCountry = "004";
            data3DS.billAddrLine1 = "billAddrLine1";
            data3DS.billAddrLine2 = "billAddrLine2";
            data3DS.billAddrLine3 = "billAddrLine3";
            data3DS.billAddrPostCode = "billAddrPostCode";
            data3DS.billAddrState = "MI";

            data3DS.homePhone = "39-321818198";
            data3DS.mobilePhone = "33-312";
            data3DS.shipAddrCity = "zio";
            data3DS.shipAddrCountry = "008";
            data3DS.shipAddrLine1 = "shipAddrLine1";
            data3DS.shipAddrLine2 = "shipAddrLine2";
            data3DS.shipAddrLine3 = "shipAddrLine3";
            data3DS.shipAddrPostCode = "shipAddrPostCode";
            data3DS.shipAddrState = "222";
            data3DS.workPhone = "39-0321818198";
            data3DS.deliveryEmailAddress = "a-b@example.com";
            data3DS.deliveryTimeframe = "02";
            data3DS.preOrderDate = "20181220";
            data3DS.preOrderPurchaseInd = "01";
            data3DS.shipNameIndicator = "01";
            return data3DS;
        }
    }
}