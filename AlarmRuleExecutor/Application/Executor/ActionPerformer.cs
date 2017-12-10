using System;
using AlarmRuleExecutor.Application.Dto;

namespace AlarmRuleExecutor.Application.Executor
{
    public abstract class ActionPerformer
    {
        public abstract bool Perform(SensorDto dto,string jsonMessage);
    }
}
