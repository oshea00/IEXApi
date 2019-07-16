﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace iexapi.Models
{
    public class IEXPriceHistoryItem
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }

        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }

}
