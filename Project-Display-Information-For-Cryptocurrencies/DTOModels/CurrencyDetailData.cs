using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public class CurrencyDetailData
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
        public Image? Image { get; set; }

        [DataMember(Name = "tickers")]
        [JsonPropertyName("tickers")]
        public List<Ticker>? Tickers { get; set; }

        [DataMember(Name = "market_data")]
        [JsonPropertyName("market_data")]
        public MarketData? MarketData { get; set; }
    }
}
