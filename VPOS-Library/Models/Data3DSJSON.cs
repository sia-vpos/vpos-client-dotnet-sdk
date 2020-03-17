using java.lang;
using System;
using System.Reflection;

namespace VPOS_Library.Models
{
    public class Data3DSJSON
    {
        //Step 0
        public string browserAcceptHeader { get; set; }
        public string browserIP { get; set; }
        public string browserJavaEnabled { get; set; }
        public string browserLanguage { get; set; }
        public string browserColorDepth { get; set; }
        public string browserScreenHeight { get; set; }
        public string browserScreenWidth { get; set; }
        public string browserTZ { get; set; }
        public string browserUserAgent { get; set; }

        //Redirect
        public string threeDSRequestorChallengeInd { get; set; }
        public string addrMatch { get; set; }
        public string chAccAgeInd { get; set; }
        public string chAccChange { get; set; }
        public string chAccChangeInd { get; set; }
        public string chAccDate { get; set; }
        public string chAccPwChange { get; set; }
        public string chAccPwChangeInd { get; set; }
        public string nbPurchaseAccount { get; set; }
        public string txnActivityDay { get; set; }
        public string txnActivityYear { get; set; }
        public string shipAddressUsage { get; set; }
        public string shipAddressUsageInd { get; set; }
        public string shipNameIndicator { get; set; }
        public string acctID { get; set; }
        public string billAddrCity { get; set; }
        public string billAddrCountry { get; set; }
        public string billAddrLine1 { get; set; }
        public string billAddrLine2 { get; set; }
        public string billAddrLine3 { get; set; }
        public string billAddrPostCode { get; set; }
        public string billAddrState { get; set; }
        public string homePhone { get; set; }
        public string mobilePhone { get; set; }
        public string shipAddrCity { get; set; }
        public string shipAddrCountry { get; set; }
        public string shipAddrLine1 { get; set; }
        public string shipAddrLine2 { get; set; }
        public string shipAddrLine3 { get; set; }
        public string shipAddrPostCode { get; set; }
        public string shipAddrState { get; set; }
        public string workPhone { get; set; }
        public string deliveryEmailAddress { get; set; }
        public string deliveryTimeframe { get; set; }
        public string preOrderDate { get; set; }
        public string preOrderPurchaseInd { get; set; }
        private string reorderItemsInd { get; set; }
        private string shipIndicator { get; set; }

        public string ToJSONString()
        {
            StringBuilder sb = new StringBuilder();
            sb.append("{");
            var bindingFlags = BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public;
            var fields = this.GetType()
                                 .GetFields(bindingFlags);
            foreach (FieldInfo field in fields)
            {
                if (field.GetValue(this) != null)
                {
                    sb.append("\"");
                    var name = field.Name;
                    name=name.Replace("<", "");
                    name=name.Replace(">", "");
                    name=name.Replace("k__BackingField", "");
                    sb.append(name);
                    sb.append("\":\"");
                    sb.append(field.GetValue(this));
                    sb.append("\",");
                }
            }
            sb.deleteCharAt(sb.length() - 1);
            sb.append("}");
            Console.WriteLine(sb.toString());
            return sb.toString();
        }


    }
}