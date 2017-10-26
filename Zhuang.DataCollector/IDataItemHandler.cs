using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector
{
    public interface IDataItemHandler
    {
        bool Handle(DataItemContext dataContext);
    }
}
