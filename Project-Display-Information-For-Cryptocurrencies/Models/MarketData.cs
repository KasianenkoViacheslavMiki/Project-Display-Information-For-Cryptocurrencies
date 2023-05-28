using System.Collections.Generic;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class MarketData
    {
        public string targetCurrent = "usd";
        public string Current_Price_Target { get=> Current_Price[targetCurrent].ToString()+ " "+ targetCurrent; }
        public string Total_Volume_Target { get => Total_Volume[targetCurrent].ToString() + " " + targetCurrent; }
        public string Price_Change_24h_In_Currency_Target { get => Price_Change_24h_In_Currency[targetCurrent].ToString() + " " + targetCurrent; }


        public Dictionary<string, decimal> Current_Price { get; set; }
        public Dictionary<string, decimal> Market_Cap { get; set; }
        public int Market_Cap_Rank { get; set; }
        public Dictionary<string, decimal> Fully_Diluted_Valuation { get; set; }
        public Dictionary<string, decimal> Total_Volume { get; set; }
        public Dictionary<string, decimal> High_24h { get; set; }
        public Dictionary<string, decimal> Low_24h { get; set; }
        public decimal Price_Change_24h { get; set; }
        public decimal Price_Change_Percentage_24h { get; set; }
        public decimal Price_Change_Percentage_7d { get; set; }
        public decimal Price_Change_Percentage_14d { get; set; }
        public decimal Price_Change_Percentage_30d { get; set; }
        public decimal Price_Change_Percentage_60d { get; set; }
        public decimal Price_Change_Percentage_200d { get; set; }
        public decimal Price_Change_Percentage_1y { get; set; }
        public decimal Market_Cap_Change_24h { get; set; }
        public decimal Market_Cap_Change_Percentage_24h { get; set; }
        public Dictionary<string, decimal> Price_Change_24h_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_1h_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_24h_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_7d_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_14d_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_30d_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_60d_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_200d_In_Currency { get; set; }
        public Dictionary<string, decimal> Price_Change_Percentage_1y_InCurrency { get; set; }
        public Dictionary<string, decimal> Market_Cap_Change_24h_In_Currency { get; set; }
        public Dictionary<string, decimal> Market_Cap_Change_Percentage_24h_In_Currency { get; set; }
        public decimal Circulating_Supply { get; set; }
        public string Last_Updated { get; set; }
    }
}
