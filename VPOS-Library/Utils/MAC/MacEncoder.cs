using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace VPOS_Library.Utils.MAC
{
    public class MacEncoder
    {
        public string GetMac(OrderedDictionary values, string key)
        {
            var macString = "";
            foreach (DictionaryEntry entry in values)
                if (entry.Value != null)
                    macString += entry.Key + "=" + entry.Value + "&";
            macString = macString.Remove(macString.Length - 1);
            //Console.WriteLine(macString);
            return HashHmac(key, macString);
        }

        public string GetMac(List<string> values, string key)
        {
            var macString = values.Aggregate("", (current, value) => (value != null) ? current + value.Trim() + "&" : current);
            macString = macString.Remove(macString.Length - 1);
            //Console.WriteLine(macString);
            return HashHmac(key, macString);
        }

        private static string HashHmac(string key, string value)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var valueBytes = Encoding.UTF8.GetBytes(value);

            using (var hash = new HMACSHA256(keyBytes))
            {
                return hash.ComputeHash(valueBytes).Aggregate("", (s, e) => s + string.Format("{0:x2}", e), s => s);
            }
        }
    }
}