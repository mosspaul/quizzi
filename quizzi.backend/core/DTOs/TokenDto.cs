using System;
using Newtonsoft.Json;

namespace core.DTOs;

public class TokenDto
{
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }

        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

}
