using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zhuang.DataCollector.Providers;

namespace Zhuang.DataCollector
{
    public class BaseDataCollector : IDataCollector
    {

        private IInputProvider _inputProvider;

        private IOutputProvider _outputProvider;

        private IDataHandler _dataHandler;

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
                if (_dataHandler != null)
                {
                    handleResult = _dataHandler.Handle(new DataContext() { DataCollector = this, DataItem = item });
                }
                if (handleResult)
                {
                    newData.Add(item);
                }
            }

            _outputProvider.WriteData(newData);

        }

        public void SetDataHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }
    }
}
