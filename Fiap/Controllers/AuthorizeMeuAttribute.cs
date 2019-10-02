using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Fiap.Controllers
{
    public class AuthorizeMeuAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {


            base.OnActionExecuting(context);    
        }

    }
}