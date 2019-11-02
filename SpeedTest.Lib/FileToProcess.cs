using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedTest.Lib
{
    public class FileToProcess
    {
        public Uri FileToProcessUri { get; set; }
        public string TempFile { get; set; }
        public long FileSize { get; set; }
        public decimal TimeInMiliseconds { get; set; }
        public decimal TimeInSeconds{ get; set; }
        public decimal Speed { get; set; }
        public double Ping { get; set; }
        public double Jitter { get; set; }


    }
}
