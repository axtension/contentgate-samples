using AXtension.ContentGate.Client;
using AXtension.ContentGate.Client.Query;
using AXtension.ContentGate.Client.GalleryViews;
using AXtension.ContentGate.Client.MSAL;
using System;

namespace UploadContentService
{
    class ContentGateClientFactory : IDisposable
    {
        private readonly ContentGateClient _contentGateClient;

        public ContentGateClientFactory()
        {
            // the base uri that references the Content Gate tenant.
            var baseUrl = new Uri("## TENANT ##"); // fill in the tenant. (e.g. https://axtension.content-gate.com)

            // the client id of the app registered in the tenant.
            var clientId = "## CLIENT ID##"; // fill in the client id here. (e.g. 1bd5690d-2902-4400-b7bb-d292691e6323)

            // the authority that ContentGate belongs to, and accepts signed tokens of.
            var authority = "## AUTHORITY ##"; // fill in the authority here. (e.g. https://login.microsoftonline.com/axtension.com)

            // for device authentication, simply use the default console output to instruct the user
            // how to authenticate.
            var deviceCodeAuthenticator = DeviceAuthentication.Console;

            // construct the client.
            this._contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator));
        }

        public QueryClient GetQueryClient() 
            => _contentGateClient.Queries;

        public GalleryViewsClient GetGalleryViewClient()
           => _contentGateClient.GalleryViews;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // by disposing the client, login credentials are also gone.
                this._contentGateClient.Dispose();
            }
        }
    }
}