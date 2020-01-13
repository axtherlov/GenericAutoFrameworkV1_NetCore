using Newtonsoft.Json;

namespace AutoFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("aut")]
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
