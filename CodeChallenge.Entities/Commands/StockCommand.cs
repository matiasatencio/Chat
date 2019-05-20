using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using CodeChallenge.Entities.Chat;

namespace CodeChallenge.Entities.Commands
{
    public class StockCommand : Command
    {
        public string Url { get; set; }

        public StockCommand(string name) : base(name)
        {
            this.Url = "https://stooq.com/q/l/?s={0}&f=sd2t2ohlcv&h&e=csv";
        }

        public override string Perform(string param)
        {
            Stock stock = ParseToStock(string.Format(this.Url, param));
            return stock != null ? $"{stock.Symbol} quote is ${stock.Close} per share" : "Wrong symbol code";
        }

        public static string GetCSV(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }

        public static Stock ParseToStock(string path)
        {
            try
            {
                string output = GetCSV(path);
                string[] rows = output.Split(new[] { Environment.NewLine },
                                        StringSplitOptions.None);

                string[] stockRow = rows[1].Split(',');

                return new Stock()
                {
                    Symbol = stockRow[0],
                    Date = Convert.ToDateTime(stockRow[1]),
                    Time = Convert.ToDateTime(stockRow[2]),
                    Open = Convert.ToDecimal(stockRow[3]),
                    High = Convert.ToDecimal(stockRow[4]),
                    Low = Convert.ToDecimal(stockRow[5]),
                    Close = Convert.ToDecimal(stockRow[6]),
                    Volume = Convert.ToDecimal(stockRow[7])
                };
            }
            catch(FormatException ex)
            {
                return null;
            }
        }
    }
}