using System;
using Newtonsoft.Json.Linq;

namespace model
{
    public class DailyHandler : AlphaVantageApiHandler
    {
        String _ticker;
        JObject _data;

        public DailyHandler(String ticker) : base(ticker)
        {
            this._ticker = ticker;
            ConstructUrl("DAILY");
            this._data = GetJson("Time Series (Daily)");
        }
    }
}