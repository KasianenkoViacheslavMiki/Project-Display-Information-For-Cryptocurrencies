using Project_Display_Information_For_Cryptocurrencies.Commands.WebBrowser;
using System;
using System.Collections.Generic;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class Ticker
    {
        public string Base_Target { get => Base.ToString() + "/" + Target.ToString(); }
        public string Converted_Last_String { get=>Converted_Last["usd"].ToString() + " usd"; }
        public string Converted_Volume_String { get => Converted_Volume["usd"].ToString() + " usd"; }
        public OpenBrowserCommand OpenBrowserCommand { get; set; } = new OpenBrowserCommand();
        public string Base { get; set; }
        public string Target { get; set; }
        public Market Market { get; set; }
        public decimal Last { get; set; }
        public decimal Volume { get; set; }
        public Dictionary<string, decimal> Converted_Last { get; set; }
        public Dictionary<string, decimal> Converted_Volume { get; set; }
        public string Trust_Score { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime Last_Traded_At { get; set; }
        public DateTime Last_Fetch_At { get; set; }
        public bool IsAnomaly { get; set; }
        public bool IsStale { get; set; }
        public string Trade_Url { get; set; }
        public object Token_Info_Url { get; set; }
        public string CoinId { get; set; }
        public string Target_Coin_Id { get; set; }
    }

}
