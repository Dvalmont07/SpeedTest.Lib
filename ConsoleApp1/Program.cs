﻿using Newtonsoft.Json;
using SpeedTest.Lib;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
var path = "Config.json";
            var GetDirectory = Path.GetFullPath(path);

            

            StreamReader r = new StreamReader(path);

            

            var json = r.ReadToEnd();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
          
            r.Close();

            var downloadPath = dict["FileToProcessDownloadUri"];
            var uploadPath = dict["FileToProcessUploadUri"];


            try
            {
                //# Passing the path with the directory where we'll download from
                DownloadSpeedTest downloadSpeedTest = new DownloadSpeedTest(downloadPath);
                //# Passing the path with the file where we'll upload to
                UploadSpeedTest uploadSpeedTest = new UploadSpeedTest(uploadPath);

                Console.WriteLine($"Start{Environment.NewLine}");
                Console.WriteLine("Calculating download speed...");
                Console.WriteLine($"Ping: {downloadSpeedTest.GetPing().ToString()} ms");
                Console.WriteLine(downloadSpeedTest.GetSpeedResult());
                Console.WriteLine("-----");

                Console.WriteLine("Calculating upload speed...");
                Console.WriteLine($"Ping: {uploadSpeedTest.GetPing()} ms");
                Console.WriteLine(uploadSpeedTest.GetSpeedResult());
                Console.WriteLine($"{Environment.NewLine}End");


                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
