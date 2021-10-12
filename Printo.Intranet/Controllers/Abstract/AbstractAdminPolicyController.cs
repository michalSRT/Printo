using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Printo.Data.Data;
using Printo.Intranet.Policy;

namespace Printo.Intranet.Controllers.Abstract
{
    public abstract class AbstractAdminPolicyController : Controller
    {
        protected readonly PrintoContextDB _context;

        public AbstractAdminPolicyController(PrintoContextDB context)
        {
            _context = context;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            UserPolicy policy = new UserPolicy(_context, HttpContext, this.ControllerContext.RouteData);

            if (await policy.isAdmin() == false)
            {
                filterContext.Result = new RedirectResult(Url.Action("Index", "Home"));
                this.OnActionExecuting(filterContext);
            }
            else
            {
                this.OnActionExecuting(filterContext);
                var resultContext = await next();
                this.OnActionExecuted(resultContext);
            }
        }
    }
}
