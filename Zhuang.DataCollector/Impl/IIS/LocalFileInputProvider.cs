using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Zhuang.DataCollector;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class LocalFileInputProvider : IInputProvider
    {
        private IDataItemParser _dataItemParser;

        public LocalFileInputProvider()
        {
            _dataItemParser = new LogDataItemParser();
        }

        public IList<Dictionary<string, object>> ReadData(string path, ReadDataContext readDataContext)
        {
            var result = new List<Dictionary<string, object>>();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(fs))
            {
                if (!string.IsNullOrEmpty(readDataContext.RuleText))
                {
                    DataItemParser.SetParseRule(readDataContext.RuleText);
                }

                fs.Seek(readDataContext.CursorPosition, SeekOrigin.Begin);
                
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    if (line.StartsWith("#Fields:"))
                    {
                        DataItemParser.SetParseRule(line);
                        readDataContext.RuleText = line;
                    }

                    if (line.StartsWith("#"))
                    {
                        continue;
                    }

                    var dicItem = DataItemParser.Parse(line);

                    result.Add(dicItem);

                    //Console.WriteLine(line);

                }

                readDataContext.CursorPosition = fs.Position;

                //Console.WriteLine(readDataContext.RuleText);
            }

            return result;
        }

        public IDataItemParser DataItemParser
        {
            get { return _dataItemParser; } 
        }
    }
}
