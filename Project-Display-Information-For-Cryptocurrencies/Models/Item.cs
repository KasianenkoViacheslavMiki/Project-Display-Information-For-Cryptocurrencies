using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using System;
using System.Windows.Input;

namespace Project_Display_Information_For_Cryptocurrencies.Models
{
    public class Item
    {
        private decimal price_btc;

        public string Id { get; set; }
        public int Coin_id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Market_cap_rank { get; set; }
        public string Thumb { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Slug { get; set; }
        public decimal Price_btc
        {
            get => price_btc;
            set => price_btc = Math.Round(value,15);
        }
        public int Score { get; set; }

        public ButtonViewCommand ShowDetailCommand { get; set; }

        public Item()
        {
            ShowDetailCommand = new ButtonViewCommand(this);
        }
    }
}
