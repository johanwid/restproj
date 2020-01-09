using System;
using Newtonsoft.Json.Linq;

namespace model
{
    public class DailyHandler : AlphaVantageApiHandler
    {
        String _ticker;

        public DailyHandler(String ticker) : base(ticker)
        {
            this._ticker = ticker;
            ConstructUrl("DAILY");
            GetJson("Time Series (Daily)");
        }
    }
}