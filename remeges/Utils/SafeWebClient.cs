using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhantomLauncher.Utils
{
    public class SafeWebClient
    {
        public static WebClient GenerateClient()
        {
            WebClient cl = new WebClient();
            cl.Proxy = new WebProxy();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            return cl;
        }

        public static WebRequest GenerateRequest(string url)
        {
            WebRequest cl = WebRequest.Create(url);
            cl.Proxy = new WebProxy();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            return cl;
        }
    }
}
