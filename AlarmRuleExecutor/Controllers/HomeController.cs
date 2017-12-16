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
            var criteria = new Dictionary<string, object>();
            criteria.Add("active", true);
            var sensors = await _manager.Search<Sensor>("sensor", "data", criteria);
           

            return View(sensors);                                                         
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
