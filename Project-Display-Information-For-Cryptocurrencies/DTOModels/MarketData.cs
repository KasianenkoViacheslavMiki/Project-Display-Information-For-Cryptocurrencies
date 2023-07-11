using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public class MarketData
    {
        [DataMember(Name = "current_price")]
        [JsonPropertyName("current_price")]
        public Dictionary<string, decimal>? CurrentPrice { get; set; }

        [DataMember(Name = "total_volume")]
        [JsonPropertyName("total_volume")]
        public Dictionary<string, decimal>? TotalVolume { get; set; }

        [DataMember(Name = "high_24h")]
        [JsonPropertyName("high_24h")]
        public Dictionary<string, decimal>? High24h { get; set; }

        [DataMember(Name = "low_24h")]
        [JsonPropertyName("low_24h")]
        public Dictionary<string, decimal>? Low24h { get; set; }

        [DataMember(Name = "price_change_24h")]
        [JsonPropertyName("price_change_24h")]
        public decimal? PriceChange24h { get; set; }

        [DataMember(Name = "price_change_percentage_24h")]
        [JsonPropertyName("price_change_percentage_24h")]
        public decimal? PriceChangePercentage24h { get; set; }

        [DataMember(Name = "price_change_percentage_7d")]
        [JsonPropertyName("price_change_percentage_7d")]
        public decimal? PriceChangePercentage7d { get; set; }

        [DataMember(Name = "price_change_percentage_14d")]
        [JsonPropertyName("price_change_percentage_14d")]
        public decimal? PriceChangePercentage14d { get; set; }

        [DataMember(Name = "price_change_percentage_30d")]
        [JsonPropertyName("price_change_percentage_30d")]
        public decimal? PriceChangePercentage30d { get; set; }

        [DataMember(Name = "price_change_percentage_60d")]
        [JsonPropertyName("price_change_percentage_60d")]
        public decimal? PriceChangePercentage60d { get; set; }

        [DataMember(Name = "price_change_24h_in_currency")]
        [JsonPropertyName("price_change_24h_in_currency")]
        public Dictionary<string, decimal>? PriceChange24hInCurrency { get; set; }
    }
}
