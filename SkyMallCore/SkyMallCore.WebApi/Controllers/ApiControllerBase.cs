﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SkyMallCore.WebApiUtils;

namespace SkyMallCore.WebApi.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// 请求辅助类
        /// </summary>
        public HttpClientHelper HttpClientHelper;

        //public override BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        //{
        //    if (!modelState.IsValid)
        //    {
        //        var errors = modelState
        //                   .Where(e => e.Value.Errors.Count > 0)
        //                   .Select(e =>
        //                       $"{e.Key}{(string.IsNullOrWhiteSpace(e.Value.Errors.First().ErrorMessage) ? e.Value.Errors.First().Exception?.Message : e.Value.Errors.First()?.ErrorMessage)}"
        //                   ).ToArray();
        //        //context.Result = Content(Failed<object>(string.Join("；", errors)).ToJson());
        //        return new BadRequestObjectResult(Failed<object>(string.Join("；", errors)).ToJson());
        //    }
        //    return base.BadRequest(modelState);
        //}

        //public override CreatedAtActionResult CreatedAtAction(string actionName, string controllerName, object routeValues, object value)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState
        //                   .Where(e => e.Value.Errors.Count > 0)
        //                   .Select(e =>
        //                       $"{e.Key}{(string.IsNullOrWhiteSpace(e.Value.Errors.First().ErrorMessage) ? e.Value.Errors.First().Exception?.Message : e.Value.Errors.First()?.ErrorMessage)}"
        //                   ).ToArray();
        //        //context.Result = Content(Failed<object>(string.Join("；", errors)).ToJson());
        //        return new CreatedAtActionResult("Failed", "ApiControllerBase", routeValues, string.Join("；", errors));  //ContentResult(Failed<object>(string.Join("；", errors)).ToJson());
        //    }
        //    return base.CreatedAtAction(actionName, controllerName, routeValues, value);
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="context"></param>
        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        var errors = context.ModelState
        //                   .Where(e => e.Value.Errors.Count > 0)
        //                   .Select(e =>
        //                       $"{e.Key}{(string.IsNullOrWhiteSpace(e.Value.Errors.First().ErrorMessage) ? e.Value.Errors.First().Exception?.Message : e.Value.Errors.First()?.ErrorMessage)}"
        //                   ).ToArray();
        //        context.Result = Content(Failed<object>(string.Join("；", errors)).ToJson());
        //        return;
        //    }

        //    HttpClientHelper = new HttpClientHelper((IHttpClientFactory)HttpContext.RequestServices.GetService(typeof(IHttpClientFactory)), "http://localhost:63656/");
        //    base.OnActionExecuting(context);
        //}


        /// <summary>
        /// 成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(T data, string message = null)
        {
            return new ApiResult<T>(data, message: message);
        }


        /// <summary>
        /// 失败
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult<T> Failed<T>(string message)
        {
            return new ApiResult<T>(default(T), false, message: message);
        }


    }
    


}