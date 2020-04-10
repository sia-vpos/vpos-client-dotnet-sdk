using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VPOS_Library.Client
{
    public class VPOSConfig : Config
    {
        public string shopID;
        public string redirectKey;
        public string redirectUrl;
        public string apiKey;
        public string proxyHost;
        public int proxyPort;
        public string proxyUsername;
        public string proxyPassword;
        public string apiUrl;
        public string algorithm;
        public int timeout;
        public X509Certificate2 certificate;


        public string ShopID { get { return shopID; } set { shopID = value; } }
        public string RedirectKey { get { return redirectKey; } set { redirectKey = value; } }
        public string RedirectUrl { get { return redirectUrl; } set { redirectUrl = value; } }
        public string ApiKey { get { return apiKey; } set { apiKey = value; } }
        public string ProxyHost { get { return proxyHost; } set { proxyHost = value; } }
        public int ProxyPort { get { return proxyPort; } set { proxyPort = value; } }
        public string ProxyUsername { get { return proxyUsername; } set { proxyUsername = value; } }
        public string ProxyPassword { get { return proxyPassword; } set { proxyPassword = value; } }
        public string ApiUrl { get { return apiUrl; } set { apiUrl = value; } }
        public string Algorithm { get { return algorithm; } set { algorithm = value; } }
        public int Timeout { get { return timeout; } set { timeout = value; } }
        public X509Certificate2 Certificate { get { return certificate; } set { certificate=value; } }


        public VPOSConfig()
        {
            this.timeout = 15;
        }
    }
}
