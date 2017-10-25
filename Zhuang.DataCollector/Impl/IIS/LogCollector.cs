﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector.Providers;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class LogCollector : BaseDataCollector
    {
        public LogCollector() : base(new LocalFileInputProvider(), new DbOutputProvider())
        {

        }
    }
}
