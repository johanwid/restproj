using System;

namespace model
{
    public class Option
    {
        double _strikePrice;

        DateTime _dateExpiry;

        public Option(double strikePrice, DateTime dateExpiry)
        {
            this._strikePrice = strikePrice;
            this._dateExpiry = dateExpiry;
        }

        // T - t: time to maturity
        // S_t: spot price (current price of underlying stock)
        // K: strike price (price option can be exercised)
        // r: risk free rate
        // v: volatility
    }
}