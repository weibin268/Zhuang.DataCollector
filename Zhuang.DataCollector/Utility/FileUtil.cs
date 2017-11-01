using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector.Utility
{
    public static class FileUtil
    {
        public static IList<string> GetLogFiles(string dirPath)
        {
            var result = new List<string>();

            var files = Directory.GetFiles(dirPath, "*.log", SearchOption.AllDirectories);

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

        public static bool ConnectShared(string path, string username, string password)
        {
            bool result = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = @"net use " + path + " /User:" + username + " " + password + " /PERSISTENT:YES";
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    result = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }

            return result;
        }
    }
}
