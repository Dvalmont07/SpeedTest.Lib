using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SpeedTest.Lib
{
    public class DownloadSpeedTest : SpeedTestAbstract
    {
       

        /// <summary>
        /// Receaves the file path to be downloaded. Ex https://exemple.com.br/download_directory/
        /// The directory must contain the files to be downloaded
        /// </summary>
        /// <param name="filePath"></param>
        public DownloadSpeedTest(string filePath)
        {
            fileUri = filePath;
        }
        public override List<FileToProcess> PrepareFiles()
        {
            List<FileToProcess> output = new List<FileToProcess>
            {
                new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX1.tmp"),TempFile=baseLocalUri+"\\tempfileX1.tmp"},
                new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX2.tmp"),TempFile=baseLocalUri+"\\tempfileX2.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX3.tmp"),TempFile=baseUri+"\\tempfileX3.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX4.tmp"),TempFile=baseUri+"\\tempfileX4.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX5.tmp"),TempFile=baseUri+"\\tempfileX5.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX6.tmp"),TempFile=baseUri+"\\tempfileX6.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri+"tempfileX7.tmp"),TempFile=baseUri+"\\tempfileX7.tmp"},
            };

            return output;
        }
        /// <summary>
        /// Perform the downlod of the files from host
        /// </summary>
        /// <param name="fileToProcess"></param>
        public override void ExecuteAction(FileToProcess fileToProcess)
        {
            try
            {

                using (WebClient wClient = new WebClient())
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    wClient.DownloadFile(fileToProcess.FileToProcessUri, fileToProcess.TempFile);
                    sw.Stop();
                    AddValuesToList(fileToProcess, sw);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
