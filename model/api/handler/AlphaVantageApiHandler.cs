using System;

namespace handler
{

    class AlphaVantageApiHandler
    {
        string _key; //"VL1S48SRTAXKY9W1"

        string _symbol;

        string _timeseries;

        public AlphaVantageApiHandler(string key)
        {
            this._key = key;
        }

        public void SetSymbol(string symbol)
        {
            this._symbol = symbol;
        }

        public void SetTimeSeries(string timeseries)
        {
            this._timeseries = timeseries;
        }

        public String GetUrl()
        {
            string url = "";
            return url;
        }

        public static void Main()
        {
            Console.WriteLine("howdy");
        }
    }
}
