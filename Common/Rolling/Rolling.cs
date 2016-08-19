using System;
using System.IO;

namespace Common.Rolling
{
    public class Rolling
    {
        public string RollLogFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appName = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
            string wildLogName = string.Format("{0}*.log", appName);

            int fileCounter = 0;
            string[] logFileList = Directory.GetFiles(path, wildLogName, SearchOption.TopDirectoryOnly);
            if (logFileList.Length > 0)
            {
                Array.Sort(logFileList, 0, logFileList.Length);
                fileCounter = logFileList.Length - 1;
                if (logFileList.Length > 25000000)
                {
                    File.Delete(logFileList[0]);
                    for (int i = 1; i < logFileList.Length; i++)
                    {
                        File.Move(logFileList[i], logFileList[i - 1]);
                    }
                    --fileCounter;
                }

                string currFilePath = logFileList[fileCounter];
                FileInfo f = new FileInfo(currFilePath);
                if (f.Length < 25000000)
                {
                    return currFilePath;
                }
                else
                {
                    ++fileCounter;
                }

            }
            return string.Format("{0}{1}{2}{3:00}.log", path, Path.DirectorySeparatorChar, appName, fileCounter);
        }
    }
}
