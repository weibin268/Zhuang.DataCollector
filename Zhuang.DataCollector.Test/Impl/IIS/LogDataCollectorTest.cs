using System;
using System.Media;
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
            var path = @"C:\inetpub\logs\LogFiles\W3SVC8\u_ex170920.log";

            logDataCollector.Collect(path);
        }
    }
}
