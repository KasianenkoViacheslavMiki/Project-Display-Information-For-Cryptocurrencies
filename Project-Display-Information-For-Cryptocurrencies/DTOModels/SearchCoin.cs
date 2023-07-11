using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public class SearchCoin
    {
        [DataMember(Name = "Coins")]
        [JsonPropertyName("Coins")]
        public List<Coin> Coins { get; set; }
    }
}
