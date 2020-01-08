using System;
using System.Collections.Generic;
using logger;

namespace model
{
    public class Model : IModel
    {
        String _ticker;
        String _timeSeries;
        String _price;
        ILogger _logger;

        Dictionary<String, String> _output;

        public Model(ILogger logger)
        {
            this._logger = logger;
        }

        public void ParseInput()
        {
            AlphaVantageApiHandler alphaVantageHandler = AlphaVantageApiHandlerFactory.Build(_ticker, _timeSeries);
        }

        public void GetSentiment()
        {
            // search twitter for company ticker and name
        }

        public void Calculate()
        {
            // black scholes ?? need to get option data
        }

        public void ConstructResult()
        {
            // json result
        }

        public void GetData(Dictionary<String, String> input)
        {
            this._ticker = input["Ticker"];
            this._timeSeries = input["TimeSeries"];
            this._logger.Log("Input received: ticker=" + this._ticker + ", time series=" + this._timeSeries);
        }

        public Dictionary<String, String> SendData()
        {
            this._logger.Log("Getting output");
            this._logger.CloseLog();
            return this._output;
        }

        public void Start(Dictionary<String, String> data)
        {
            GetData(data);
            BlackScholes b = new BlackScholes();
            Console.WriteLine(b.CallPrice(23.75, 15.00, 0.01, 0.35, 0.5));
        }
    }
}