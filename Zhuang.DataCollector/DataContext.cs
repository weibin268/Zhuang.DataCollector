using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector
{
    public class DataContext
    {
        public IDataCollector DataCollector { get; set; }

        public Dictionary<string, object> DataItem { get; set; }

    }
}
