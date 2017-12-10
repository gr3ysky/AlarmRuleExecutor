using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlarmRuleExecutor.Controllers
{
    public class SensorController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var actionTypes = new List<SelectListItem>();
            actionTypes.Add(new SelectListItem(){Text="Web Request",Value="WebRequest"});
            actionTypes.Add(new SelectListItem() { Text = "Email", Value = "Email" });
            ViewBag.ActionTypes = actionTypes;
            return View();
        }
    }
}
