namespace IPTVM3UGenerator
{
    using System.Net;

    public class MyWebClient : WebClient
    {
        [System.Security.SecuritySafeCritical]
        public MyWebClient() : base()
        {
            this.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36");
            this.Headers.Add("Accept-Language", "en-us,en;q=0.5");
        }

        public CookieContainer m_cookieContainer = new CookieContainer();

        protected override WebResponse GetWebResponse(WebRequest _wRequest)
        {
            if (_wRequest is HttpWebRequest)
            {
                HttpWebRequest wRequest = (_wRequest as HttpWebRequest);

                wRequest.CookieContainer = m_cookieContainer;
                wRequest.AllowAutoRedirect = true;
                wRequest.MaximumAutomaticRedirections = 4;
            }

            return base.GetWebResponse(_wRequest);
        }
    }
}
