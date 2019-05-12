using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace ChuckNorrisFacts2
{
    public class FactsApiAccess
    {
        private RestClient _client;

        public FactsApiAccess()
        {
            _client = new RestClient("https://api.chucknorris.io");
        }

        public string GetFact(string category = null)
        {
            var url = "/jokes/random";
            if (category != null) url += "?category=" + category;
            var fact = Get<Fact>(url);
            return fact?.value;
        }


        public string[] GetCategories()
        {
            return Get<string[]>("/jokes/categories");
        }

        private T Get<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);
            var response = _client.Execute(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
