using Newtonsoft.Json;
using Project_Display_Information_For_Cryptocurrencies.Commands.WebBrowser;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public partial class Ticker
    {
        [DataMember(Name = "base")]
        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [DataMember(Name = "target")]
        [JsonPropertyName("target")]
        public string? Target { get; set; }

        [DataMember(Name = "volume")]
        [JsonPropertyName("volume")]
        public decimal? Volume { get; set; }

        [DataMember(Name = "converted_last")]
        [JsonPropertyName("converted_last")]
        public Dictionary<string, decimal>? ConvertedLast { get; set; }

        [DataMember(Name = "converted_volume")]
        [JsonPropertyName("converted_volume")]
        public Dictionary<string, decimal>? ConvertedVolume { get; set; }

        [DataMember(Name = "trade_url")]
        [JsonPropertyName("trade_url")]
        public string? TradeUrl { get; set; }

        public string? TargetCurrencies = "usd";

        public string? BaseTarget => Base.ToString() + "/" + Target.ToString();

        public string? ConvertedLastString => ConvertedLast[TargetCurrencies].ToString() + " " + TargetCurrencies;

        public string? ConvertedVolumeString => ConvertedVolume[TargetCurrencies].ToString() + " " + TargetCurrencies;

        public OpenBrowserCommand? OpenBrowserCommand => new OpenBrowserCommand();
    }

}
