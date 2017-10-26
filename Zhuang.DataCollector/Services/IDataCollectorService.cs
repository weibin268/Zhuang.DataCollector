using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector.Models;

namespace Zhuang.DataCollector.Services
{
    public interface IDataCollectorService
    {
        void SaveReadDataLog(Sys_ReadDataLog model);

        Sys_ReadDataLog GetReadDataLogByDataPath(string dataPath);
               
    }
}
