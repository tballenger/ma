using ma.Areas.Account.Models;
using ma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ma.Attributes
{
    public class CurrentUserProfileAttribute : ActionFilterAttribute
    {
        public string AccessLevel { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User != null)
            {
                var isAuthorized = filterContext.HttpContext.User.Identity.IsAuthenticated;
                if (isAuthorized)
                {
                    var userProfile = new UserProfileService().GetProfileForUsername(filterContext.HttpContext.User.Identity.Name);

                    if (userProfile != null)
                        filterContext.Controller.ViewBag.CurrentUserProfile = userProfile;
                }
            }
        }
    }
}