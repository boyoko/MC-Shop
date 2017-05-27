using MC.NetCore.ShopApp.ResponseBaseDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.NetCore.ShopApp.Filters
{
    public class CustomJSONExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            var jsonResult = new JsonResult(new BaseResult { ErrorMessage = context.Exception.Message,StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError });
            jsonResult.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
            context.Result = jsonResult;

            //if (context.HttpContext.Request.GetTypedHeaders().Accept.Any(header => header.MediaType == "application/json"))
            //{
            //    var jsonResult = new JsonResult(new { error = context.Exception.Message });
            //    jsonResult.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError;
            //    context.Result = jsonResult;
            //}
        }
    }
}
