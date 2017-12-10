using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlarmRuleExecutor.Application.Dto;
using AlarmRuleExecutor.Application.Executor;
using Microsoft.AspNetCore.Mvc;

namespace AlarmRuleExecutor.Controllers
{
    [Route("[controller]")]
    public class AlarmController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Index([FromBody]SensorDto dto,[FromServices]IRuleExecutor executor)
        {
            dto.CreationTime = DateTime.UtcNow;
            var result = await executor.Execute(dto);
            return Ok(result);
        }
    }
}
