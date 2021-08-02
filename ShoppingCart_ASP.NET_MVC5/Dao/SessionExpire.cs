﻿using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace ShoppingCart_ASP.NET_MVC5.Dao
{
    public class SessionExpire : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)

        {
            if (HttpContext.Current.Request.Cookies.Count == 0)
            {
                filterContext.Result = new RedirectToRouteResult
                        (new RouteValueDictionary{
                            { "controller","Home" },
                            {"action","Home" }
                             });

            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }
}