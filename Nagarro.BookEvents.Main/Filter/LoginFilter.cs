using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Nagarro.BookEvents.Main.Filter
{
    public class LoginFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {

            HttpCookie cookie = filterContext.HttpContext.Request.Cookies["userInfo"];
            if (cookie == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
            
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // intentionally left empty
        }
    }
}