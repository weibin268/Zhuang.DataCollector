using System;
using System.Media;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.DataCollector.Impl.IIS;

namespace Zhuang.DataCollector.Test.Impl.IIS
{
    [TestClass]
    public class LogDataCollectorTest
    {
        [TestMethod]
        public void TestCollect()
        {
            LogDataCollector logDataCollector = new LogDataCollector();

            //var path = @"D:\BC2BING-G7LLGSN-Server_D20171025-011752061.log";
            //var path = @"D:\BC2BING-G7LLGSN-Server_D20171101-085816906.log";
            var path = @"D:\BC2BING-G7LLGSN-Server_D20171102-010546956.log";

            logDataCollector.Collect(path);

        }

        [TestMethod]
        public void Test()
        {
            string dataItem = "a \"b b\" \"cc\"";
            var matches = Regex.Matches(dataItem, "((?<=\\s)|^)\"[^\"]+\"((?=\\s)|$)");

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

        }

       
    }
}
