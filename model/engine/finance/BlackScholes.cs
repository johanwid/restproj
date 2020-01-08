using System;

namespace model
{
    class BlackScholes
    {
        // https://introcs.cs.princeton.edu/python/21function/blackscholes.py.html

        // T - t: time to maturity
        // S_t: spot price (current price of underlying stock)
        // K: strike price (price option can be exercised)
        // r: risk free rate
        // v: volatility (sigma)

        // public double Phi(double )
        // {

        // }

        public double ProbabilityDensityFunction(double val, double mu = 0.0, double sigma = 1.0)
        {
            return PhiNot((val - mu) / sigma) / sigma;
        }

        public double PhiNot(double val)
        {
            return Math.Exp(-1 * val * val / 2.0) / Math.Sqrt(2.0 * Math.PI);
        }

        public double PhiOne(double val)
        {
            if (val < -8.0) return 0.0;
            if (val > 8.0) return 1.0;
            double total = 0.0;
            double hold = val;
            double i = 3;
            while (total != total + hold)
            {
                total += hold;
                hold *= val * val / i;
                i += 2;
            }
            return 0.5 + total * PhiNot(val);
        }

        public double NormalDistribution(double val, double mu = 0.0, double sigma = 1.0)
        {
            return PhiOne((val - mu) / sigma);
        }

        public double CallPrice(double sharePrice, double strikePrice, double riskRate, double volatility, double timeExpiry)
        {
            double numerator = (Math.Log(sharePrice / strikePrice) + (riskRate + volatility * volatility / 2.0) * timeExpiry);
            double denominator = volatility * Math.Sqrt(timeExpiry);
            double a = numerator / denominator;
            double b = a - volatility * Math.Sqrt(timeExpiry);
            return sharePrice * NormalDistribution(a) - strikePrice * Math.Exp(-1 * riskRate * timeExpiry) * NormalDistribution(b);
        }
    }
}