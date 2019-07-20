using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace iexapi.Models
{
    public class IEXAdvancedStats
    {
        public string CompanyName { get; set; }
        public decimal? MarketCap { get; set; }
        public decimal? Week52High { get; set; }
        public decimal? Week52Low { get; set; }
        public decimal? Week52Change { get; set; }
        public decimal? SharesOutstanding { get; set; }
        public decimal? Float { get; set; }
        public string Symbol { get; set; }
        public int? Avg10Volume { get; set; }
        public int? Avg30Volume { get; set; }
        public decimal? Day200MovingAvg { get; set; }
        public decimal? Day50MovingAvg { get; set; }
        public int? Employees { get; set; }
        public decimal? TtmEPS { get; set; }
        public decimal? TtmDividendRate { get; set; }
        public decimal? DividendYield { get; set; }
        public DateTime? NextDividendDate { get; set; }
        public DateTime? ExDividendDate { get; set; }
        public DateTime? NextEarningsDate { get; set; }
        public decimal? PERatio { get; set; }
        public decimal? Beta { get; set; }
        public decimal? MaxChangePercent { get; set; }
        public decimal? Year5ChangePercent { get; set; }
        public decimal? Year2ChangePercent { get; set; }
        public decimal? Year1ChangePercent { get; set; }
        public decimal? YtdChangePercent { get; set; }
        public decimal? Month6ChangePercent { get; set; }
        public decimal? Month3ChangePercent { get; set; }
        public decimal? Month1ChangePercent { get; set; }
        public decimal? Day30ChangePercent { get; set; }
        public decimal? Day5ChangePercent { get; set; }
        public decimal? TotalCash { get; set; }
        public decimal? CurrentDebt { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? GrossProfit { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? EBITDA { get; set; }
        public decimal? RevenuePerShare { get; set; }
        public decimal? RevenuePerEmployee { get; set; }
        public decimal? DebtToEquity { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? EnterpriseValue { get; set; }
        public decimal? EnterpriseValueToRevenue { get; set; }
        public decimal? PriceToSales { get; set; }
        public decimal? PriceToBook { get; set; }
        public decimal? ForwardPERatio { get; set; }
        public decimal? PegRatio { get; set; }
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
}
