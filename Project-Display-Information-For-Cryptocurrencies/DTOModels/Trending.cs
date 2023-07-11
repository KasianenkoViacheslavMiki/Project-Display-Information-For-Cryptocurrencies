using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public partial class Trending
    {
        [DataMember(Name = "coins")]
        [JsonPropertyName("coins")]
        public Box[] Coins { get; set; }

        [DataMember(Name = "nfts")]
        [JsonPropertyName("nfts")]
        public object[] Nfts { get; set; }

        [DataMember(Name = "exchanges")]
        [JsonPropertyName("exchanges")]
        public object[] Exchanges { get; set; }
    }


    [DataContract]
    public class Box
    {
        [DataMember(Name = "item")]
        [JsonPropertyName("item")]
        public Item Item { get; set; }
    }
}
