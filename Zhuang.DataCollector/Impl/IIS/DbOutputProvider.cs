using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.Data;
using Zhuang.DataCollector;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class DbOutputProvider:IOutputProvider
    {

        public void WriteData(IList<Dictionary<string, object>> data)
        {
            if (data.Count == 0) return;
   
            foreach (var item in data)
            {
                item.Add("Id", Guid.NewGuid().ToString());
                item.Add("CreatedDate", DateTime.Now);

            }

            var dataItem = data.First();

            var arIISLogFields = new string[]
            {
                "Id","date","time","s_ip","cs_method","cs_uri_stem",
                "cs_uri_query","s_port","cs_username","c_ip",
                "csUser_Agent","csReferer","sc_status","sc_substatus",
                "sc_win32_status","time_taken","CreatedDate"
            };

            var arHasDataFields = dataItem.Keys.Where(c => arIISLogFields.Contains(c)).ToArray();

            string fieldNames = string.Join(",", arHasDataFields);
            string valueNames= "#"+string.Join("#,#", arHasDataFields)+ "#";
            /*
                        string strSql = @"INSERT into Sys_IISLog(Id,date,time,s_ip,cs_method,cs_uri_stem,
                                   cs_uri_query,s_port,cs_username,c_ip,
                                   csUser_Agent,csReferer,sc_status,sc_substatus,
                                   sc_win32_status,time_taken,CreatedDate)
                                    VALUES(#Id#,#date#,#time#,#s_ip#,#cs_method#,#cs_uri_stem#,
                                    #cs_uri_query#,#s_port#,#cs_username#,#c_ip#,
                                    #csUser_Agent#,#csReferer#,#sc_status#,#sc_substatus#,
                                    #sc_win32_status#,#time_taken#,#CreatedDate#);";*/
                                    
            string strSql = string.Format(@"INSERT into Sys_IISLog({0})
            VALUES({1});",fieldNames,valueNames);

            DbAccessor dbAccessor = DbAccessor.Get();
            foreach (var item in data)
            {
                item["CreatedDate"] = DateTime.Now;
                dbAccessor.ExecuteNonQuery(strSql, item);
            }

        }
    }
}
