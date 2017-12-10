using System;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Dto;

namespace AlarmRuleExecutor.Application.Executor
{
    public interface IRuleExecutor
    {
        Task<bool> Execute(SensorDto dto);
    }
}
