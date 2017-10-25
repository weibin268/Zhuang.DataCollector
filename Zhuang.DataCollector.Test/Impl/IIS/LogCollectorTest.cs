using System;
using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.DataCollector.Impl.IIS;

namespace Zhuang.DataCollector.Test.Impl.IIS
{
    [TestClass]
    public class LogCollectorTest
    {
        [TestMethod]
        public void TestCollect()
        {
            LogCollector logCollector = new LogCollector();

            var path = @"C:\inetpub\logs\LogFiles\W3SVC8\u_ex170920.log";

            logCollector.Collect(path);
        }
    }
}
