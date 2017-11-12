using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlarmRuleExecutor.Controllers
{
    public class SensorController:Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(){
            return View();
        }
    }
}
