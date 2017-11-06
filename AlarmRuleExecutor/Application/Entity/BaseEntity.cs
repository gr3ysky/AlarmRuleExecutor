using System;
using Nest;

namespace AlarmRuleExecutor.Application.Entity
{
    public class BaseEntity
    {
        [Keyword(Name = "id")]
        public Guid Id { get; set; }
    }
}
