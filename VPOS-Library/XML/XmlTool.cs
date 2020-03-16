using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using VPOS_Library.XMLModels.Request;

namespace VPOS_Library.XML
{
    public static class XmlTool
    {
        private const string XmlnsPattern = " xmlns.*>";
        private const string EmptyTagPattern = "<.* />\r\n";

        public static string Serialize<T>(BPWXmlRequest<T> request) where T : GenericRequest
        {
            var serializer = new XmlSerializer(typeof(BPWXmlRequest<T>));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, request);
                var xmlString = textWriter.ToString().Replace("RequestTag", request.Data.RequestTag.GetRequestTag());
                xmlString = Regex.Replace(xmlString, XmlnsPattern, ">");
                xmlString = Regex.Replace(xmlString, "utf-16", "utf-8");
                xmlString = Regex.Replace(xmlString, EmptyTagPattern, "");
                return xmlString;
            }
        }

        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var sr = new StringReader(xml))
            {
                var res = serializer.Deserialize(sr);
                Console.WriteLine(res.ToString());
                return (T) res;
            }
        }
    }
}