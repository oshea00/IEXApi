using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using iexapi.Models;

namespace iexapi
{
    public class IEXApi
    {
        public string ApiUrl { get; }
        public string ApiToken { get; }

        public IEXApi(string apiurl, string apitoken)
        {
            ApiUrl = apiurl;
            ApiToken = apitoken;
        }

        public List<IEXPriceHistoryItem> GetPriceHistory(string ticker, string period)
        {
            return LoadPriceHistory(ticker, period);
        }

        string QueryData(string url)
        {
            var client = new WebClient();
            return client.DownloadString(new Uri(url));
        }

        List<IEXPriceHistoryItem> LoadPriceHistory(string ticker, string range)
        {
            var urlstring = $"{ApiUrl}/stock/{ticker}/chart/{range}?token={ApiToken}";
            var data = QueryData(urlstring);
            var prices = new List<IEXPriceHistoryItem>();
            var items = JArray.Parse(data);
            foreach (JObject item in items.Children())
            {
                prices.Add(item.ToObject<IEXPriceHistoryItem>());
            }
            return prices;
        }

        public IEXAdvancedStats GetAdvancedStats(string ticker)
        {
            var urlstring = $"{ApiUrl}/stock/{ticker}/advanced-stats?token={ApiToken}";
            var data = QueryData(urlstring);
            var stats = JObject.Parse(data).ToObject<IEXAdvancedStats>();
            stats.Symbol = ticker.ToUpper();
            return stats;
        }
    }
}
