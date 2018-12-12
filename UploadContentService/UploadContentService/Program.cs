using System;

namespace UploadContentService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var uploader = new ContentUploadService())
                {
                    var directory = @"c:\temp\contentgate-uploads";
                    var watch = new ContentWatcher(directory);

                    uploader.StartUpload(watch);

                    Console.WriteLine("Press enter to stop watching ...");
                    Console.ReadLine();

                    uploader.StopUpload();
                }
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
