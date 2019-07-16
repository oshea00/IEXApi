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
        public double? MarketCap { get; set; }
        public double? Week52High { get; set; }
        public double? Week52Low { get; set; }
        public double? Week52Change { get; set; }
        public double? SharesOutstanding { get; set; }
        public double? Float { get; set; }
        public string Symbol { get; set; }
        public int? Avg10Volume { get; set; }
        public int? Avg30Volume { get; set; }
        public double? Day200MovingAvg { get; set; }
        public double? Day50MovingAvg { get; set; }
        public int? Employees { get; set; }
        public double? TtmEPS { get; set; }
        public double? TtmDividendRate { get; set; }
        public double? DividendYield { get; set; }
        public DateTime? NextDividendDate { get; set; }
        public DateTime? ExDividendDate { get; set; }
        public DateTime? NextEarningsDate { get; set; }
        public double? PERatio { get; set; }
        public double? Beta { get; set; }
        public double? MaxChangePercent { get; set; }
        public double? Year5ChangePercent { get; set; }
        public double? Year2ChangePercent { get; set; }
        public double? Year1ChangePercent { get; set; }
        public double? YtdChangePercent { get; set; }
        public double? Month6ChangePercent { get; set; }
        public double? Month3ChangePercent { get; set; }
        public double? Month1ChangePercent { get; set; }
        public double? Day30ChangePercent { get; set; }
        public double? Day5ChangePercent { get; set; }
        public double? TotalCash { get; set; }
        public double? CurrentDebt { get; set; }
        public double? Revenue { get; set; }
        public double? GrossProfit { get; set; }
        public double? TotalRevenue { get; set; }
        public double? EBITDA { get; set; }
        public double? RevenuePerShare { get; set; }
        public double? RevenuePerEmployee { get; set; }
        public double? DebtToEquity { get; set; }
        public double? ProfitMargin { get; set; }
        public double? EnterpriseValue { get; set; }
        public double? EnterpriseValueToRevenue { get; set; }
        public double? PriceToSales { get; set; }
        public double? PriceToBook { get; set; }
        public double? ForwardPERatio { get; set; }
        public double? PegRatio { get; set; }
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
}
