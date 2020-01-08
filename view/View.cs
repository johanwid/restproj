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
            GetOption();
        }

        public void GetTicker()
        {
            _logger.Log("Getting ticker");
            string ticker;
            Console.Write("Input ticker: ");
            ticker = Console.ReadLine().ToUpper();
            Console.WriteLine("Ticker selected: " + ticker);
            this._data.Add("Ticker", ticker);
        }

        public void GetTimeSeries()
        {
            _logger.Log("Getting time series");
            string timeSeries;
            Console.Write("Input ticker (Intraday, Daily, Weekly): ");
            timeSeries = Console.ReadLine().ToUpper();
            Console.WriteLine("Ticker selected: " + timeSeries);
            this._data.Add("TimeSeries", timeSeries);
        }

        public void GetOption()
        {

        }

        public Dictionary<String, String> GetData()
        {
            return this._data;
        }

        public void Finish(Dictionary<String, String> output)
        {
            this._logger.Log("Output received");
        }
    }
}