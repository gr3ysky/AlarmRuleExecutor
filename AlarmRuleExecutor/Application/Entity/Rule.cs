using System;
using System.Collections.Generic;
using Nest;
using Newtonsoft.Json;

namespace AlarmRuleExecutor.Application.Entity
{
    public class Rule
    {       
        [Text(Name = "name")]
        public string Name { get; set; }
        [Text(Name="op")]
        public string Operator { get; set; }
        [Text(Name = "targetVal")]
        public string Value { get; set; }
        [Nested]
        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }
}
