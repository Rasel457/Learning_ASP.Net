using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture_5.Models;

namespace Lecture_5.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var db = new Database();
                int type = db.Customers.GetUserType(httpContext.User.Identity.Name);
                if (type == 2) return true;
            }
            return false;
        }
    }
}