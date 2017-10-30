using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector.Utility
{
    public static class FileUtil
    {
        public static IList<string> GetLogFiles(string dirPath)
        {
            var result=new List<string>();

            var files = Directory.GetFiles(dirPath,"*.log",SearchOption.AllDirectories);

            result.AddRange(files);

            //var dirs = Directory.GetDirectories(dirPath);

            //foreach (var dir in dirs)
            //{
            //    var tempFiles = GetAllFiles(dir);
            //    result.AddRange(tempFiles);
            //}

            return result;

        }

        public static IList<string> GetTodayLogFiles(string dirPath)
        {
            var files = GetLogFiles(dirPath);

            var dateInfo = DateTime.Now.ToString("yyyyMMdd");

            dateInfo = dateInfo.Substring(2, dateInfo.Length - 2);

            return files.Where(c =>
            {
                var fileName = Path.GetFileName(c);
                return fileName != null && fileName.Contains(dateInfo);
            }).ToList();
        }
    }
}
