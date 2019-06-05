using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsychologyCenter.Areas.Manage.Filters
{
    public class Auth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["AdminLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/manage/login");
                return;
            }
            base.OnActionExecuting(filterContext);

        }

    }
}