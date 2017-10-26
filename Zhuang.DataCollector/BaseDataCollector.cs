using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector;
using Zhuang.DataCollector.Models;
using Zhuang.DataCollector.Services;

namespace Zhuang.DataCollector
{
    public class BaseDataCollector : IDataCollector
    {
        private IInputProvider _inputProvider;

        private IOutputProvider _outputProvider;

        private IDataCollectorService _dataCollectorService;

        private IDataItemHandler _dataItemHandler;

        public BaseDataCollector(IInputProvider inputProvider, IOutputProvider outputProvider, IDataCollectorService dataCollectorService)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _dataCollectorService = dataCollectorService;
        }

        public void Collect(string path)
        {
            var readDataContext = new ReadDataContext();
            
            var readDataLog = _dataCollectorService.GetReadDataLogByDataPath(path);

            if (readDataLog != null)
            {
                readDataContext.CursorPosition = readDataLog.CursorPosition;
                readDataLog.RuleText = readDataLog.RuleText;
            }

            var rawData = _inputProvider.ReadData(path, readDataContext);

            _dataCollectorService.SaveReadDataLog(new Sys_ReadDataLog()
            {
                DataPath = path,
                CursorPosition = readDataContext.CursorPosition,
                RuleText = readDataContext.RuleText
            });

            Console.WriteLine(readDataContext.CursorPosition);

            IList<Dictionary<string, object>> newData = new List<Dictionary<string, object>>();

            foreach (var item in rawData)
            {
                var handleResult = true;
                if (_dataItemHandler != null)
                {
                    handleResult = _dataItemHandler.Handle(new DataItemContext() { DataCollector = this, DataItem = item });
                }
                if (handleResult)
                {
                    newData.Add(item);
                }
            }

            _outputProvider.WriteData(newData);

        }

        public void SetDataItemHandler(IDataItemHandler dataHandler)
        {
            _dataItemHandler = dataHandler;
        }
    }
}
