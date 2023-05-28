using System.Collections.Generic;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class CurrencyDetailData
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public Description Description { get; set; }
        public Links Links { get; set; }
        public Image Image { get; set; }
        public List<Ticker>? Tickers { get; set; }
        public double Sentiment_Votes_Up_Percentage { get; set; }
        public double Sentiment_Votes_Down_Percentage { get; set; }
        public MarketData Market_Data { get; set; }
        public string Last_Updated { get; set; }
    }
}
