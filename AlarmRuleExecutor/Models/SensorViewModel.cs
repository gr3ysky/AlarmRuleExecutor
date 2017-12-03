using System;
namespace AlarmRuleExecutor.Models
{
    public class SensorViewModel
    {
        public string Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DataType DataType
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }

    }
}
