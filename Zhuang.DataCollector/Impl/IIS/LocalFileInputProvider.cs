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

        public IList<Dictionary<string, object>> ReadData(string path, ref long cursor)
        {
            var result = new List<Dictionary<string, object>>();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var sr = new StreamReader(fs))
            {
                fs.Seek(cursor, SeekOrigin.Begin);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("#Fields:"))
                    {
                        DataItemParser.SetParseRule(line);
                    }

                    if (line.StartsWith("#"))
                    {
                        continue;
                    }

                    var dicItem = DataItemParser.Parse(line);

                    result.Add(dicItem);

                }

                cursor = fs.Position;
            }

            return result;
        }

        public IDataItemParser DataItemParser
        {
            get { return _dataItemParser; } 
        }
    }
}
