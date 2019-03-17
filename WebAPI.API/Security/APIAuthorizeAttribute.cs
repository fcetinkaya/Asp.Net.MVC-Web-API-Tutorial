using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI.DAL;

namespace WebAPI.API.Security
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRole = Roles;
            var userName = HttpContext.Current.User.Identity.Name;
            UserDAL userDAL = new UserDAL();
            var user = userDAL.GetUserByName(userName);
            if (user != null && actionRole.Contains(user.Role))
            {

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            base.OnAuthorization(actionContext);
        }
    }
}