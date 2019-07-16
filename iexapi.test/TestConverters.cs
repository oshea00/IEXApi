using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace iexapi.test
{
    [TestFixture]
    public class TestConverters
    {
        [Test]
        public void CanConvertWeirdJsonDates(
            [Values("2015-01-01", "", "0000-00-00", null)]
        string date)
        {
            string json = "{ \"Date\":" + "\""+date+"\"}";
            Dated obj = JObject.Parse(json).ToObject<Dated>();
            Console.WriteLine(obj.Date);
        }
    }

    public class Dated
    {
        public DateTime? Date { get; set; }
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
}
