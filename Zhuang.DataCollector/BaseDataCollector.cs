using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector;

namespace Zhuang.DataCollector
{
    public class BaseDataCollector : IDataCollector
    {
        private IInputProvider _inputProvider;

        private IOutputProvider _outputProvider;

        private IDataItemHandler _dataItemHandler;

        public BaseDataCollector(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }
        
        public void Collect(string path)
        {
            long cursor = 0;

            var rawData = _inputProvider.ReadData(path, ref cursor);
            
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
