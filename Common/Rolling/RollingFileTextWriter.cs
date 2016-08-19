using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Common.Rolling
{
    public class RollingFileTextWriter : IRollingFileTextWriter
    {
        private string _path;
        private string _fileName;

        public long RollingSize { get; set; }

        public string FileRollingSeperator { get; set; }

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
                        throw new Exception("Path'de uygunsuz içerik");
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
                    throw new ArgumentNullException("Dosya adı boş olmamalıdır.");
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
            RollingSize = 10000000;
            FileRollingSeperator = "_";
        }

        private string FullFileName
        {
            get
            {
                return System.IO.Path.Combine(Path, FileName);
            }
        }

        private string CurrentFileName { get; set; }


        public async Task RollLogFile(string content)
        {
            if (File.Exists(FullFileName))
            {
                var fileInfo = new FileInfo(FullFileName);
                if (fileInfo.Length >= RollingSize)
                {
                    var extension = System.IO.Path.GetExtension(FullFileName);
                    var fileName = FullFileName.Replace("." + extension, "");
                    fileName = $"{fileName}{FileRollingSeperator}{DateTime.Now.ToString("ssmmhhddMMyyyy")}.{extension}";
                    CurrentFileName = fileName;
                }
                else
                {
                    CurrentFileName = FullFileName;
                }
            }
            else
            {
                using (var fileStream = File.Create(FullFileName))
                {
                    CurrentFileName = FullFileName;
                }
            }
            var streamWriter = File.AppendText(CurrentFileName);
            await streamWriter.WriteLineAsync(content);
        }
    }
}
