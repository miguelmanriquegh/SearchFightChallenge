using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SearchFightChallenge.Engine
{
    class GoogleEngine : ISearchEngine
    {
        private string name;
        private string engineUrl;
        private long totalResults;

        public GoogleEngine()
        {
            var googleApiKey = "AIzaSyAzBOB1i-9IMQwW0pJl6RpUEKMRvvVyAP4";
            var googleEngineID = "a6357b354bd26f338sd";
            this.Name = "Google";
            this.EngineUrl = "https://www.googleapis.com/customsearch/v1?key=" + googleApiKey + "&cx=" + googleEngineID + "&q=";
        }

        public string Name { get; set; }
        public string EngineUrl { get; set; }
        public long TotalResults { get; set; }

        public void GenerateRequest(string searchArgument)
        {
            //Building request for api
            var url = this.EngineUrl + searchArgument;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();
            this.TotalResults = JsonConvert.DeserializeObject<GoogleEngine>(html).SearchInformation.TotalResults;
        }

        public Searchinformation SearchInformation { get; set; }

    }

    public class Searchinformation
    {
        public long TotalResults { get; set; }
    }
}
