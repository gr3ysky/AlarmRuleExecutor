using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Entity;

namespace AlarmRuleExecutor.Application.Data
{
    public interface IElasticSearchManager
    {
        Task AddAsync<T>(string index, string type, T t) where T : BaseEntity;
        Task<T> GetAsync<T>(string index, string type, Guid id) where T : BaseEntity;
        Task<List<T>> Search<T>(string index, string type, Dictionary<string, object> creatia) where T : BaseEntity;
        void Log(string index, string type, object obj);
    }
}
