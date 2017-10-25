using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Zhuang.DataCollector.Providers
{
    public interface IOutputProvider
    {
        void SaveData(IList<Dictionary<string,object>> data);
    }
}
