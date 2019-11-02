using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedTest.Lib
{
  public  class FileToProcess
    {
        public Uri FileUri { get; set; }
        public string TempFile { get; set; }
        public decimal FileSize { get; set; }
        public decimal TimeInMiliseconds { get; set; }
        public decimal Speed { get; set; }

    }
}
