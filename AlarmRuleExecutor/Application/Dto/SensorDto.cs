using System;
namespace AlarmRuleExecutor.Application.Dto
{
    public class SensorDto
    {
        public string SensorId { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
