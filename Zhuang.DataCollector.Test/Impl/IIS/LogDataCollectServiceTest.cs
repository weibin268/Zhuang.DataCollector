using System;
using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.DataCollector.Impl.IIS;

namespace Zhuang.DataCollector.Test.Impl.IIS
{
    [TestClass]
    public class LogDataCollectServiceTest
    {

        [TestMethod]
        public void TestCollect()
        {

            LogDataCollectService logDataCollectService=new LogDataCollectService();

            logDataCollectService.Collect();

        }
    }
}
