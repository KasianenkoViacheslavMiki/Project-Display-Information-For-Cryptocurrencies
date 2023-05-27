using System.Collections.Generic;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class Root
    {
        public List<CoinData> coins { get; set; }
        public List<object> exchanges { get; set; }
    }
}
