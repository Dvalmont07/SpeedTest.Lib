using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace SpeedTest.Lib
{
    public abstract class SpeedTestAbstract
    {

        protected string fileUri;
        protected string baseLocalUri = @"C:\\Windows\\Temp";
        public List<decimal> totalSpeedList;

        /// <summary>
        /// Get the base remote uri to work with Ping class
        /// Ex.: From https:// www.exemple.com/pag1 to www.exemple.com
        /// </summary>
        /// <returns></returns>
        private string GetBaseRemoteUri()
        {
            string baseRemoteUri = fileUri.Replace("https://", "").Replace("http://", "");
            string[] output = baseRemoteUri.Split('/');
            return output[0];
        }
        public SpeedTestAbstract()
        {
            totalSpeedList = new List<decimal>();
        }
        /// <summary>
        /// Return a list of files to download/upload
        /// </summary>
        /// <returns></returns>
        public abstract List<FileToProcess> PrepareFiles();
        /// <summary>
        /// Loops a list of files and delegates the execution to the specialist class
        /// </summary>
        public void RunTest()
        {
            try
            {
                foreach (var item in PrepareFiles())
                {
                    ExecuteAction(item);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Delegates to concrete class the process of dowmload/upload
        /// </summary>
        /// <param name="file"></param>
        public abstract void ExecuteAction(FileToProcess file);
        /// <summary>
        /// Fills the fileToProcess object and add the download/upload speed to the list
        /// </summary>
        /// <param name="fileToProcess"></param>
        /// <param name="sw"></param>
        public void AddValuesToList(FileToProcess fileToProcess, Stopwatch sw)
        {
            FileInfo fileInfo = new FileInfo(fileToProcess.TempFile);

            fileToProcess.FileSize = fileInfo.Length;
            fileToProcess.TimeInMiliseconds = sw.ElapsedMilliseconds;
            fileToProcess.Speed = ((fileToProcess.FileSize) / (fileToProcess.TimeInMiliseconds / 1000));

            totalSpeedList.Add(fileToProcess.Speed);
        }
        /// <summary>
        /// Returns the average of total speed tests
        /// </summary>
        /// <returns></returns>
        public string GetSpeedResult()
        {
            RunTest();
            decimal realValue = (totalSpeedList.Average() / 10240);
            return string.Format("{0:0.00}", realValue) + " Mbps";
        }
        /// <summary>
        /// Return the Ping of the process
        /// </summary>
        /// <returns></returns>
        public long GetPing()
        {
            using (Ping ping = new Ping())
            {
                long roundTrip = ping.Send(GetBaseRemoteUri()).RoundtripTime / 100;

                return roundTrip;
            }
        }
    }
}
