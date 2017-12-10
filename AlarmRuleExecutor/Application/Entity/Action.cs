using System;
using Nest;

namespace AlarmRuleExecutor.Application.Entity
{
    public class Action 
    {
        [Text(Name="type",Fielddata = true)]
        public string Type { get; set; }
        [Text(Name = "name", Fielddata = true)]
        public string Name { get; set; }
        [Text(Name = "content", Fielddata = true)]
        public string Content { get; set; }
    }
}