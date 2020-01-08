using System;
using Newtonsoft.Json.Linq;

namespace model
{
    public class IntraDayHandler : AlphaVantageApiHandler
    {
        String _ticker;
        JObject _data;

        public IntraDayHandler(String ticker) : base(ticker)
        {
            this._ticker = ticker;
            ConstructUrl("INTRADAY");
            this._data = GetJson("Time Series (1min)");
        }
    }
}