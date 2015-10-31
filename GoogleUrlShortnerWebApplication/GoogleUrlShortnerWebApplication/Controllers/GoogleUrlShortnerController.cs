using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace GoogleUrlShortnerWebApplication.Controllers
{
    public class GoogleUrlShortnerController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public List<string> UrlShortner(string urlsNewLineSeparated)
        {
            string[] urlArray = urlsNewLineSeparated.Split(new char[] {'\n'});
            return UrlShortner(urlArray);
        }

        public List<string> UrlShortner(string[] urlArray)
        {
            List<string> shortenedUrlList = new List<string>();
            shortenedUrlList.Add(GetShortUrl(urlArray[0]));
            return shortenedUrlList;

        }

        public string GetShortUrl(string longUrl)
        {
            using (var client = new WebClient())
            {
                NameValueCollection json = new NameValueCollection();
                json["longUrl"] = longUrl;

                var response = client.UploadValues("https://www.googleapis.com/urlshortener/v1/url?key=AIzaSyBXrUXJ5lT3MeUkxDmBHmnNpfJ81cMcS6U", json);

                string responseString = Encoding.Default.GetString(response);

                return responseString;
            }

            return String.Empty;
        }
    }
}
