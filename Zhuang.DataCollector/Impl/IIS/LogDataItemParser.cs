using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class LogDataItemParser : IDataItemParser
    {
        private Dictionary<int, string> _dicFieldsInfo;

        public Dictionary<string, object> Parse(string dataItem)
        {
            var result = new Dictionary<string, object>();

            var dataFields = dataItem.Split(' ');

            if (dataFields.Length != _dicFieldsInfo.Keys.Count) return result;

            for (int i = 0; i < dataFields.Length; i++)
            {
                result.Add(_dicFieldsInfo[i], dataFields[i]);
            }

            return result;
        }

        public void SetParseRule(string ruleText)
        {
            _dicFieldsInfo = new Dictionary<int, string>();

            ruleText = ruleText.Replace("#Fields:", "").Trim();

            var fieldsInfo = ruleText.Split(' ');

            for (int i = 0; i < fieldsInfo.Length; i++)
            {
                var fieldName = fieldsInfo[i];

                fieldName = fieldName.Replace("(", "").Replace(")","").Replace("-","_");

                _dicFieldsInfo.Add(i, fieldName);
            }
        }
    }
}
