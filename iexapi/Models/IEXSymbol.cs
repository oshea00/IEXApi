﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iexapi.Models
{
    public class IEXSymbol
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string IEXID { get; set; }
        public string Region { get; set; }
        public string Currency { get; set; }
        public bool IsEnabled { get; set; }
    }
}
