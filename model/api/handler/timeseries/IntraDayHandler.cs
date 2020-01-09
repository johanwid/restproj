using System;
using Newtonsoft.Json.Linq;

namespace model
{
    public class IntraDayHandler : AlphaVantageApiHandler
    {
        String _ticker;

        public IntraDayHandler(String ticker) : base(ticker)
        {
            this._ticker = ticker;
            ConstructUrl("INTRADAY");
            GetJson("Time Series (1min)");
        }
    }
}