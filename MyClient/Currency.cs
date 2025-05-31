using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    public class CurrencyRate
    {
        public string currency { get; set; }
        public string code { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
    }
    public class RateTable
    {
        public string table { get; set; }
        public string no { get; set; }
        public string tradingDate { get; set; }
        public string effectiveDate { get; set; }
        public List<CurrencyRate> rates { get; set; }
    }
}
