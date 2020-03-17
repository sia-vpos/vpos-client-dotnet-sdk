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
            URL url = null;
            var query_pairs = new Dictionary<string, string>();

            url = new URL(urlString);

            String query = url.getQuery();
            String[] pairs = query.Split('&');
            foreach (String pair in pairs)
            {
                int idx = pair.IndexOf("=");
                query_pairs.Add(URLDecoder.decode(pair.Substring(0, idx), "UTF-8"), URLDecoder.decode(pair.Substring(idx + 1), "UTF-8"));
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

            map.Add("AMOUNT", values["AMOUNT"]);
            map.Add("CURRENCY", values["CURRENCY"]);
            map.Add("EXPONENT", values["EXPONENT.NAME"]);
            map.Add("TRANSACTIONID", values["TRANSACTIONID.NAME"]);
            map.Add("ACCOUNTINGMODE", values["ACCOUNTINGMODE.NAME"]);
            map.Add("AUTHORMODE", values["AUTHORMODE"]);
            map.Add("RESULT", values["RESULT"]);
            map.Add("TRANSACTIONTYPE", values["TRANSACTIONTYPE"]);
            map.Add("ISSUERCOUNTRY", values["ISSUERCOUNTRY"]);
            map.Add("AUTHCODE", values["AUTHCODE"]);
            map.Add("PAYERID", values["PAYERID"]);
            map.Add("PAYER", values["PAYER"]);
            map.Add("PAYERSTATUS", values["PAYERSTATUS"]);
            map.Add("HASHPAN", values["HASHPAN"]);
            map.Add("PANALIASREV", values["PANALIASREV"]);
            map.Add("PANALIAS", values["PANALIAS"]);
            map.Add("PANALIASEXPDATE", values["PANALIASEXPDATE"]);
            map.Add("PANALIASTAIL", values["PANALIASTAIL"]);

            map.Add("MASKEDPAN", values["MASKEDPAN"]);
            map.Add("PANTAIL", values["PANTAIL"]);
            map.Add("PANEXPIRYDATE", values["PANEXPIRYDATE"]);

            map.Add("ACCOUNTHOLDER", values["ACCOUNTHOLDER"]);
            map.Add("IBAN", values["IBAN.NAME"]);
            map.Add("ALIASSTR", values["ALIASSTR"]);
            map.Add("ACQUIRERBIN", values["ACQUIRERBIN"]);
            map.Add("MERCHANTID", values["MERCHANTID"]);
            map.Add("CARDTYPE", values["CARDTYPE"]);
            return map;
        }
    }
    
}
