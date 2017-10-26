using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Zhuang.DataCollector
{
    public interface IOutputProvider
    {
        void WriteData(IList<Dictionary<string,object>> data);
    }
}
