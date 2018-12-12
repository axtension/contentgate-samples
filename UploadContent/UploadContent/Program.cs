using System;

namespace UploadContent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uploader = new ContentUploader();

                uploader.StartUpload().Wait();
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
