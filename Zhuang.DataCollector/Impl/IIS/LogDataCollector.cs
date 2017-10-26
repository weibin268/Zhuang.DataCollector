using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class LogDataCollector : BaseDataCollector
    {
        public LogDataCollector() : base(new LocalFileInputProvider(), new DbOutputProvider())
        {

        }
    }
}
