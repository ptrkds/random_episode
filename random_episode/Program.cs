using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace random_episode
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = Console.ReadLine();
            
            String[] dirList = Directory.GetDirectories(path);
            
            
            List<String> fileList = new List<string>();


            String[] filesInFirstDir = Directory.GetFiles(path);

            foreach (string file in filesInFirstDir)
            {
                fileList.Add(file);
            }
            
            
            Random rnd = new Random();
            
            foreach (String dir in dirList)
            {
                String[] filesInDir = Directory.GetFiles(dir);
                foreach (string file in filesInDir)
                {
                    fileList.Add(file);
                }
            }

            fileList.RemoveAll(u => u.EndsWith(".nfo"));
            fileList.RemoveAll(u => u.EndsWith(".srt"));
            fileList.RemoveAll(u => u.Contains("sample"));
            fileList.RemoveAll(u => u.EndsWith(".ac3"));

            // Debug
            /*foreach (string file in fileList)
            {
                Console.WriteLine(file);
            }*/
            
            
            int r = rnd.Next(fileList.Count);

            Console.WriteLine(fileList[r]);
            String processStart = "\"C:\\Program Files (x86)\\Webteh\\BSPlayer\\bsplayer.exe\"" + " \"" + fileList[r] + "\"";
            Process.Start(processStart);
        }
    }
}