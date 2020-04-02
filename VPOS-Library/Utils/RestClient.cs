using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VPOS_Library.Utils.Exception;

namespace VPOS_Library.Utils
{
    public class RestClient
    {
        private static HttpClient _client = new HttpClient();

        public RestClient(int timeout)
        {
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            _client.Timeout = TimeSpan.FromSeconds(timeout);
        }

        public string CallApi(string url, string xmlBody)
        {
            try
            {
                var data = new StringContent("data=" + xmlBody, Encoding.UTF8, "application/x-www-form-urlencoded");
                Console.WriteLine("Sending request to " + url + " with body: \n" + data.ReadAsStringAsync().Result);
                var response = _client.PostAsync(url, data).Result;

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return response.Content.ReadAsStringAsync().Result;
            }
            catch {
                throw new VPOSClientException("Connection Error while contacting VPOS");
            }
        }

        public void SetProxy(string proxyName, int port, string user, string password)
        {
            _client = GenerateHttpClientWithProxySettings(proxyName, port, user, password);
            _client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        private HttpClient GenerateHttpClientWithProxySettings(string proxyName, int port, string user, string password)
        {
            // First create a proxy object
            var proxy = new WebProxy()
            {
                Address = new Uri(proxyName + ":" + port),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };

            // *** These credentials are given to the proxy server, not the web server ***
            if (user != null && password != null)
                proxy.Credentials = new NetworkCredential(
                    userName: user,
                    password: password);

            // Now create a client handler which uses that proxy
            var httpClientHandler = new HttpClientHandler()
            {
                Proxy = proxy,
                UseProxy = true,
                AllowAutoRedirect = true,
            };

            //// Omit this part if you don't need to authenticate with the web server:
            //if (needServerAuthentication)
            //{
            //    httpClientHandler.PreAuthenticate = true;
            //    httpClientHandler.UseDefaultCredentials = false;

            //    // *** These creds are given to the web server, not the proxy server ***
            //    httpClientHandler.Credentials = new NetworkCredential(
            //        userName: serverUserName,
            //        password: serverPassword);
            //}

            // Finally, create the HTTP client object
            return new HttpClient(handler: httpClientHandler, disposeHandler: true);
        }
    }
}