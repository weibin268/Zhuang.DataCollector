using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector.Impl.IIS
{
    class IISLogDataParser:IDataItemParser
    {

        private Dictionary<int, string> dicFieldsInfo;

        public IISLogDataParser()
        {

        }

        public Dictionary<string, object> Parse(string strData)
        {

            var result=new Dictionary<string,object>();

            var dataFields = strData.Split(' ');

            for (int i = 0; i < dataFields.Length; i++)
            {
                result.Add(dicFieldsInfo[i], dataFields[i]);
            }

            return result;
        }

        public void SetFieldsInfo(string strFieldsInfo)
        {
            dicFieldsInfo = new Dictionary<int, string>();

            strFieldsInfo = strFieldsInfo.Replace("#Fields: ", "");

            var fieldsInfo = strFieldsInfo.Split(' ');

            for (int i = 0; i < fieldsInfo.Length; i++)
            {
                dicFieldsInfo.Add(i, fieldsInfo[i]);
            }
        }
    }
}
