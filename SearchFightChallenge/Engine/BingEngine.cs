using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SearchFightChallenge.Engine
{
    class BingEngine : ISearchEngine
    {
        private string name;
        private string apiKey;
        private string searchUrl;
        private long totalResults;

        public BingEngine()
        {
            this.Name = "Bing";
            this.ApiKey = "a49e37f3cf22407f8475240d74598e0d";
            this.EngineUrl = "https://api.cognitive.microsoft.com/bing/v7.0/search?q=";
        }

        public string Name { get; set; }
        public string ApiKey { get; set; }
        public string EngineUrl { get; set; }
        public long TotalResults { get; set; }

        public void GenerateRequest(string searchArgument)
        {
            //Building request for api
            var url = this.EngineUrl + searchArgument;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.ApiKey);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();
            this.TotalResults = JsonConvert.DeserializeObject<BingEngine>(html).WebPages.TotalMatches;

        }

        public Webpages WebPages { get; set; }

    }


    public class Webpages
    {
        public long TotalMatches { get; set; }
    }
}
