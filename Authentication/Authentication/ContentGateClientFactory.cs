using AXtension.ContentGate.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication
{
    class ContentGateClientFactory
    {
        private readonly Uri _baseUrl;
        private readonly string _clientId;
        private readonly string _authority;

        public ContentGateClientFactory(Uri baseUrl, string clientId, string authority)
        {
            this._baseUrl = baseUrl;
            this._clientId = clientId;
            this._authority = authority;
        }

        public ContentGateClient CreateClientWithDeviceCode()
        {
            // for device authentication, simply use the default console output to instruct the user.
            // how to authenticate.
            var deviceCodeAuthenticator = DeviceAuthentication.Console;

            // construct the client.
            return new ContentGateClient(_baseUrl, new ContentGateCredentials(_clientId, _authority, deviceCodeAuthenticator));
        }

        public ContentGateClient CreateClientWithClientIdAndSecret(string clientSecret)
            => new ContentGateClient(_baseUrl, new ContentGateCredentials(_clientId, _authority, clientSecret));
        
        public ContentGateClient CreateClientWithUsernameAndPassword(string username, string password)
            => new ContentGateClient(_baseUrl, new ContentGateCredentials(_clientId, _authority, username, password));

        public ContentGateClient CreateClientWithUserPrompt()
            => new ContentGateClient(_baseUrl, new ContentGateCredentials(_clientId, _authority));

        public ContentGateClient CreateClientWithCustomAuthorizationHeader()
            => new ContentGateClient(_baseUrl, new CustomContentGateCredentials(_clientId, _authority));
    }
}
