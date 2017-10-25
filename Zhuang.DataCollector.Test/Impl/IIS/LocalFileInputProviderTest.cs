using System;
using System.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zhuang.DataCollector.Impl.IIS;

namespace Zhuang.DataCollector.Test.Impl.IIS
{
    [TestClass]
    public class LocalFileInputProviderTest
    {
        [TestMethod]
        public void TestGetData()
        {
            var localFileInputProvider = new LocalFileInputProvider(@"C:\inetpub\logs\LogFiles\W3SVC8\u_ex170920.log");

            var data = localFileInputProvider.GetData();

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
