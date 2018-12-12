using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UploadContentService
{
    class ContentWatcher
    {
        private bool _running;
        private string _directory;
        public event EventHandler<string> FileFound;

        protected virtual void OnFileFound(string file)
            => FileFound?.Invoke(this, file);

        public ContentWatcher(string directory)
        {
            this._directory = directory;
        }

        public void StartWatch()
        {
            if (!this._running)
            {
                // watch a directory for files.
                Task.Factory.StartNew(() =>
                {
                    this._running = true;
                    RunWatch();
                }).Wait();
            }
        }

        public void StopWatch()
        {
            this._running = false;
        }

        private void RunWatch()
        {
            // adjust this loop to find files that have been added, or remove files that are 
            // already processed.
            while(this._running)
            {
                var files = Directory.GetFiles(this._directory);

                if (files?.Length == 0)
                {
                    // check again in the next second.
                    Thread.Sleep(1000);
                }
                else
                {
                    foreach(var f in files)
                    {
                        // stop if no longer running.
                        if (!this._running)
                            break;

                        // raise the event.
                        OnFileFound(f);
                    }
                }
            }
        }
    }
}
