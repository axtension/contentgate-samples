using AXtension.ContentGate.Client.BusinessEntities;
using System;
using System.Threading.Tasks;

namespace UploadContentService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Create the client factory.
                var clientFactory = new ContentGateClientFactory();

                // Get the query client.
                var queryClient = clientFactory.GetQueryClient();

                // Get the gallery views client.
                var viewClient = clientFactory.GetGalleryViewClient();

                // Initialize external business entity reference.
                var providerReferenceId = "DYNS2";
                var externalType = "Customers";
                var externalId = "CustomerAccount='US-023',dataAreaId='usmf'";
                var externalRef = new BusinessEntityExternalRef(providerReferenceId, externalType, externalId);

                // Initialize internal business entity reference.
                var internalId = 9;
                var directRef = new BusinessEntityDirectRef(internalId);

                // Get the Gallery View.
                var galleryView = await viewClient.GetGalleryViewAsync(19);

                // Get data from specific view (GalleryViewId or GalleryView object).
                var viewIdResult = await queryClient.ExecuteQueryAsync(externalRef, 4);
                var viewResult = await queryClient.ExecuteQueryAsync(directRef, galleryView);

                // Get data from context.
                var contextExternalResult = await queryClient.ExecuteQueryAsync(externalRef);
                var contextDirectResult = await queryClient.ExecuteQueryAsync(directRef);

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
