using System;
using Nest;

namespace AlarmRuleExecutor.Application.Entity
{
    public class Email : Action
    {
        public Email()
        {
            Type = "email";
        }
        [Text(Name = "to")]
        public string To { get; set; }
        [Text(Name = "sub")]
        public string Subject { get; set; }
        [Text(Name = "body")]
        public string Body { get; set; }
    }
}
