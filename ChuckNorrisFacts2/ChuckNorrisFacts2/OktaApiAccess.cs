using Okta.Auth.Sdk;
using Okta.Sdk.Abstractions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisFacts2
{
    public class OktaApiAccess
    {
        public static async Task<bool> DoAuth(string email, string password)
        {
            var config = new OktaClientConfiguration { OktaDomain = "https://dev-660868.okta.com", };
            var authClient = new AuthenticationClient(config);

            var authnOptions = new AuthenticateOptions { Username = email, Password = password };
            try
            {
                var authnResponse = await authClient.AuthenticateAsync(authnOptions);
                return authnResponse.AuthenticationStatus == AuthenticationStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}
