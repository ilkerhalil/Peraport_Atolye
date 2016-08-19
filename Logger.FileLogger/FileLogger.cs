using System;
using Common.Rolling;
using System.Threading.Tasks;

namespace Logger.FileLogger
{
    public class FileLogger : IFileTextWriter
    {
        public string FileName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Path
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task RollLogFile(string content)
        {
            throw new NotImplementedException();
        }
    }
}
