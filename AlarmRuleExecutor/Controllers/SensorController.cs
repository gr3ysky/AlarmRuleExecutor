using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Data;
using AlarmRuleExecutor.Application.Entity;
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
        [HttpPost]
        public async Task<IActionResult> Create(Sensor entity,[FromServices]IElasticSearchManager manager)
        {
            entity.CreateTime = DateTime.UtcNow;
            entity.Id = Guid.NewGuid();
            entity.IsActive = true;
            await manager.AddAsync("sensor","data",entity);
            return RedirectToAction("index", "home");
        }


    }
}
