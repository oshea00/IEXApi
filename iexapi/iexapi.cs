using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using iexapi.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace iexapi
{
    public class IEXApi : HttpClient
    {
        private string ApiToken { get; }

        public IEXApi(string apiurl, string apitoken) : base()
        {
            var baseUrl = (apiurl.Last() != '/') ? apiurl + "/" : apiurl;
            this.BaseAddress = new Uri(baseUrl);
            ApiToken = apitoken;
        }

        public async Task<List<IEXPriceHistoryItem>> GetPriceHistoryAsync(string ticker, string range)
        {
            var result = await GetStringAsync($"stock/{ticker}/chart/{range}?token={ApiToken}");
            var prices = new List<IEXPriceHistoryItem>();
            var items = JArray.Parse(result);
            foreach (JObject item in items.Children())
            {
                prices.Add(item.ToObject<IEXPriceHistoryItem>());
            }
            return prices;
        }

        public List<IEXPriceHistoryItem> GetPriceHistory(string ticker, string period)
        {
            var promise = GetPriceHistoryAsync(ticker, period);
            promise.Wait();
            return promise.Result;
        }

        public async Task<List<IEXNews>> GetNewsAsync(string ticker, int count)
        {
            var result = await GetStringAsync($"stock/{ticker}/news/last/{count}?token={ApiToken}");
            var news = new List<IEXNews>();
            foreach (JObject item in JArray.Parse(result).Children())
            {
                news.Add(item.ToObject<IEXNews>());
            }
            return news;
        }

        public List<IEXNews> GetNews(string ticker, int count)
        {
            var promise = GetNewsAsync(ticker, count);
            promise.Wait();
            return promise.Result;
        }

        public async Task<List<IEXSymbol>> GetSymbolsAsync()
        {
            var result = await GetStringAsync($"ref-data/symbols?token={ApiToken}");
            var symbols = new List<IEXSymbol>();
            var items = JArray.Parse(result);
            foreach (JObject item in items)
            {
                symbols.Add(item.ToObject<IEXSymbol>());
            }
            return symbols;
        }

        public List<IEXSymbol> GetSymbols()
        {
            var promise = GetSymbolsAsync();
            promise.Wait();
            return promise.Result;
        }

        public async Task<IEXAdvancedStats> GetAdvancedStatsAsync(string ticker)
        {
            var urlstring = $"stock/{ticker}/advanced-stats?token={ApiToken}";
            var data = await GetStringAsync(urlstring);
            var stats = JObject.Parse(data).ToObject<IEXAdvancedStats>();
            stats.Symbol = ticker.ToUpper();
            return stats;
        }

        public IEXAdvancedStats GetAdvancedStats(string ticker)
        {
            var promise = GetAdvancedStatsAsync(ticker);
            promise.Wait();
            return promise.Result;
        }
    }
}
