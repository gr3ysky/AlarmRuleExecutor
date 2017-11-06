using System;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Entity;

namespace AlarmRuleExecutor.Application.Data
{
    public interface IElasticSearchManager
    {
        Task AddAsync<T>(string index, string type, T t) where T : BaseEntity;
    }
}
