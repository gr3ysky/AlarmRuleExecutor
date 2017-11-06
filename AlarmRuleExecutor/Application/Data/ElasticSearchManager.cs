using System;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Configuration;
using AlarmRuleExecutor.Application.Entity;
using Microsoft.Extensions.Options;
using Nest;
namespace AlarmRuleExecutor.Application.Data
{
    public class ElasticSearchManager : IElasticSearchManager
    {
        private readonly ElasticClient _client;
        public ElasticSearchManager(IOptions<ElasticSearchConnectionSettings> options)
        {
            var uri = new Uri($"http://{options.Value.Url}:{options.Value.Port}");
            var settings = new ConnectionSettings(uri);
            settings.EnableHttpCompression();
#if DEBUG
            settings.EnableDebugMode();
#endif
            _client = new ElasticClient(settings);
            CreateMappings();
        }
        /// <summary>
        /// Create mappings for each entity 
        /// </summary>
        private void CreateMappings()
        {
            var descriptor = new CreateIndexDescriptor("sensor")
            .Mappings(ms => ms
            .Map<Sensor>(m => m.AutoMap()));
        }

        public async Task AddAsync<T>(string index,string type,T t)where T:BaseEntity{          
            await _client.IndexAsync<T>(t, req => req.Index(index).Type(type).Id(t.Id));
        }


    }
}
