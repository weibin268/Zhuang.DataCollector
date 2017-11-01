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
                var arrDirs = dirs.Split(';');

                foreach (var dir in arrDirs)
                {
                    if(string.IsNullOrEmpty(dir)) continue;

                    if (dir.Trim().StartsWith(@"\\"))
                    {
                        var netInfo = dir.Split(':');

                        if(netInfo.Length!=2)
                            throw new Exception(string.Format("配置项“Zhuang.DataCollector.IIS.LogDirs”格式有误！"));

                        var netPath = netInfo[0];
                        var netUserInfo = netInfo[1].Split(' ');

                        if (netUserInfo.Length!=2)
                            throw new Exception(string.Format("配置项“Zhuang.DataCollector.IIS.LogDirs”格式有误！"));
                        
                        var netUsername = netUserInfo[0];
                        var netPasswrod = netUserInfo[1];
                        FileUtil.ConnectShared(netPath, netUsername, netPasswrod);

                        result.Add(netPath);
                    }
                    else
                    {
                        result.Add(dir);
                    }
                }
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
