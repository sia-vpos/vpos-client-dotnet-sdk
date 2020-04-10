namespace VPOS_Library.Models
{
    public class PaymentInfo
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Exponent { get; set; }
        public string OrderId { get; set; }
        public string UrlBack { get; set; }
        public string UrlDone { get; set; }
        public string UrlMs { get; set; }
        public string AccountingMode { get; set; }
        public string AuthorMode { get; set; }
        public string Lang { get; set; }
        public string ShopEmail { get; set; }
        private string Options { get; set; }
        public string Lockcard { get; set; }
        public string Commis { get; set; }
        public string OrdDescr { get; set; }
        public string Vsid { get; set; }
        public string OpDescr { get; set; }
        public string RemainingDuration { get; set; }
        public string UserId { get; set; }
        public string BpPostepay { get; set; }
        public string BpCards { get; set; }
        public string PhoneNumber { get; set; }
        public string Causation { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TaxId { get; set; }
        public string ProductRef { get; set; }
        public string AntiFraud { get; set; }
        public Data3DSJSON Data3DS { get; set; }
        public string Network { get; set; }
        public string Token { get; set; }
        public string ExpDate { get; set; }
        public string TRecurr { get; set; }
        public string CRecurr { get; set; }
        public string IBAN { get; set; }
        public string SurnameCH { get; set; }
        public string NameCH { get; set; }
        public string Email { get; set; }
        

        public void AddOption(char option)
        {
            if (Options == null)
                Options = "";
            Options += option;
        }

        public string GetOptions()
        {
            return Options;
        }
    }
}