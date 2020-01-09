using System;
using Newtonsoft.Json.Linq;

namespace model
{
    public class WeeklyHandler : AlphaVantageApiHandler
    {
        String _ticker;

        public WeeklyHandler(String ticker) : base(ticker)
        {
            this._ticker = ticker;
            ConstructUrl("WEEKLY");
            GetJson("Weekly Time Series");
        }
    }
}