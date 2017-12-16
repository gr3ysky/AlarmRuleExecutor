using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Dto;
using AlarmRuleExecutor.Application.Executor;
using AlarmRuleExecutor.Application.Security;
using AlarmRuleExecutor.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace AlarmRuleExecutor.Controllers
{
    [Route("[controller]")]
    public class SlackController:Controller
    {
        private static HttpClient _client;
        public SlackController()
        {
            if(_client==null)
                _client = new HttpClient();
        }
        [HttpPost]
        [BasicAuthFilter]
        public async Task<IActionResult> Send([FromBody]SlackMessageModel model )
        {
            //string apiurl = "https://hooks.slack.com/services/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";
            var payload = new
            {
                text = $"{model.SensorName} has sent the value:{model.SensorValue}",
            };
            await _client.PostAsync(model.ApiUrl, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));
            return Ok();
        }
    }
}
