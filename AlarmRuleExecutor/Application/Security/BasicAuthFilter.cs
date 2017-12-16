using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlarmRuleExecutor.Application.Security
{
    public class BasicAuthFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var req = context.HttpContext.Request;
            var auth = req.Headers["Authorization"].ToString();
            if (!String.IsNullOrEmpty(auth))
            {
                var cred = Encoding.UTF8.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
                var user = new { Name = cred[0], Pass = cred[1] };
                if (user.Name == "test" && user.Pass == "test") return;
            }
            context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
        }
    }
}
