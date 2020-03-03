using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Template.Domain.Models;

namespace Template.Api.ExceptionFIlter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            RequestRetorno<string> responseData = new RequestRetorno<string>()
            {
                Mensagens = new List<string>() { context.Exception.Message },
                Erro = true
            };

            //context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = "application/json";
            context.Result = new ObjectResult(responseData);
        }
    }
}
