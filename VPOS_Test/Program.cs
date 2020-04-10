using System;
using System.Xml.Serialization;
using VPOS_Library.Client;
using VPOS_Library.Models;
using VPOS_Library.Request;


namespace VPOS_Test
{
    class Program
    {
        private const string SHOP_ID = "129289999900002";
        private const string PAN_ALIAS = "0000409500729966732";

        private const string START_KEY_VPOS =
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
        private const string amount = "100";
        private const string currency = "978";
        private const string accountingMode = "D";
        private const string authorMode = "I";

        static void Main(string[] args)
        {
            VPOSConfig config = new VPOSConfig();
            config.ApiKey = API_RESULT_KEY;
            config.ApiUrl = URL_WEB_API;
            config.RedirectKey = START_KEY_VPOS;
            config.RedirectUrl = URL_REDIRECT;
            //config.Timeout = 15;
            config.ShopID = SHOP_ID;
            var vposClient = new VPOSClient(config);
            var response = vposClient.ThreeDSAuthorize1(BuildThreeDSAuthorize1());
            Console.WriteLine(response);
            //TestAccounting();
            //TestAuth3ds();
            //TestOrderStatus();
            //TestVerify();
            //TestRefund();
            //TestAuthorize();
            //TestThreeDSAuthorize0();
            //TestThreeDSAuthorize1();
            //TestThreeDSAuthorize2();
            //TestGetHtmlDocument();
            //TestGetHtmlDocumentTOKEN();
            //TestVerifyMac();
        }


        static void TestTimeFormat()
        {
            Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
        }

        
        static void TestVerifyMac()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);

            var response = vposClient.VerifyMac("http://localhost:8080/payment-gateway/vpos/tokenize?ORDERID=1585919322092143568728681910679428531949566&SHOPID=129289999900002&AUTHNUMBER=413889&AMOUNT=10&CURRENCY=978&TRANSACTIONID=8032112928SL211ntcm0icwf4&ACCOUNTINGMODE=D&AUTHORMODE=I&RESULT=00&TRANSACTIONTYPE=TT07&TRECURR=U&CRECURR=899107067200401&NETWORK=02&MAC=105e962d0727ef0d30a1ce21d14e6813449daa6375c433d2cc2fa631bc3bf680");
            Console.WriteLine(response.ToString());
        }

        static void TestRefund()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);

            var requestData = new RefundRequest();
            requestData.Amount = "10";
            requestData.Currency = "978";
            requestData.TransactionID = "8032112928SL1ljjcuqqyek44";
            requestData.OrderId = "516774135";
            requestData.OperatorID = OPERATOR_ID;
            var response = vposClient.Refund(requestData);
            Console.WriteLine(response.ToString());
        }

        static void TestAccounting()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var requestData = new CaptureRequest();
            requestData.Amount = "10";
            requestData.Currency = "978";
            requestData.TransactionID = "8032112928SL1ljjcuqqyek44";
            requestData.OrderId = "516774135";
            requestData.OperatorID = OPERATOR_ID;
            var response = vposClient.Capture(requestData);
            Console.WriteLine(response.ToString());
        }

        static void TestOrderStatus()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var requestData = new OrderStatusRequest(SHOP_ID,OPERATOR_ID, "516774135");
            
            var response = vposClient.GetOrderStatus(requestData);
            Console.WriteLine(response);
        }
        static void TestAuthorize() {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            Random rand = new Random();
            var requestData = new AuthorizeRequest("12345676912"+ rand.Next(1000), "OPERATOR", "4598250000000027", "2112", "6000", "978", "I", "93");
            requestData.CVV2 = "111";
            requestData.EmailCh = "asd@gmail.it";
            var response = vposClient.Authorize(requestData);
            Console.WriteLine(response);
        }
        static PaymentInfo BuildPaymentInfoRequest(string amount, string currency, string urlBack, string urlDone, string urlMs, string accountingMode, string authorMode)
        {
            
            var paymentInfo = new PaymentInfo();
            paymentInfo.Amount = amount;
            paymentInfo.Currency = currency;
            paymentInfo.OrderId = new Random().Next(999999999).ToString();
            
            paymentInfo.UrlBack = urlBack;
            paymentInfo.UrlDone = urlDone;
            paymentInfo.UrlMs = urlMs;
            paymentInfo.AccountingMode = accountingMode;
            paymentInfo.AuthorMode = authorMode;
            //paymentInfo.AddOption('M');
            paymentInfo.Data3DS = build3DSData();

            return paymentInfo;
        }
        static void TestGetHtmlDocumentTOKEN()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
                API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var paymentInfo = new PaymentInfo();
            paymentInfo.Amount = "1000";
            paymentInfo.Currency = "978";
            paymentInfo.OrderId = new Random().Next(999999999).ToString();
            
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

        static ThreeDSAuthorization0Request BuildThreeDSAuthorize0() {
            
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
            test.OperatorID = "OPERATOR";
            test.Exponent = "2";
            test.NameCh="Mario";
            test.NotifyUrl="https://atpostest.ssb.it/atpos/apibo/en/3ds-notification.html";
            test.ThreeDSMtdNotifyUrl="https://atpostest.ssb.it/atpos/apibo/en/3ds-notification.html";           
            test.ThreeDSData = build3DSData3DS2();
            return test;
        }

        static ThreeDSAuthorization1Request BuildThreeDSAuthorize1() {
            
            var test = new ThreeDSAuthorization1Request();
            test.OperatorID = "Operator id";
            test.ThreeDSMtdComplInd = "N";
            test.ThreeDSTransId = "aded56a0-177d-40e3-b7a1-2d95251279cf";
            return test;
        }

        static void TestThreeDSAuthorize2()
        {
            var vposClient = new VPOSClient(URL_WEB_API,
              API_RESULT_KEY, START_KEY_VPOS, SHOP_ID, URL_REDIRECT);
            var test = new ThreeDSAuthorization2Request();
            test.OperatorID = "Operator id";
            test.ThreeDSTransId = "aded56a0-177d-40e3-b7a1-2d95251279cf";
            var response = vposClient.ThreeDSAuthorize2(test);
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