using System;
namespace AlarmRuleExecutor.Models
{
    public class SlackMessageModel
    {
        public String SensorName
        {
            get;
            set;
        }
        public String SensorValue { get; set; }
        public String ApiUrl { get; set; }
    }
}
