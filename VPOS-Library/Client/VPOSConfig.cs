using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Client
{
    class VPOSConfig : Config
    {
        public string shopID { get { return shopID; } set { shopID = value; } }
        public string redirectKey { get { return redirectKey; } set { redirectKey = value; } }
        public string redirectUrl { get { return redirectUrl; } set { redirectUrl = value; } }
        public string apiKey { get { return apiKey; } set { apiKey = value; } }
        public string proxyHost { get { return proxyHost; } set { proxyHost = value; } }
        public int proxyPort { get { return proxyPort; } set { proxyPort = value; } }
        public string proxyUsername { get { return proxyUsername; } set { proxyUsername = value; } }
        public string proxyPassword { get { return proxyPassword; } set { proxyPassword = value; } }
        public string apiUrl { get { return apiUrl; } set { apiUrl = value; } }
        public string algorithm { get { return algorithm; } set { algorithm = value; } }
    }
}
