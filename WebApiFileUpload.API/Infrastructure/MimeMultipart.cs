#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
#endregion

namespace WebApiFileUpload.API.Infrastructure
{
    /// <summary>
    /// validate request content is multipart/form-data
    /// </summary>
    /// <remarks>
    /// The HttpResponseException type is a special case. This exception returns any HTTP status code that you specify in the exception constructor. 
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/exception-handling#httpresponseexception
    /// </remarks>
    public class MimeMultipart : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

        }
    }
}