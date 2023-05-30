using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using System;
using System.Collections;
using System.Windows.Documents;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class Coin
    {
        public string? Id { get; set; }
        public string? Symbol { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Thumb { get; set; }
        public decimal? Current_price { get; set; }
        public decimal? Market_cap { get; set; }
        public string? Api_symbol { get; set; }
        public int? Market_cap_rank { get; set; }
        public decimal? Fully_diluted_valuation { get; set; }
        public decimal? Total_volume { get; set; }
        public decimal? High_24h { get; set; }
        public decimal? Low_24h { get; set; }
        public decimal? Price_change_24h { get; set; }
        public decimal? Price_change_percentage_24h { get; set; }
        public decimal? Market_cap_change_24h { get; set; }
        public decimal? Market_cap_change_percentage_24h { get; set; }
        public decimal? Circulating_supply { get; set; }
        public decimal? Total_supply { get; set; }
        public decimal? Max_supply { get; set; }
        public decimal? Ath { get; set; }
        public decimal? Ath_change_percentage { get; set; }
        public DateTime? Ath_date { get; set; }
        public decimal? Atl { get; set; }
        public decimal? Atl_change_percentage { get; set; }
        public DateTime? Atl_date { get; set; }
        public DateTime? Last_updated { get; set; }

        public ButtonViewCommand ShowDetailCommand { get; set; }

        public Coin()
        {
            ShowDetailCommand = new ButtonViewCommand(this);
        }
    }
}
