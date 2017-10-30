using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Zhuang.DataCollector.Utility;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class LogDataCollectService
    {
        private IDataCollector _dataCollector;

        public LogDataCollectService()
        {
            _dataCollector = new LogDataCollector();
        }

        public IList<string> GetLogDirectories()
        {
            var result = new List<string>();

            var dirs = ConfigurationManager.AppSettings["Zhuang.DataCollector.IIS.LogDirs"];

            if (!string.IsNullOrEmpty(dirs))
            {
                result.AddRange(dirs.Split('|'));
            }

            return result;
        }

        public IList<string> GetLogFiles(string dirPath)
        {
            return FileUtil.GetTodayLogFiles(dirPath);
        }

        public void Collect()
        {

            var logDirs = GetLogDirectories();

            foreach (var logDir in logDirs)
            {
                var logFiles = GetLogFiles(logDir);

                foreach (var logFile in logFiles)
                {
                    _dataCollector.Collect(logFile);
                }
            }

        }
    }
}
