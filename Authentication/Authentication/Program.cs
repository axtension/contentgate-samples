using System;

namespace Authentication
{
    class Program
    {
        static void Main(string[] args)
        {
            // the base uri that references the Content Gate tenant.
            var baseUrl = new Uri("## TENANT ##"); // fill in the tenant. (e.g. https://axtension.content-gate.com)

            // the client id of the app registered in the tenant.
            var clientId = "## CLIENT ID##"; // fill in the client id here. (e.g. 1bd5690d-2902-4400-b7bb-d292691e6323)

            // the authority that ContentGate belongs to, and accepts signed tokens of.
            var authority = "## AUTHORITY ##"; // fill in the authority here. (e.g. https://login.microsoftonline.com/axtension.com)

            try
            {
                // Create a client factory object.
                var clientFactory = new ContentGateClientFactory(baseUrl, clientId, authority);

                // Create the client.
                var contentGateClient = clientFactory.CreateClientWithUserPrompt();
            }
            catch (AggregateException ag)
            {
                if (ag.InnerExceptions.Count == 1)
                    throw ag.InnerException;
                else
                    throw ag.Flatten();
            }
            catch (Exception)
            {
                throw;
            }

            Console.ReadLine();
        }
    }
}
