using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appp.Models
{
    public partial class Root
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public List<Posts> Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public partial class Posts
    {
        [JsonProperty("uuid")]
        public Guid uuid { get; set; }

        [JsonProperty("head")]
        public string head { get; set; }

        [JsonProperty("body")]
        public string body { get; set; }

        [JsonProperty("preview_picture")]
        public string preview_picture { get; set; }
    }

}
