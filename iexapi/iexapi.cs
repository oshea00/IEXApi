using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        List<IEXPriceHistoryItem> LoadPriceHistory(string ticker, string range)
        {
            var client = new WebClient();
            var urlstring = $"{ApiUrl}/stock/{ticker}/chart/{range}?token={ApiToken}";
            var uri = new Uri(urlstring);
            var pricedata = client.DownloadString(uri);
            var prices = new List<IEXPriceHistoryItem>();
            var items = JArray.Parse(pricedata);
            foreach (JObject item in items.Children())
            {
                prices.Add(item.ToObject<IEXPriceHistoryItem>());
            }
            return prices;
        }

    }
}
