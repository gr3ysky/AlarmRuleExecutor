using System;
using AlarmRuleExecutor.Application.Configuration;
using AlarmRuleExecutor.Application.Data;

namespace AlarmRuleExecutor.Application.Executor
{
    public class ActionPerformerFactory
    {
        internal static ActionPerformer Create(string type,IElasticSearchManager manager,EmailSettings settings){
            if (type.ToLower() == "webrequest")
                return new HttpRequestPerformer(manager);
            return new EmailSendPerformer(manager,settings);
        }

    }
}
