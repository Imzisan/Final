
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PostComment.Auth
{
    public class Logged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //check authorization header is in database or not or is expired
            var token = actionContext.Request.Headers.Authorization;//getting request header authorization data
            if (token == null)//no token hence unauthorized
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "No token supplied" });
            }
            else if (!AuthService.IsTokenValid(token.ToString()))
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "Supplied token is invalid or expired" });
            }
            base.OnAuthorization(actionContext);//brr token
        }
    }
}