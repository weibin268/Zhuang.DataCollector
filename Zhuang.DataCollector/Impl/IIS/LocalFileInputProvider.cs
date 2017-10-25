using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Zhuang.DataCollector.Providers;

namespace Zhuang.DataCollector.Impl.IIS
{
    public class LocalFileInputProvider : IInputProvider
    {
        private string _filePath;

        private IDataItemParser _dataItemParser;

        public LocalFileInputProvider(string filePath)
        {
            _filePath = filePath;

            _dataItemParser=new IISLogDataParser();
        }

        public IList<Dictionary<string, object>> GetData()
        {
            var result=new List<Dictionary<string, object>>();

            using (var fs=new FileStream(_filePath,FileMode.Open,FileAccess.Read))
            using (var sr=new StreamReader(fs))
            {
                string line;
                while ((line = sr.ReadLine())!=null)
                {
                    if (line.StartsWith("#Fields:"))
                    {
                        ((IISLogDataParser)_dataItemParser).SetFieldsInfo(line);
                    }

                    if (line.StartsWith("#"))
                    {
                        continue;
                    }
                    
                    var dicItem =_dataItemParser.Parse(line);

                    result.Add(dicItem);
                }
             }

            return result;
        }
    }
}
