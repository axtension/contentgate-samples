using AXtension.ContentGate.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    class CustomContentGateCredentials : IContentGateCredentials
    {
        private readonly string _clientId;
        private readonly string _authority;

        public CustomContentGateCredentials(string clientId, string authority)
        {
            // This is an example to add a custom contentGateCredentials class.

            this._clientId = clientId;
            this._authority = authority;
        }

        public Task<string> GetAuthorizationHeader(string resource)
        {
            // Implement your own autorization header response.
            throw new NotImplementedException();
        }
    }
}
