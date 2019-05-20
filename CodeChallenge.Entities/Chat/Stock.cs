using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallenge.Entities.Chat
{
    public class Stock
    {
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }

        public Stock()
        {
        }
    }
}