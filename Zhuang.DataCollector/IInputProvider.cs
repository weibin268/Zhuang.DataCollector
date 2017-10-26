using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector
{
    public interface IInputProvider
    {
        IList<Dictionary<string, object>> ReadData(string path, ReadDataContext readDataContext);
        
        IDataItemParser DataItemParser { get;}
    }

}
