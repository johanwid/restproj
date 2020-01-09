using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using logger;

namespace model
{
    public class Model : IModel
    {
        String _ticker;
        String _timeSeries;
        Double _callPrice;
        Double _optionTimeExpiry;
        Double _currentStockPrice;
        Double _optionStrikePrice;
        ILogger _logger;
        Dictionary<String, String> _output = new Dictionary<String, String>();

        public Model(ILogger logger)
        {
            this._logger = logger;
        }

        public void GetPrices()
        {
            this._logger.Log("Getting prices");
            AlphaVantageApiHandler alphaVantageHandler = AlphaVantageApiHandlerFactory.Build(_ticker, _timeSeries);
            this._currentStockPrice = alphaVantageHandler.GetPrice();
            this._logger.Log("Prices received");
        }

        public void GetSentiment()
        {
        }

        public void Calculate()
        {
            this._logger.Log("Calculating Black-Scholes");
            BlackScholes bs = new BlackScholes();
            double riskFreeRate = 0.01;
            double volatility = 0.30;
            this._callPrice = bs.CallPrice(this._currentStockPrice, this._optionStrikePrice, riskFreeRate, volatility, this._optionTimeExpiry);
            this._logger.Log("Black-Scholes calculated");
        }

        public void GetInputData(Dictionary<String, String> input)
        {
            this._logger.Log("Getting inputs");
            this._ticker = input["Ticker"];
            this._timeSeries = input["TimeSeries"];
            this._optionStrikePrice = Double.Parse(input["OptionStrikePrice"]);
            this._optionTimeExpiry = Double.Parse(input["OptionTimeExpiry"]);
            this._logger.Log("Inputs received");
        }

        public void ConstructOutput()
        {
            this._output.Add("Ticker", this._ticker);
            this._output.Add("CurrentStockPrice", this._currentStockPrice.ToString());
            this._output.Add("CallPrice", this._callPrice.ToString());
            // this._output.Add("PriceHistory");
        }

        public Dictionary<String, String> GetOutput()
        {
            this._logger.Log("Sending output");
            return this._output;
        }

        public void Start(Dictionary<String, String> data)
        {
            GetInputData(data);
            GetPrices();
            Calculate();
            ConstructOutput();
        }
    }
}