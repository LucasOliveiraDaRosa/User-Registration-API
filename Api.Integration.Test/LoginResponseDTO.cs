using Newtonsoft.Json;
using System;

namespace Api.Integration.Test
{
    public class LoginResponseDTO
    {
        [JsonProperty("authenticated")]
        public bool authenticated { get; set; }
        
        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("expiration")]
        public DateTime expiration { get; set; }

        [JsonProperty("acessToken")]
        public string accessToken { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
