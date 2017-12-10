using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using AlarmRuleExecutor.Application.Data;
using AlarmRuleExecutor.Application.Dto;
using AlarmRuleExecutor.Application.Entity;
using Newtonsoft.Json;

namespace AlarmRuleExecutor.Application.Executor
{
    public class HttpRequestPerformer:ActionPerformer
    {
        public static HttpClient _client;
        public readonly static  object _lock = new object();
        private readonly IElasticSearchManager manager;

        public HttpRequestPerformer(IElasticSearchManager manager)
        {
            if (_client == null)
            {
                _client = new HttpClient();
            }
            this.manager = manager;
        }

        public override bool Perform(SensorDto dto, string jsonMessage)
        {
            var webrequest = JsonConvert.DeserializeObject<WebRequest>(jsonMessage);
            if (webrequest == null|| string.IsNullOrEmpty(webrequest.Url)) return false;
            lock(_lock){
                if (webrequest.Security != null && webrequest.Security.Type.ToLower() == "basic")
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(webrequest.Security.Username + ":" + webrequest.Security.Password)));
                if(webrequest.Headers!=null && webrequest.Headers.Any()){
                    foreach (var header in webrequest.Headers)
                    {
                        _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                try
                {
                    var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                    if(webrequest.Method.ToLower()=="get")
                        _client.GetAsync(webrequest.Url, tokenSource.Token).Wait();
                    else{
                        if (webrequest.Body != null)
                            _client.PostAsync(webrequest.Url, new StringContent(JsonConvert.SerializeObject(webrequest.Body), Encoding.UTF8, "application/json"), tokenSource.Token).Wait();
                        else
                            _client.PostAsync(webrequest.Url,null,tokenSource.Token).Wait();
                    }
                }
                catch (Exception ex)
                {
                    manager.Log("logs", "exception", ex);
                }
                _client.DefaultRequestHeaders.Clear();
            }
   
            return true;
        }
    }
}
