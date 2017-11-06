using System;
using System.Collections.Generic;
using Nest;
using Newtonsoft.Json;

namespace AlarmRuleExecutor.Application.Entity
{
    public class Rule:BaseEntity
    {
        [Text(Name="op")]
        public string Operator { get; set; }
        [Text(Name = "treshold")]
        public string TresholdValue { get; set; }
        [Nested]
        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }
}
