using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector.Providers
{
    public interface IInputProvider
    {
        IList<Dictionary<string, Object>> ReadData(string path, ref long cursor);
    }

}
