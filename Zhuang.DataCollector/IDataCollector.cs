using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector
{
    public interface IDataCollector
    {
        void Collect(string path);

        void SetDataItemHandler(IDataItemHandler dataHandler);
    }
}
