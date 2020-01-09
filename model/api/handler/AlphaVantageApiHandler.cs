using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace model
{
    public class AlphaVantageApiHandler
    {
        String _key = "VL1S48SRTAXKY9W1";
        String _ticker;
        String _url;
        JObject _data;

        public AlphaVantageApiHandler(String ticker)
        {
            this._ticker = ticker;
        }

        public String GetTicker()
        {
            return this._ticker;
        }

        public String GetUrl()
        {
            return this._url;
        }

        public void GetJson(String timeSeriesDesignation)
        {
            using (WebClient wc = new WebClient())
            {
                var jsonString = wc.DownloadString(this._url);
                JObject json = JObject.Parse(jsonString);
                this._data = (JObject)json[timeSeriesDesignation];
            }
        }

        public JObject GetData()
        {
            return this._data;
        }

        public Double GetPrice()
        {
            Double closingPrice;
            String hmm;
            JToken recent = _data.First;
            JObject hold = new JObject();
            hold.Add(recent);
            foreach (JProperty prop in hold.Properties())
            {
                hmm = (String)prop.Value["4. close"];
                closingPrice = Double.Parse(hmm);
                return closingPrice;
            }
            return 0.00;
        }

        public void ConstructUrl(String timeSeries, String datatype = "json")
        {
            String url = "https://www.alphavantage.co/query?";
            url += "function=";
            url += "TIME_SERIES_";
            url += timeSeries;
            url += "&symbol=";
            url += _ticker;
            url += "&interval=";
            url += "1min";
            url += "&apikey=";
            url += _key;
            url += "&datatype=";
            url += datatype; // csv or json
            this._url = url;
        }
    }
}
