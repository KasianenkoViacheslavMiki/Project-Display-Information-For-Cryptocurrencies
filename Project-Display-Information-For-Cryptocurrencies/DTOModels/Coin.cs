using Newtonsoft.Json;
using Project_Display_Information_For_Cryptocurrencies.Commands.UICommands;
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Windows.Documents;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public partial class Coin 
    {
        [DataMember(Name = "id")]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [DataMember(Name = "symbol")]
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [DataMember(Name = "name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [DataMember(Name = "image")]
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [DataMember(Name = "thumb")]
        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

        [DataMember(Name = "current_price")]
        [JsonPropertyName("current_price")]
        public decimal? CurrentPrice { get; set; }

        [DataMember(Name = "market_cap")]
        [JsonPropertyName("market_cap")]
        public decimal? MarketCap { get; set; }

        [DataMember(Name = "fully_diluted_valuation")]
        [JsonPropertyName("fully_diluted_valuation")]
        public decimal? FullyDilutedValuation { get; set; }

        [DataMember(Name = "total_volume")]
        [JsonPropertyName("total_volume")]
        public decimal? TotalVolume { get; set; }

        [DataMember(Name = "high_24h")]
        [JsonPropertyName("high_24h")]
        public decimal? High24h { get; set; }

        [DataMember(Name = "low_24h")]
        [JsonPropertyName("low_24h")]
        public decimal? Low24h { get; set; }

        [DataMember(Name = "price_change_24h")]
        [JsonPropertyName("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [DataMember(Name = "price_change_percentage_24h")]
        [JsonPropertyName("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        [DataMember(Name = "market_cap_change_24h")]
        [JsonPropertyName("market_cap_change_24h")]
        public decimal? MarketCapChange24h { get; set; }

        [DataMember(Name = "market_cap_change_percentage_24h")]
        [JsonPropertyName("market_cap_change_percentage_24h")]
        public decimal? MarketCapChangePercentage24h { get; set; }


        public ButtonViewCommand ShowDetailCommand => new ButtonViewCommand(this);
    }
}
