using System;
using System.Collections.Generic;
using System.Linq;
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
                          .Map<Rule>(m => m.AutoMap())
                      .Map<Entity.Action>(m => m.AutoMap())
                          .Map<Sensor>(m => m.AutoMap()));
        }

        public async Task AddAsync<T>(string index, string type, T t) where T : BaseEntity
        {
            await _client.IndexAsync<T>(t, req => req.Index(index).Type(type).Id(t.Id));
        }
        public async Task<T> GetAsync<T>(string index, string type,Guid id)where T: BaseEntity
        {
            var response = await _client.GetAsync<T>(new GetRequest(index,type,id));
            return response.Source;
        }

        public async Task<List<T>> Search<T>(string index,string type,Dictionary<string,object> creatia) where T:BaseEntity
        {
            Func<SearchDescriptor<T>, ISearchRequest> req = desc =>
            {
                desc.Index(index)
                    .Type(type);
                var filters = new List<Func<QueryContainerDescriptor<T>, QueryContainer>>();
                foreach (var item in creatia)
                {
                    filters.Add(fq => fq.Terms(t => t.Field(item.Key).Terms(item.Value)));
                }
                desc.Query(q=> q.Bool(b=>b.Filter(filters)));

                return desc;
            };

            var response=await _client.SearchAsync(req);
            return response.Documents.ToList();
        }

        public void Log(string index, string type, object obj)
        {
            _client.Index<object>(obj, req => req.Index(index).Type(type).Id(Guid.NewGuid()));
        }
    }
}
