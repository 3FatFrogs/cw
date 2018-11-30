using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;


namespace WindowsFormsApp1
{
    static class ParseYahooData
    {
        public class HistoricalStock
        {
            public DateTime Date { get; set; }
            public double Open { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public double Close { get; set; }
            public double Volume { get; set; }
            public double AdjClose { get; set; }
        }

        public class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
        }

        class YahooData
        {
            public IList<string> chart { get; set; }
        }

        public class Pre
        {
            public string timezone { get; set; }
            public int end { get; set; }
            public int start { get; set; }
            public int gmtoffset { get; set; }
        }

        public class Regular
        {
            public string timezone { get; set; }
            public int end { get; set; }
            public int start { get; set; }
            public int gmtoffset { get; set; }
        }

        public class Post
        {
            public string timezone { get; set; }
            public int end { get; set; }
            public int start { get; set; }
            public int gmtoffset { get; set; }
        }

        public class CurrentTradingPeriod
        {
            public Pre pre { get; set; }
            public Regular regular { get; set; }
            public Post post { get; set; }
        }

        public class Meta
        {
            public string currency { get; set; }
            public string symbol { get; set; }
            public string exchangeName { get; set; }
            public string instrumentType { get; set; }
            public int? firstTradeDate { get; set; }
            public int gmtoffset { get; set; }
            public string timezone { get; set; }
            public string exchangeTimezoneName { get; set; }
            public CurrentTradingPeriod currentTradingPeriod { get; set; }
            public string dataGranularity { get; set; }
            public List<string> validRanges { get; set; }
        }

        public class Quote
        {
            public List<double?> volume { get; set; }
            public List<double?> low { get; set; }
            public List<double?> high { get; set; }
            public List<double?> close { get; set; }
            public List<double?> open { get; set; }
        }

        public class Unadjclose
        {
            public List<double?> unadjclose { get; set; }
        }

        public class Unadjquote
        {
            public List<double?> unadjopen { get; set; }
            public List<double?> unadjclose { get; set; }
            public List<double?> unadjhigh { get; set; }
            public List<double?> unadjlow { get; set; }
        }

        public class Adjclose
        {
            public List<double?> adjclose { get; set; }
        }

        public class Indicators
        {
            public List<Quote> quote { get; set; }
            public List<Unadjclose> unadjclose { get; set; }
            public List<Unadjquote> unadjquote { get; set; }
            public List<Adjclose> adjclose { get; set; }

        }

        public class Result
        {
            public Meta meta { get; set; }
            public List<int> timestamp { get; set; }
            public Indicators indicators { get; set; }
        }

        public class Chart
        {
            public List<Result> result { get; set; }
            public object error { get; set; }
        }

        public class RootObject
        {
            public Chart chart { get; set; }
        }

        public static List<HistoricalStock> ParseYahoo(string json2)
        {
            var data = JsonConvert.DeserializeObject<RootObject>(json2);

            var quotesInfo = data.chart.result.First();

            List<HistoricalStock> result = new List<HistoricalStock>();

            for (var i = 0; i < quotesInfo.timestamp.Count; i++)
            {
                HistoricalStock hs = new HistoricalStock();
                var quotesStr = new List<string>();
                var quoteData = quotesInfo.indicators.quote.First();

                hs.AdjClose = (double)(quotesInfo.indicators.adjclose[0].adjclose[i].HasValue ? quotesInfo.indicators.adjclose[0].adjclose[i] : double.NaN);
                hs.Open = (double)(quoteData.open[i].HasValue ? quoteData.open[i] : double.NaN);
                hs.Close = (double)(quoteData.close[i].HasValue ? quoteData.close[i] : double.NaN);
                hs.High = (double)(quoteData.high[i].HasValue ? quoteData.high[i] : double.NaN);
                hs.Low = (double)(quoteData.low[i].HasValue ? quoteData.low[i] : double.NaN);
                hs.Volume = (double)(quoteData.volume[i].HasValue ? quoteData.volume[i] : double.NaN);
                hs.Date = UnixTimeStampToDateTime(quotesInfo.timestamp[i]);
                result.Add(hs);
            }

            return result;
        }

        public static double ToUnixTimestamp(DateTime datetime)
        {
            return (datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }

    }
}
