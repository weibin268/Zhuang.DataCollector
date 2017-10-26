using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.Data;
using Zhuang.DataCollector.Models;

namespace Zhuang.DataCollector.Services
{
    public class DefaultDataCollector : IDataCollectorService
    {
        private DbAccessor _dbAccessor;

        public DefaultDataCollector()
        {
            _dbAccessor = DbAccessor.Get();
        }

        public void SaveReadDataLog(Sys_ReadDataLog model)
        {
            var oldModel = GetReadDataLogByDataPath(model.DataPath);
            if (oldModel == null)
            {
                model.Id = Guid.NewGuid().ToString();
                model.CreatedDate = DateTime.Now;
                _dbAccessor.Insert<Sys_ReadDataLog>(model);
            }
            else
            {
                oldModel.CursorPosition = model.CursorPosition;
                oldModel.RuleText = model.RuleText;
                oldModel.ModifiedDate = DateTime.Now;
                _dbAccessor.Update<Sys_ReadDataLog>(oldModel);
            }
        }

        public Sys_ReadDataLog GetReadDataLogByDataPath(string dataPath)
        {
            string strSql = @"select * from Sys_ReadDataLog where DataPath=#DataPath# order by CreatedDate desc";

            return _dbAccessor.QueryEntity<Sys_ReadDataLog>(strSql, new { DataPath = dataPath });
        }
    }
}
