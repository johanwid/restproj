using System;
using System.Collections.Generic;
using logger;

namespace view
{
    class View : IView
    {
        ILogger _logger;
        Dictionary<String, String> _data = new Dictionary<String, String>();

        public View(ILogger logger)
        {
            this._logger = logger;
        }

        public void Start()
        {
            GetTicker();
            GetTimeSeries();
            GetOptionStrikePrice();
            GetOptionExpiry();
        }

        public void GetTicker()
        {
            _logger.Log("Getting ticker");
            String ticker;
            Console.Write("Input ticker: ");
            ticker = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine("Ticker selected: " + ticker);
            _logger.Log("Ticker inputted");
            this._data.Add("Ticker", ticker);
        }

        public void GetTimeSeries()
        {
            _logger.Log("Getting time series");
            String timeSeries;
            Console.Write("Input ticker (Intraday, Daily, Weekly): ");
            timeSeries = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine("Time series selected: " + timeSeries);
            _logger.Log("Time series inputted");
            this._data.Add("TimeSeries", timeSeries);
        }

        public void GetOptionStrikePrice()
        {
            _logger.Log("Getting option data");
            String optionStrikePrice;
            Console.Write("Input option strike price: ");
            optionStrikePrice = Console.ReadLine().Trim();
            Console.WriteLine("Strike price: " + optionStrikePrice);
            _logger.Log("Strike price inputted");
            this._data.Add("OptionStrikePrice", optionStrikePrice);
        }

        public void GetOptionExpiry()
        {
            _logger.Log("Getting option time to expiration");
            String optionTimeExpiry;
            Console.Write("Input option time to expiration (in years): ");
            optionTimeExpiry = Console.ReadLine().Trim();
            Console.WriteLine("Time to expiration: " + optionTimeExpiry + " year(s)");
            _logger.Log("Time to expiration inputted");
            this._data.Add("OptionTimeExpiry", optionTimeExpiry);
        }

        public Dictionary<String, String> GetData()
        {
            _logger.Log("Sending inputs");
            return this._data;
        }

        public void Finish(Dictionary<String, String> output)
        {
            this._logger.Log("Output received");
            Console.WriteLine("---Results---");
            Console.WriteLine("Ticker: " + output["Ticker"]);
            Console.WriteLine("Current stock price: " + output["CurrentStockPrice"]);
            Console.WriteLine("Calculated call price: " + output["CallPrice"]);
            this._logger.CloseLog();
        }
    }
}