using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace iexapi.Models
{
    public class IEXCompanyBalanceSheet
    {
        public string Symbol { get; set; }
        public List<IEXBalanceSheet> BalanceSheet { get; set; }
    }

    public class IEXBalanceSheet
    {
        public string ReportDate { get; set; }
        public decimal? CurrentCash { get; set; }
        public decimal? ShortTermInvestments { get; set; }
        public decimal? Receivables { get; set; }
        public decimal? Inventory { get; set; }
        public decimal? OtherCurrentAssets { get; set; }
        public decimal? CurrentAssets { get; set; }
        public decimal? LongTermInvestments { get; set; }
        public decimal? PropertyPlantEquipment { get; set; }
        public decimal? Goodwill { get; set; }
        public decimal? IntangibleAssets { get; set; }
        public decimal? OtherAssets { get; set; }
        public decimal? TotalAssets { get; set; }
        public decimal? AccountsPayable { get; set; }
        public decimal? CurrentLongTermDebt { get; set; }
        public decimal? OtherCurrentLiabilities { get; set; }
        public decimal? TotalCurrentLiabilities { get; set; }
        public decimal? LongTermDebt { get; set; }
        public decimal? OtherLiabilities { get; set; }
        public decimal? MinorityInterest { get; set; }
        public decimal? TotalLiabilities { get; set; }
        public decimal? CommonStock { get; set; }
        public decimal? RetainedEarnings { get; set; }
        public decimal? TreasuryStock { get; set; }
        public decimal? CapitalSurplus { get; set; }
        public decimal? ShareholderEquity { get; set; }
        public decimal? NetTangibleAssets { get; set; }

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }

    }
}
