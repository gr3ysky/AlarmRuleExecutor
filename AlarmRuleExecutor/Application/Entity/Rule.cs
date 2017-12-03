using System;
using System.Collections.Generic;
using Nest;
using Newtonsoft.Json;

namespace AlarmRuleExecutor.Application.Entity
{
    public class Rule:BaseEntity
    {       
        [Text(Name = "deviceId")]
        public Guid DeviceId { get; set; }
        [Text(Name = "name")]
        public string Name { get; set; }
        [Text(Name="op")]
        public string Operator { get; set; }
        [Text(Name = "targetVal")]
        public string TargetValue { get; set; }
    }
}
