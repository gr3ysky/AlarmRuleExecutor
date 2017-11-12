using System;
using Nest;

namespace AlarmRuleExecutor.Application.Entity
{
    public class Action : BaseEntity
    {
        public Guid RuleId { get; set; }
        [Text(Name="type",Fielddata = true)]
        public string Type { get; set; }
    }
}