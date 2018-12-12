using AXtension.ContentGate.Client;
using AXtension.ContentGate.Client.BusinessEntities;
using AXtension.ContentGate.Client.Content;
using AXtension.ContentGate.Client.ContentCategories;
using AXtension.ContentGate.Client.StorageProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UploadContent
{
    class ContentUploader
    {
        public async Task StartUpload()
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
            using (var contentGateClient = new ContentGateClient(baseUrl, clientId, authority, deviceCodeAuthenticator))
            {
                // construct the upload manifest for uploading content.
                var addContentArgs = new AddContentArgs
                {
                    // add the binary content (or weblink content) that needs to be uploaded.
                    Assets =
                    {
                        // use binary assets to upload files.
                        new BinaryAsset("My Binary Title", "text/plain", @"d:\example1.txt"),

                       // use uri link assets to upload web links.
                       new UriLinkAsset("AXtension home page", "http://axtension.com")
                    },

                    // set the content category that the content will be added to.
                    ContentCategory = new ContentCategoryRef(2),

                    // set the storage provider that will store the content.
                    StorageProvider = new StorageProviderRef("AZBLOB3"),

                    // set property values that need to be set.
                    UserProperties =
                    {
                        // set user property values by adding a user property id and its corresponding value.
                        new UserPropertyValue{ Property = new UserPropertyRef(1), Value = "Remarks" },
                        new UserPropertyValue{ Property = new UserPropertyRef(2), Value = DateTime.Now},
                    },

                    // add the connection to one or more business entities.
                    Connections =
                    {
                        // externally linked business entity reference (using external reference) which means:
                        // business entity connector reference, external type, external id combination
                        BusinessEntityRef.ExternalReference("DYN3652", "Customers", "CustomerAccount='US-027',dataAreaId='usmf'")
                    }
                };

                // send the request to Content Gate.
                await contentGateClient.Content.AddContentAsync(addContentArgs).ConfigureAwait(false);
            }
        }
    }
}
