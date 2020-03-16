using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace VPOS_Library.Utils
{
    public class HtmlTool
    {
        private const string FormPattern =
            "PGZvcm0gYWN0aW9uPSJbQVBPU19VUkxdIiBtZXRob2Q9IlBPU1QiPjxpbnB1dCBuYW1lPSJQQUdFIiB0eXBlPSJoaWRkZW4iIHZhbHVlPSJMQU5EIj5bUEFSQU1FVEVSU108aW5wdXQgaWQ9InN1Ym1pdCIgc3R5bGU9ImRpc3BsYXk6IG5vbmU7IiB0eXBlPXN1Ym1pdCAgdmFsdWU9Ii4iPjwvZm9ybT4NCg==";

        private const string InputPattern = "PGlucHV0IHR5cGU9ImhpZGRlbiIgbmFtZT0iS0VZIiB2YWx1ZT0iVkFMVUUiPg==";

        private const string Script =
            "PHNjcmlwdCB0eXBlPSJ0ZXh0L2phdmFzY3JpcHQiPndpbmRvdy5vbmxvYWQgPSBmdW5jdGlvbigpe3NldFRpbWVvdXQoZnVuY3Rpb24oKXtkb2N1bWVudC5nZXRFbGVtZW50QnlJZCgnc3VibWl0JykuY2xpY2soKTt9LCBbREVMQVldKTt9PC9zY3JpcHQ+";

        public string HtmlToBase64(string filePath, string urlApos, OrderedDictionary values)
        {
            var html = System.IO.File.ReadAllText(filePath);
            html = html.Replace("[APOS_URL]", urlApos);
            html = html.Replace("[PARAMETERS]", GenerateParamsHtml(values));
            var data = Encoding.UTF8.GetBytes(html);
            return Convert.ToBase64String(data);
        }

        public string Base64ToHtml(string base64, int delay)
        {
            var html = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            var decodedForm = Encoding.UTF8.GetString(Convert.FromBase64String(FormPattern));
            var decodedScript = Encoding.UTF8.GetString(Convert.FromBase64String(Script));

            html = html.Replace("</body>", decodedForm + "</body>");
            html = html.Replace("</html>", decodedScript + "</html>");
            html = html.Replace("[DELAY]", delay.ToString());

            return html;
        }

        private static string GenerateParamsHtml(OrderedDictionary values)
        {
            var result = "";
            var inputPattern = Encoding.UTF8.GetString(Convert.FromBase64String(InputPattern));
            foreach (DictionaryEntry entry in values)
                if (entry.Value != null)
                {
                    result += inputPattern.Replace("KEY", (string) entry.Key).Replace("VALUE", (string) entry.Value);
                }

            return result;
        }
    }
}