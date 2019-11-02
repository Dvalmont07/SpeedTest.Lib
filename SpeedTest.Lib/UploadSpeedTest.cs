using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace SpeedTest.Lib
{
    public class UploadSpeedTest : SpeedTestAbstract
    {
        /// <summary>
        /// Receaves the path with the file where we'll upload to. Ex https://exemple.com.br/uploads.php/
        /// The server file (uploads.php or any other language) will do the magic
        /// </summary>
        /// <param name="filePath"></param>
        public UploadSpeedTest(string filePath)
        {
            fileUri = filePath;
        }
        /// <summary>
        /// A list of files previously downloaded to the 'Windows\\Temp' folder
        /// </summary>
        /// <returns></returns>
        public override List<FileToProcess> PrepareFiles()
        {
            List<FileToProcess> output = new List<FileToProcess>
            {

                new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseLocalUri+"\\tempfileX1.tmp"},
                new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseLocalUri+"\\tempfileX2.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX3.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX4.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX5.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX6.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX7.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX8.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX9.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX10.tmp"},
                //new FileToProcess { FileToProcessUri =new Uri( fileUri),TempFile=baseUri+"\\tempfileX11.tmp"},
            };

            return output;
        }
        /// <summary>
        /// Perform the upload of temp files to host
        /// </summary>
        /// <param name="fileToProcess"></param>
        public override void ExecuteAction(FileToProcess fileToProcess)
        {

            try
            {

                using (WebClient wClient = new WebClient())
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    wClient.UploadFile(fileToProcess.FileToProcessUri, "POST", fileToProcess.TempFile);
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
