using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlarmRuleExecutor.Models;
using AlarmRuleExecutor.Application.Data;
using AlarmRuleExecutor.Application.Entity;

namespace AlarmRuleExecutor.Controllers
{
    public class HomeController : Controller
    {
        private IElasticSearchManager _manager;
        public HomeController(IElasticSearchManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var filters = new Dictionary<string, object>();
            filters.Add("type", "webrequest");
            var webreqs = await _manager.Search<Application.Entity.WebRequest>("action", "data", 
                                                                             filters
                                                                             
                                                                             );


            await _manager.AddAsync("sensor", "data", new Sensor
            {
                CreateTime = DateTime.Now,
                Description = "Test sensor",
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "test",
                Value = "1"
            });
            await _manager.AddAsync("rule", "data", new Rule
            {
                DeviceId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Operator = "==",
                TargetValue = "1"
            });
            var headers = new List<Header>();
            headers.Add(new Header() { Key = "key1", Value = "val1" });
            headers.Add(new Header() { Key = "key2", Value = "key2" });
            await _manager.AddAsync("action", "data", new WebRequest
            {
                Id = Guid.NewGuid(),
                Body = "body",
                Headers = headers,
                Method = "POST",
                RuleId = Guid.NewGuid(),
                Url = "http://localhost:8080/api/sensor/history"

            });
            await _manager.AddAsync("action", "data", new Email
            {
                Id = Guid.NewGuid(),
                RuleId = Guid.NewGuid(),
                Message = "message",
                Subject = "subject",
                To = "taneryigit@live.com"

            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
