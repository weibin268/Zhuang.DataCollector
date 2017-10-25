using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector.Providers;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class DbOutputProvider:IOutputProvider
    {
        public void WriteData(IList<Dictionary<string, object>> data)
        {
            throw new NotImplementedException();
        }
    }
}
