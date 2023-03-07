using Newtonsoft.Json;
using System.Text.Json;

namespace C_DotNetCore_Launch_EC2.Model
{
   public class RequestModel
    {
    
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}


