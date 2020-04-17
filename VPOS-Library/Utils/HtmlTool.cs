using System.Collections;
using System.Collections.Specialized;

namespace VPOS_Library.Utils
{
    public class HtmlTool
    {
        private const string InputPattern = "<input type=\"hidden\" name=\"KEY\" value=\"VALUE\">";

        private const string Template = "<div><form id=\"myForm\"action=\"[VPOS_URL]\" method=\"POST\"><input name=\"PAGE\" type=\"hidden\" value=\"[PAGE]\">[PARAMETERS]</form><script type=\"text/javascript\">function subForm() {document.getElementById('myForm').submit();}</script></div>";
        public string BuildHtml(string vposUrl, OrderedDictionary values)
        {
            var html = Template;
            if (values.Contains("TOKEN") && values["TOKEN"]  != null)
            {
                html = html.Replace("[PAGE]", "TOKEN");
            }
            else {
                html = html.Replace("[PAGE]", "LAND");
            }
            html = html.Replace("[VPOS_URL]", vposUrl);
            html = html.Replace("[PARAMETERS]", GenerateParamsHtml(values));  
            return html;
        }


        private static string GenerateParamsHtml(OrderedDictionary values)
        {
            var result = "";
            var inputPattern = InputPattern;
            foreach (DictionaryEntry entry in values)
                if (entry.Value != null)
                {
                    result += inputPattern.Replace("KEY", (string) entry.Key).Replace("VALUE", (string) entry.Value);
                }

            return result;
        }
    }
}