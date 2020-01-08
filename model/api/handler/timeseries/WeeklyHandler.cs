using System;
using Newtonsoft.Json.Linq;

namespace model
{
    public class WeeklyHandler : AlphaVantageApiHandler
    {
        String _ticker;
        JObject _data;

        public WeeklyHandler(String ticker) : base(ticker)
        {
            this._ticker = ticker;
            ConstructUrl("WEEKLY");
            this._data = GetJson("Weekly Time Series");
        }
    }
}