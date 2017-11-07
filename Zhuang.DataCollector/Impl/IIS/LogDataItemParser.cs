using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Zhuang.DataCollector.Impl.IIS
{

    //((?<=\s)|^)\"[^"]+\"((?=\s)|$)

    public class LogDataItemParser : IDataItemParser
    {

        private const string REGEX_FIELD_VALUE = "((?<=\\s)|^)\"[^\"]+\"((?=\\s)|$)";

        private const string SPACE_REPLACEMENT = "&nbsp;";

        private const string SPACE_CHAR = " ";

        private const char FIELD_SPLIT_CHAR = ' ';

        public const string FIELD_NAMES_ROW_START_MARK = "#Fields:";

        private Dictionary<int, string> _dicFieldsInfo;

        public Dictionary<string, object> Parse(string dataItem)
        {
            var matches = Regex.Matches(dataItem, REGEX_FIELD_VALUE);

            foreach (Match match in matches)
            {
                var newStr = match.Value.Replace(SPACE_CHAR, SPACE_REPLACEMENT);
                dataItem = dataItem.Replace(match.Value, newStr);
            }

            var result = new Dictionary<string, object>();

            var dataFields = dataItem.Split(FIELD_SPLIT_CHAR);

            if (dataFields.Length != _dicFieldsInfo.Keys.Count) return result;

            for (int i = 0; i < dataFields.Length; i++)
            {

                var dataField = dataFields[i];

                dataField = dataField.Replace(SPACE_REPLACEMENT, SPACE_CHAR);

                dataField = dataField.TrimStart('"').TrimEnd('"');

                result.Add(_dicFieldsInfo[i], dataField);
            }

            return result;
        }

        public void SetParseRule(string ruleText)
        {
            _dicFieldsInfo = new Dictionary<int, string>();

            ruleText = ruleText.Replace(FIELD_NAMES_ROW_START_MARK, "").Trim();

            var fieldsInfo = ruleText.Split(FIELD_SPLIT_CHAR);

            for (int i = 0; i < fieldsInfo.Length; i++)
            {
                var fieldName = fieldsInfo[i];

                fieldName = fieldName
                    .Replace("(", "").Replace(")", "")
                    .Replace("-", "_")
                    .Replace("TimeTakenMS", "time_taken");

                _dicFieldsInfo.Add(i, fieldName);
            }
        }
    }
}
