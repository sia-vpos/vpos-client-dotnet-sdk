using System;
using System.Collections.Generic;
using System.Text;

namespace VPOS_Library.Client
{
    public interface Config
    {
        String shopID { get; set; }

         String redirectKey { get; set; }

         String redirectUrl { get; set; }

         String apiKey { get; set; }

         String proxyHost { get; set; }

         int proxyPort { get; set; }

         String proxyUsername { get; set; }

         String proxyPassword { get; set; }

         String apiUrl { get; set; }

         String algorithm { get; set; }

        
    }
}
