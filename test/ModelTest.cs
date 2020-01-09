using NUnit.Framework;
using model;
using logger;

namespace test
{
    public class ModelTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01()
        {
            BlackScholes bs = new BlackScholes();
            Assert.AreEqual(bs.CallPrice(23.75, 15.00, 0.01, 0.35, 0.5), 8.879159263714124);
            Assert.AreEqual(bs.CallPrice(30.14, 15.00, 0.01, 0.332, 0.25), 15.177462481558178);

            AlphaVantageApiHandler fakeHandler = AlphaVantageApiHandlerFactory.Build("", "");
            AlphaVantageApiHandler dailyHandler = AlphaVantageApiHandlerFactory.Build("AAPL", "DAILY");
            AlphaVantageApiHandler weeklyHandler = AlphaVantageApiHandlerFactory.Build("AAPL", "WEEKLY");
            AlphaVantageApiHandler intradayHandler = AlphaVantageApiHandlerFactory.Build("AAPL", "INTRADAY");
            Assert.AreEqual(fakeHandler.GetType(), null);
            Assert.AreEqual(dailyHandler.GetType(), typeof(DailyHandler));
            Assert.AreEqual(weeklyHandler.GetType(), typeof(WeeklyHandler));
            Assert.AreEqual(intradayHandler.GetType(), typeof(IntraDayHandler));
            Assert.AreEqual(dailyHandler.GetTicker(), "AAPL");
            Assert.AreEqual(dailyHandler.GetUrl().Length, 124);

            // Database?
        }
    }
}