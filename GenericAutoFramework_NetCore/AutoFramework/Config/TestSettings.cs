using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AutoFramework.Config
{
    //[JsonObject("testSettings")]
    [DataContract]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

       // [JsonProperty("aut")]
       [DataMember]
        public string Aut { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("isLog")]
        public string IsLog { get; set; }

        [JsonProperty("logPath")]
        public string LogPath { get; set; }

        [JsonProperty("browser")]
        public string Browser { get; set; }
        
        [JsonProperty("autConnectionString")]
        public string AutConnectionString { get; set; }
    }
}
