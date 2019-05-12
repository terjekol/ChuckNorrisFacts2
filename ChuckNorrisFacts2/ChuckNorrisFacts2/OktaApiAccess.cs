using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorrisFacts2
{
    public class OktaApiAccess
    {
        private RestClient _client;
        string _oktaToken = "007-cEy4MwK_hA6pvuhn2iheO9i__GOKA67XlLRXae";

        public OktaApiAccess()
        {
            _client = new RestClient("https://dev-660868.okta.com");
            var request = new RestRequest("/api/v1/authn", Method.POST);
            request.RequestFormat = DataFormat.Xml;
            request.AddParameter("username", "per@terje.kolderup.net");
            request.AddParameter("password", "Abcd1234");
            var response = _client.Execute(request);
            var x = response.Content;
        }
    }
}
