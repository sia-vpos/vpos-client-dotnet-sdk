using System.Security.Cryptography.X509Certificates;

namespace VPOS_Library.Client
{
    public interface Config
    {
        string ShopID { get; set; }

        string RedirectKey { get; set; }

        string RedirectUrl { get; set; }

        string ApiKey { get; set; }

        string ProxyHost { get; set; }

         int ProxyPort { get; set; }

        string ProxyUsername { get; set; }

        string ProxyPassword { get; set; }

        string ApiUrl { get; set; }

        string Algorithm { get; set; }

        int Timeout { get; set; }

        X509Certificate2 Certificate { get ; set ;}

    }
}
