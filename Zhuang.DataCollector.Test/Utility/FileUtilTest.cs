using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.DataCollector.Utility;

namespace Zhuang.DataCollector.Test.Utility
{
    [TestClass]
    public class FileUtilTest
    {
        [TestMethod]
        public void GetLogFiles()
        {
            var files = FileUtil.GetLogFiles(@"C:\inetpub\logs\LogFiles");;

            foreach (var file in files)
            {

                Console.WriteLine(file);
            }
        }

        [TestMethod]
        public void GetTodayLogFiles()
        {
            var files = FileUtil.GetTodayLogFiles(@"C:\inetpub\logs\LogFiles"); ;

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
