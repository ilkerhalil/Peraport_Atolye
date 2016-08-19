using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Common.Rolling
{
    public class RollingFileTextWriter : IFileTextWriter
    {
        private string _path;
        private string _fileName;

        public string Path
        {
            get
            {
                return _path;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Path   boş olmamalıdır.");
                }
                var pathInvalidChars = System.IO.Path.GetInvalidPathChars();
                pathInvalidChars.ToList().ForEach(f =>
                {
                    if (value.Contains(f))
                    {
                        throw new System.Exception("Path'de uygunsuz içerik");
                    }
                });
                _path = value;
            }
        }
        public string FileName
        {
            get
            {
                return _fileName;
            }
            private set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Ddosya adı boş olmamalıdır.");
                }
                var fileInvalidChars = System.IO.Path.GetInvalidFileNameChars();
                fileInvalidChars.ToList().ForEach(f =>
                {
                    if (value.Contains(f))
                    {
                        throw new System.Exception("FileName'de uygunsuz içerik");
                    }
                });
                _fileName = value;
            }
        }
        public bool IsAsync { get; set; }

        public RollingFileTextWriter(string path, string fileName)
        {
            //ValidateParameters(path, fileName);
            Path = path;
            FileName = fileName;
        }

        public string FullFileName
        {
            get
            {
                return System.IO.Path.Combine(Path, FileName);
            }
        }

        public async Task RollLogFile(string content)
        {
            using (FileStream fileStream = new FileStream(FullFileName, FileMode.OpenOrCreate))
            {
                FileInfo fileInfo = new FileInfo(FullFileName);
                await fileInfo.AppendText().WriteLineAsync(content);
            }

        }
    }
}
