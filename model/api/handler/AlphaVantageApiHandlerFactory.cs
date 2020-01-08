using System;

namespace model
{
    public class AlphaVantageApiHandlerFactory
    {
        public static AlphaVantageApiHandler Build(String ticker, String timeSeries)
        {
            switch (timeSeries)
            {
                case "INTRADAY":
                    return new IntraDayHandler(ticker);
                case "DAILY":
                    return new DailyHandler(ticker);
                case "WEEKLY":
                    return new WeeklyHandler(ticker);
                default:
                    return null;
            }
        }
    }
}