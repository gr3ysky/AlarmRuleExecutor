using System;
using Nest;

namespace AlarmRuleExecutor.Application.Entity
{
    [ElasticsearchType(Name = "data", IdProperty = "id")]
    public class Sensor : BaseEntity
    {
        [Text(Name = "name", Fielddata = true)]
        public string Name { get; set; }
        [Text(Name = "desc")]
        public string Description { get; set; }
        [Text(Name = "val", Fielddata = true)]
        public string Value { get; set; }
        [Date(Name="created",Format = "dd.MM.yyyy HH:mm:ss")]
        public DateTime CreateTime { get; set; }
        [Date(Name = "modified", Format = "dd.MM.yyyy HH:mm:ss")]
        public DateTime ModifyTime { get; set; }
        [Boolean(Name = "active", Store = true)]
        public bool IsActive { get; set; }

    }
}
