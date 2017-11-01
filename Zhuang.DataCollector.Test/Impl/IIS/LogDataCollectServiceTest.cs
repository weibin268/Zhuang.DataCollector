using System;
using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.DataCollector.Impl.IIS;
using Zhuang.DataCollector.Utility;

namespace Zhuang.DataCollector.Test.Impl.IIS
{
    [TestClass]
    public class LogDataCollectServiceTest
    {

        [TestMethod]
        public void TestCollect()
        {

            //FileUtil.ConnectShared(@"\\10.201.76.223\AdvancedLogs", "administrator", "gmcc2011!");

            LogDataCollectService logDataCollectService=new LogDataCollectService();

            logDataCollectService.Collect();

        }
    }
}
