using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WebAPI.API.Attributes
{
    public class ApiExceptionAttribute:ExceptionFilterAttribute
    {
        // Override methot..
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            responseMessage.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = responseMessage;
            base.OnException(actionExecutedContext);
        }
    }
}