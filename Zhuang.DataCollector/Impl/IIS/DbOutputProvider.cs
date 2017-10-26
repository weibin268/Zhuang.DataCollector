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
            string strSql= @"INSERT into Sys_IISLog(`Id`,`date`,`time`,`s-ip`,`cs-method`,`cs-uri-stem`,
                       `cs-uri-query`,`s-port`,`cs-username`,`c-ip`,
                       `csUser-Agent`,`csReferer`,`sc-status`,`sc-substatus`,
                       `sc-win32-status`,`time-taken`,`CreatedDate`)
                        VALUES(#Id#,#date#,#time#,#s_ip#,#cs_method#,#cs_uri_stem#,
                        #cs_uri_query#,#s_port#,#cs_username#,#c_ip#,
                        #csUser_Agent#,#csReferer#,#sc_status#,#sc_substatus#,
                        #sc_win32_status#,#time_taken#,#CreatedDate#);";

            foreach (var item in data)
            {
                item.Add("Id",Guid.NewGuid().ToString());
                item.Add("CreatedDate",DateTime.Now);
                DbAccessor.Get().ExecuteNonQuery(strSql, item);
            }

        }
    }
}
