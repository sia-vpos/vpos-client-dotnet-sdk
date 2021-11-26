using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Utils
{

    public static class PARAMETERS
    {

        public static string OPERATION = "OPERATION";
        public static string AUTHORIZATION3DSSTEP1 = "AUTHORIZATION3DSSTEP1";
        public static string AUTHORIZATION3DSSTEP2 = "AUTHORIZATION3DSSTEP2";
        public static string ONLINEAUTHORIZATION = "AUTHORIZATION";

        public static string AUTHORIZATION3DS2STEP0 = "THREEDSAUTHORIZATION0";
        public static string AUTHORIZATION3DS2STEP1 = "THREEDSAUTHORIZATION1";
        public static string AUTHORIZATION3DS2STEP2 = "THREEDSAUTHORIZATION2";

        public static string BOOKING = "BOOKING";
        public static string IBANAUTHORIZATION = "IBANAUTHORIZATION";
        public static string ACCOUNTING = "ACCOUNTING";
        public static string REFUND = "REFUND";
        public static string ORDERSTATUS = "ORDERSTATUS";
        public static string VERIFY = "VERIFY";
        public static string DEFERREDREQUEST = "DEFERREDREQUEST";
        public static string CONFIRM = "CONFIRM";
        public static string TIMESTAMP = "TIMESTAMP";
        public static string PARES = "PARES";



        public static class CREATEPANALIAS
        {
            public static string NAME = "CREATEPANALIAS";
            public static string PATTERN = "S";



        }

        public static class INPERSON
        {
            public static string NAME = "INPERSON";
            public static string PATTERN = "([S]|[N]){1}";


        }

        public static class SERVICE
        {
            public static string NAME = "SERVICE";
            public static string PATTERN = "[SV47]{4}";


        }


        public static class MERCHANTURL
        {
            public static string NAME = "MERCHANTURL";
            public static string PATTERN = "[A-Za-z0-9_\\-/:. ]";


        }

        public static class REQREFNUM
        {
            public static string NAME = "REQREFNUM";
            public static int LEN1 = 8;
            public static int LEN2 = 24;
            public static string PATTERN = "[20[0-9][0-9](0[1-9]|1[0-2])(0[1-9]|2[0-9]|3[0-1])]{" +
                LEN1 + "}" + "\\d{" + LEN2 + "}";


        }


        public static class USRAUTHFLAG
        {
            public static string NAME = " USRAUTHFLAG";
            public static string PATTERN = "[0-2]{1}";


        }

        //pattern da controllare per XID e CAVV
        public static class XID
        {
            public static string NAME = "XID";
            public static string PATTERN = "{40}";


        }

        public static class CAVV
        {
            public static string NAME = "CAVV";
            public static string PATTERN = "{40}";


        }

        public static class ECI
        {
            public static string NAME = "ECI";
            public static string PATTERN = "([01]|[02]|[05]|[07]){2}";


        }


        public static class CLOSEORDER
        {
            public static string NAME = "CLOSEORDER";


        }

        public static class AMOUNT
        {
            public static string NAME = "AMOUNT";
            public static int MIN_LEN = 2;
            public static int MAX_LEN = 8;
            public static string PATTERN = "[0-9]{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;

        }

        public static class ACQUIRER
        {
            public static string NAME = "ACQUIRER";
            public static string PATTERN = "[A-Za-z0-9]{5}";


        }

        public static class IPADDRESS
        {
            public static string NAME = "IPADDRESS";
            public static string PATTERN = "^(?=.*[^\\.]$)((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.?){4}$";


        }

        public static class PP_AUTHENTICATEMETHOD
        {
            public static string NAME = "PP_AUTHENTICATEMETHOD";
            public static string PATTERN = "([MERCHANT ONLY]|[3DS]|[NO AUTHENTICATION]){3,20}";


        }

        public static class PP_CARDENROLLMETHOD
        {
            public static string NAME = "PP_CARDENROLLMETHOD";
            public static string PATTERN = "([Manual]|[Direct Provisioned]|[3DS Manual]|[NFC Tap]){6,20}";

        }

        public static class SCENROLLSTATUS
        {
            public static string NAME = "SCENROLLSTATUS";
            public static string PATTERN = "([Y]|[N]|[U]){1}";


        }


        public static class CURRENCY
        {

            public static string NAME = "CURRENCY";
            public static int LEN = 3;
            public static string PATTERN = "[0-9]{" + LEN + "}";
            public static string EURO = "978";
            public static bool MANDATORY = true;



        }

        public static class PARESSTATUS
        {
            public static string NAME = "PARESSTATUS";
            public static string PATTERN = "([Y]|[N]|[A]|[U]){1}";

        }

        public static class SIGNATUREVERIFICATION
        {
            public static string NAME = "SIGNATUREVERIFICATION";
            public static int LEN = 1;
            public static string PATTERN = "([Y]|[N]){" + LEN + "}";


        }

        public static class TRECURR
        {
            public static string NAME = "TRECURR";
        }

        public static class CRECURR
        {
            public static string NAME = "CRECURR";
        }

        public static class TOKEN
        {
            public static string NAME = "TOKEN";
        }

        public static class ORIGINALREQREFNUM
        {
            public static string NAME = "ORIGINALREQREFNUM";
            public static string PATTERN = "[20[0-9][0-9](0[1-9]|1[0-2])(0[1-9]|2[0-9]|3[0-1])]{8}\\d{24}";


        }


        public static class EXPONENT
        {

            public static string NAME = "EXPONENT";
            public static int LEN = 1;
            public static string PATTERN = "[0-9]{" + LEN + "}";
            public static bool MANDATORY = false; // CONDITIONAL
            public static string EURO = "2";
            public static int DEFAULT = 2;



        } // Only if Currency is different from 978 (Euro)


        public static class COMMIS
        {
            public static string NAME = "COMMIS";
        }

        public static class VSID
        {
            public static string NAME = "VSID";
        }


        public static class REMAININGDURATION
        {
            public static string NAME = "REMAININGDURATION";


        }


        public static class BP_POSTEPAY
        {
            public static string NAME = "BP_POSTEPAY";
        }


        public static class BP_CARDS
        {
            public static string NAME = "BP_CARDS";


        }


        public static class PHONENUMBER
        {
            public static string NAME = "PHONENUMBER";
        }


        public static class CAUSATION
        {
            public static string NAME = "CAUSATION";
        }


        public static class USER
        {
            public static string NAME = "USER";
        }


        public static class DATA3DS
        {
            public static string NAME = "3DSDATA";
        }

        public static class THREEDSMTDNOTIFURL
        {
            public static string NAME = "THREEDSMTDNOTIFURL";

        }

        public static class CHALLENGEWINSIZE
        {
            public static string NAME = "CHALLENGEWINSIZE";

        }

        public static class NOTIFURL
        {
            public static string NAME = "NOTIFURL";

        }

        public static class THREEDSTRANSID
        {
            public static string NAME = "THREEDSTRANSID";

        }

        public static class THREEDSMTDCOMPLIND
        {
            public static string NAME = "THREEDSMTDCOMPLIND";
            public static int LEN = 1;
            public static string PATTERN = "[NY]{" + LEN + "}";


        }

        public static class THREEDSDATA
        {
            public static string NAME = "THREEDSDATA";

        }


        public static class ORDERID
        {

            public static string NAME = "ORDERID";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 50;
            public static string PATTERN = "[a-zA-Z0-9\\\\\\-//_]{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class TRANSACTIONID
        {

            public static string NAME = "TRANSACTIONID";
            public static int LEN = 25;


            /*
             * public static  int LEN = 15; public static  string PATTERN =
             * "[0-9]{" + LEN + "}"; public static  bool MANDATORY = true;
             */
        }

        public static class SHOPID
        {

            public static string NAME = "SHOPID";
            public static int LEN = 15;
            public static string PATTERN = "[0-9A-Za-z]{" + LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class SHORTID
        {

            public static string NAME = "SHORTID";
            public static int LEN = 2;
            public static string PATTERN = "[0-9]{" + LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class URLBACK
        {

            public static string NAME = "URLBACK";
            public static int MIN_LEN = 10;
            public static int MAX_LEN = 254;
            public static string PATTERN = "^https?://.{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class URLDONE
        {

            public static string NAME = "URLDONE";
            public static int MIN_LEN = 10;
            public static int MAX_LEN = 254;
            public static string PATTERN = "^https?://.{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class URLMS
        {

            public static string NAME = "URLMS";
            public static int MIN_LEN = 10;
            public static int MAX_LEN = 400;
            public static string PATTERN = "^https?://.{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = false; // OPTIONAL


        }

        public static class ACCOUNTINGMODE
        {

            public static string NAME = "ACCOUNTINGMODE";
            public static int LEN = 1;
            public static string PATTERN = "[DI]{" + LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class AUTHORMODE
        {

            public static string NAME = "AUTHORMODE";
            public static int LEN = 1;
            public static string PATTERN = "[DI]{" + LEN + "}";
            public static bool MANDATORY = true;
        }

        public static class MAC
        {

            public static string NAME = "MAC";
            public static int MIN_LEN = 32;
            public static int MAX_LEN = 32;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;
        }

        public static class NETWORK
        {

            public static string NAME = "NETWORK";
            public static int LEN = 2;
            public static string PATTERN = "[0-9]{" + LEN + "}";
            public static bool MANDATORY = false; // CONDITIONAL

        }

        public static class PAN
        {

            public static string NAME = "PAN";
            public static int MIN_LEN = 10;
            public static int MAX_LEN = 18;
            public static int PANALIAS_LEN = 19;
            public static string PATTERNGENERIC = "^[0-9]{" + MIN_LEN + "," + PANALIAS_LEN + "}";
            public static string PATTERNTOKENCARD = "^[0-9]{" + MIN_LEN + "," + MAX_LEN + "}";
            public static string PATTERNPAYPALPANALIAS = "^[0-9]{" + PANALIAS_LEN + "}";
            public static bool MANDATORY = false; // CONDITIONAL
        }

        public static class EXPDATE
        {

            public static string NAME = "EXPDATE";
            public static string PATTERN = "^[0-9]{2}(0[0-9]|1[0-2])";
            public static bool MANDATORY = false; // CONDITIONAL

        }

        public static class OPERATORID
        {

            public static string NAME = "OPERATORID";
            public static int MIN_LEN = 8;
            public static int MAX_LEN = 18;
            public static string PATTERN = "[a-zA-Z0-9]{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = false; // RECOMMENDED

        }

        public static class IBAN
        {

            public static string NAME = "IBAN";
            public static int LEN = 27;
            public static string PATTERN = "[IT|SM]+[0-9]{2}+[A-Z]+[0-9]{" + (LEN - 5) + "}";
            public static bool MANDATORY = false; // CONDITIONAL
        }

        public static class LANG
        {

            public static string NAME = "LANG";
            public static int MIN_LEN = 2;
            public static int MAX_LEN = 3;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = false; // OPTIONAL

        }

        public static class OPTIONS
        {

            public static string NAME = "OPTIONS";
            public static string PATTERN = "[A-Za-z]*";
            public static bool MANDATORY = true;
            public static string G = "G";
            public static string H = "H";
            public static string M = "M";
            public static string N = "N";
        }

        public static class LOCKCARD
        {

            public static string NAME = "LOCKCARD";
            public static bool MANDATORY = false; // OPTIONAL

        }

        public static class EMAIL
        {

            public static string NAMECH = "EMAILCH";
            public static string NAME = "EMAIL";
            public static string SHOPNAME = "SHOPEMAIL";
            public static int MIN_LEN = 7;
            public static int MAX_LEN = 50;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = false; // RECOMMENDED
        }

        public static class ORDDESCR
        {

            public static string NAME = "ORDDESCR";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 140;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = false; // OPTIONAL

        }

        public static class OPDESCR
        {

            public static string NAME = "OPDESCR";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 100;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = false; // OPTIONAL

        }

        public static class USERID
        {

            public static string NAME = "USERID";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 255;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;

        }

        public static class NAME_
        {

            public static string NAME = "NAME";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 40;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;


        }

        public static class SURNAME
        {

            public static string NAME = "SURNAME";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 40;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;

        }

        public static class TAXID
        {

            public static string NAME = "TAXID";
            public static int TI_LEN = 11;
            public static int FC_LEN = 16;
            public static string PATTERN = "^([A-Z0-9]{" + FC_LEN + "}|[0-9]{" + TI_LEN + "})";
            public static bool MANDATORY = true;

        }

        public static class PRODUCTREF
        {

            public static string NAME = "PRODUCTREF";
            public static int MIN_LEN = 1;
            public static int MAX_LEN = 50;
            public static string PATTERN = ".{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;
        }

        public static class ANTIFRAUD
        {

            public static string NAME = "ANTIFRAUD";
            public static string PATTERN = ".*";
            public static bool MANDATORY = true;

        }

        public static class LINKCODE
        {

            public static string NAME = "LINKCODE";
            public static int LEN = 6;
            public static string PATTERN = "[0-9]{" + LEN + "}";
            public static bool MANDATORY = true;

        }

        public static class CVV
        {

            public static string NAME = "CVV";
            public static int MIN_LEN = 3;
            public static int MAX_LEN = 4;
            public static string PATTERN = "[0-9]{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;

        }

        public static class CVV2
        {

            public static string NAME = "CVV2";
            public static int MIN_LEN = 3;
            public static int MAX_LEN = 4;
            public static string PATTERN = "[0-9]{" + MIN_LEN + "," + MAX_LEN + "}";
            public static bool MANDATORY = true;

        }

    }



}
