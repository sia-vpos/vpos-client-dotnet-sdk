using System.Collections.Generic;

namespace VPOS_Library.Response
{
    public class OrderStatusResponse
    {
        public string Result { get; set; }
        public string Timestamp { get; set; }
        public string ProductRef { get; set; }
        public string PanAlias { get; set; }
        public string PanAliasRev { get; set; }
        public string PanAliasExpDate { get; set; }
        public string PanAliasTail { get; set; }
        public List<AuthorizationResponse> Authorizations { get; set; }

    }
}
