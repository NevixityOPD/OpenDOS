using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDOS.IntegratedSoftware.FileManager
{
    public class FileManager
    {
        public List<Content> contents = new List<Content>();

        public FileManager()
        {
            Console.Clear();
            Log.Log.ShowLog("Retrieaving content on current directory. Disclaimer this file manager is kinda slow", Log.LogWarningLevel.Information);
        }

        public void Start()
        {
            
        }

        private void RetrieavingContent(string path)
        {
            string[] files = Directory.GetFiles(Kernel.currentDir);
            string[] dirs = Directory.GetDirectories(Kernel.currentDir);

            foreach (string file in files)
            {
                contents.Add(new Content()
                {
                    contentName = file,
                    contentPath = $@"{Kernel.currentDir}\{file}",
                    contentType = ContentType.Files,
                });
            }

            foreach (string dir in dirs)
            {
                contents.Add(new Content()
                {
                    contentName = dir,
                    contentPath = $@"{Kernel.currentDir}\{dir}",
                    contentType = ContentType.Directory,
                });
            }
        }
    }
}
