using System;
using System.Collections.Generic;
using Nest;
using Newtonsoft.Json;

namespace AlarmRuleExecutor.Application.Entity
{
    public class WebRequest : Action
    {
        public WebRequest()
        {
            Type = "webrequest";
        }
        [Text(Name = "url")]
        public string Url { get; set; }
        [Text(Name = "method")]
        public string Method { get; set; }
        [Nested]
        [JsonProperty("headers")]
        public List<Header> Headers { get; set; }
        [Text(Name="body")]
        public object Body { get; set; }
        public Security Security { get; set; }
    }
    public class Header
    {
        [Text(Name = "key")]
        public string Key { get; set; }
        [Text(Name = "val")]
        public string Value { get; set; }
    }
    public class Security {
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
