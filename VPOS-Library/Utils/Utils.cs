using java.net;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace VPOS_Library.Utils
{
    public class Utils
    {
        private Utils() { }

        public static Dictionary<string,string> splitQuery(String urlString)
        {
            var query_pairs = new Dictionary<string, string>();

            //url = new URL(urlString);
            string queryString = new System.Uri(urlString).Query;
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var k in queryDictionary.AllKeys)
            {
                query_pairs.Add(k, queryDictionary[k]);
            }
            return query_pairs;
        }

        public static OrderedDictionary getUrlDoneDictionary(Dictionary<string,string> values) {
            var map = new OrderedDictionary();

            map.Add("ORDERID", values["ORDERID"]);
            map.Add("SHOPID", values["SHOPID"]);

            if (values["AUTHNUMBER"] == null)
                map.Add("AUTHNUMBER", "NULL");
            else
                map.Add("AUTHNUMBER", values["AUTHNUMBER"]);

            map.Add("AMOUNT", values.ContainsKey("AMOUNT") == true? values["AMOUNT"] : null);
            map.Add("CURRENCY", values.ContainsKey("CURRENCY") == true? values["CURRENCY"] : null);
            map.Add("EXPONENT", values.ContainsKey("EXPONENT") == true ? values["EXPONENT"]:null);
            map.Add("TRANSACTIONID", values.ContainsKey("TRANSACTIONID") == true ? values["TRANSACTIONID"]:null);
            map.Add("ACCOUNTINGMODE", values.ContainsKey("ACCOUNTINGMODE") == true ? values["ACCOUNTINGMODE"]: null);
            map.Add("AUTHORMODE", values.ContainsKey("AUTHORMODE") == true ? values["AUTHORMODE"]:null);
            map.Add("RESULT", values.ContainsKey("RESULT") == true ? values["RESULT"]:null);
            map.Add("TRANSACTIONTYPE", values.ContainsKey("TRANSACTIONTYPE") == true ? values["TRANSACTIONTYPE"]:null);
            map.Add("ISSUERCOUNTRY", values.ContainsKey("ISSUERCOUNTRY") == true ? values["ISSUERCOUNTRY"]:null);
            map.Add("AUTHCODE", values.ContainsKey("AUTHCODE") == true ? values["AUTHCODE"]:null);
            map.Add("PAYERID", values.ContainsKey("PAYERID") == true ? values["PAYERID"]:null);
            map.Add("PAYER", values.ContainsKey("PAYER") == true ? values["PAYER"]:null);
            map.Add("PAYERSTATUS", values.ContainsKey("PAYERSTATUS") == true ? values["PAYERSTATUS"]:null);
            map.Add("HASHPAN", values.ContainsKey("HASHPAN") == true ? values["HASHPAN"]:null);
            map.Add("PANALIASREV", values.ContainsKey("PANALIASREV") == true ? values["PANALIASREV"]:null);
            map.Add("PANALIAS", values.ContainsKey("PANALIAS") == true ? values["PANALIAS"]:null);
            map.Add("PANALIASEXPDATE", values.ContainsKey("PANALIASEXPDATE") == true ? values["PANALIASEXPDATE"]:null);
            map.Add("PANALIASTAIL", values.ContainsKey("PANALIASTAIL") == true ? values["PANALIASTAIL"]:null);

            map.Add("MASKEDPAN", values.ContainsKey("MASKEDPAN") == true ? values["MASKEDPAN"]:null);

            map.Add("TRECURR", values.ContainsKey("TRECURR") == true ? values["TRECURR"] : null);
            map.Add("CRECURR", values.ContainsKey("CRECURR") == true ? values["CRECURR"] : null);

            map.Add("PANTAIL", values.ContainsKey("PANTAIL") == true ? values["PANTAIL"]:null);
            map.Add("PANEXPIRYDATE", values.ContainsKey("PANEXPIRYDATE") == true ? values["PANEXPIRYDATE"]:null);

            map.Add("ACCOUNTHOLDER", values.ContainsKey("ACCOUNTHOLDER") == true ? values["ACCOUNTHOLDER"]:null);
            map.Add("IBAN", values.ContainsKey("IBAN") == true ? values["IBAN"]:null);
            map.Add("ALIASSTR", values.ContainsKey("ALIASSTR") == true ? values["ALIASSTR"]:null);
            map.Add("EMAILCH", values.ContainsKey("EMAILCH") == true ? values["EMAILCH"] : null);
            map.Add("CFISC", values.ContainsKey("CFISC") == true ? values["CFISC"] : null);
            map.Add("ACQUIRERBIN", values.ContainsKey("ACQUIRERBIN") == true ? values["ACQUIRERBIN"]:null);
            map.Add("MERCHANTID", values.ContainsKey("MERCHANTID") == true ? values["MERCHANTID"]:null);
            map.Add("CARDTYPE", values.ContainsKey("CARDTYPE") == true ? values["CARDTYPE"]:null);
            map.Add("AMAZONAUTHID", values.ContainsKey("AMAZONAUTHID") == true ? values["AMAZONAUTHID"] : null);
            map.Add("AMAZONCAPTUREID", values.ContainsKey("AMAZONCAPTUREID") == true ? values["AMAZONCAPTUREID"] : null);
            map.Add("CHINFO", values.ContainsKey("CHINFO") == true ? values["CHINFO"] : null);

            return map;
        }
    }
    
}
