using Newtonsoft.Json;
using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Windows.Input;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public partial class Item 
    {
        private decimal price_btc;

        [DataMember(Name = "price_btc")]
        [JsonPropertyName("price_btc")]
        public decimal PriceBtc
        {
            get => price_btc;
            set => price_btc = Math.Round(value, 15);
        }
        [DataMember(Name = "id")]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [DataMember(Name = "coin_id")]
        [JsonPropertyName("coin_id")]
        public int CoinId { get; set; }

        [DataMember(Name = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [DataMember(Name = "symbol")]
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "market_cap_rank")]
        [JsonPropertyName("market_cap_rank")]
        public int MarketCapRank { get; set; }

        [DataMember(Name = "thumb")]
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [DataMember(Name = "small")]
        [JsonPropertyName("small")]
        public string Small { get; set; }

        [DataMember(Name = "large")]
        [JsonPropertyName("large")]
        public string Large { get; set; }

        [DataMember(Name = "slug")]
        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [DataMember(Name = "score")]
        [JsonPropertyName("score")]
        public int Score { get; set; }

        public ButtonViewCommand? ShowDetailCommand => new ButtonViewCommand(this);
    }
}
