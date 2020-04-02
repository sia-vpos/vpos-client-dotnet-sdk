using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Client
{
    class VPOSConfig : Config
    {
        public VPOSConfig() {
            Timeout = 15;
        }
        public string ShopID { get { return ShopID; } set { ShopID = value; } }
        public string RedirectKey { get { return RedirectKey; } set { RedirectKey = value; } }
        public string RedirectUrl { get { return RedirectUrl; } set { RedirectUrl = value; } }
        public string ApiKey { get { return ApiKey; } set { ApiKey = value; } }
        public string ProxyHost { get { return ProxyHost; } set { ProxyHost = value; } }
        public int ProxyPort { get { return ProxyPort; } set { ProxyPort = value; } }
        public string ProxyUsername { get { return ProxyUsername; } set { ProxyUsername = value; } }
        public string ProxyPassword { get { return ProxyPassword; } set { ProxyPassword = value; } }
        public string ApiUrl { get { return ApiUrl; } set { ApiUrl = value; } }
        public string Algorithm { get { return Algorithm; } set { Algorithm = value; } }
        public int Timeout { get { return Timeout; } set { Timeout = value; } }

    }
}
