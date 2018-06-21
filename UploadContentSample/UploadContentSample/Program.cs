using AXtension.ContentGate.Client;
using AXtension.ContentGate.Client.Content;
using AXtension.ContentGate.Client.ContentCategories;
using AXtension.ContentGate.Client.StorageProviders;
using System;
using System.Threading.Tasks;

namespace UploadContentSample
{
    class Program
    {
        static void Main(string[] args)
        {
            StartUpload().Wait();

            Console.WriteLine("Done uploading content.");
        }

        static async Task StartUpload()
        {
            // the base uri that references the Content Gate tenant.
            var baseUrl = default(Uri);

            // the client id of the app registered in the tenant.
            var clientId = ""; // fill in the client id here. (e.g. 1bd5690d-2902-4400-b7bb-d292691e6323)

            // the authority that ContentGate belongs to, and accepts signed tokens of.
            var authority = ""; // fill in the authority here. (https://login.microsoftonline.com/axtension.com)

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
                        new BinaryAsset("My Binary Title", "text/plain", @"c:\path\to\binary.txt"),
                        new UriLinkAsset("AXtension home page") { Uri = "http://axtension.com" }
                    },

                    // set the content category that the content will be added to.
                    ContentCategory = new ContentCategoryRef(2),

                    // set the storage provider that will store the content.
                    StorageProvider = new StorageProviderRef("AZBLOB"),

                    // set property values that need to be set.
                    UserProperties =
                    {
                        // user property id and value.
                        (id: 1, value: "Remarks"),
                        // or using the shorthand:
                        (2, DateTime.Now)
                    },

                    // add the connection to one or more business entities.
                    Connections =
                    {
                        // directly linked business entity reference (using Content Gate id)
                        20392,
                        // externally linked business entity reference (using external reference) which means:
                        // business entity connector reference, external type, external id combination
                        ("DYN365", "Customers", "CustomerAccount'US-023',dataAreaId='usmf'")
                    }
                };

                // send the request to Content Gate.
                await contentGateClient.Content.AddContentAsync(addContentArgs).ConfigureAwait(false);
            }
        }
    }
}
