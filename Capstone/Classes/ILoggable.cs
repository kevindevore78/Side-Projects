using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public interface ILoggable
    {
        public string logFile { get; set; }

        public void Log()
        {
            try
            {
                using(StreamWriter write = new StreamWriter(this.logFile))
                {

                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
