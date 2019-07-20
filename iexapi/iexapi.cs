using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using iexapi.Models;

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

        public async Task<IEXCompanyBalanceSheet> GetBalanceSheetAsync(string ticker)
        {
            IEXCompanyBalanceSheet report = null;
            var response = await GetAsync($"stock/{ticker}/balance-sheet?token={ApiToken}");
            if (response.IsSuccessStatusCode)
            {
                report = await response.Content.ReadAsAsync<IEXCompanyBalanceSheet>();
            }
            return report;
        }

        public IEXCompanyBalanceSheet GetBalanceSheet(string ticker)
        {
            var promise = GetBalanceSheetAsync(ticker);
            promise.Wait();
            return promise.Result;

        }

        public async Task<List<IEXPriceHistoryItem>> GetPriceHistoryAsync(string ticker, string range)
        {
            var result = await GetAsync($"stock/{ticker}/chart/{range}?token={ApiToken}");
            var prices = new List<IEXPriceHistoryItem>();
            if (result.IsSuccessStatusCode)
            {
                var items = await result.Content.ReadAsAsync<List<IEXPriceHistoryItem>>();
                foreach (var item in items)
                {
                    prices.Add(item);
                }
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
            var result = await GetAsync($"stock/{ticker}/news/last/{count}?token={ApiToken}");
            var news = new List<IEXNews>();
            if (result.IsSuccessStatusCode)
            {
                var newsitems = await result.Content.ReadAsAsync<List<IEXNews>>();
                foreach (var item in newsitems)
                {
                    news.Add(item);
                }
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
            var result = await GetAsync($"ref-data/symbols?token={ApiToken}");
            var symbols = new List<IEXSymbol>();
            if (result.IsSuccessStatusCode)
            {
                var items = await result.Content.ReadAsAsync<List<IEXSymbol>>();
                foreach (var item in items)
                {
                    symbols.Add(item);
                }
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
            IEXAdvancedStats stats = null;
            var urlstring = $"stock/{ticker}/advanced-stats?token={ApiToken}";
            var data = await GetAsync(urlstring);
            if (data.IsSuccessStatusCode)
            {
                stats = await data.Content.ReadAsAsync<IEXAdvancedStats>();
                stats.Symbol = ticker.ToUpper();
            }
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
