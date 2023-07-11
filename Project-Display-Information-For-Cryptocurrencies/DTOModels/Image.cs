using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Project_Display_Information_For_Cryptocurrencies.DTOModels
{
    [DataContract]
    public class Image
    {
        [DataMember(Name = "thumb")]
        [JsonProperty("thumb")]
        public string? Thumb { get; set; }

        [DataMember(Name = "small")]
        [JsonProperty("small")]
        public string? Small { get; set; }

        [DataMember(Name = "large")]
        [JsonProperty("large")]
        public string? Large { get; set; }
    }
}
