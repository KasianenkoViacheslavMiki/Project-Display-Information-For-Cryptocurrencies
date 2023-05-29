using System.Collections.Generic;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class Trending
    {
        public List<TrendingData>? Coins { get; set; }
        public List<object>? Exchanges { get; set; }
    }
}
