using MC.NetCore.DomainModels.Dto;
using MC.NetCore.ShopApp.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.NetCore.ShopApp.Filters
{
    public class LoginCheckFilterAttribute: ActionFilterAttribute
    {
        private readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
        public LoginCheckFilterAttribute()
        {
            IsCheck = true;
        }

        //表示是否检查登录
        public bool IsCheck { get; set; }

        //Action方法执行之前执行此方法
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (IsCheck)
                {
                    //http://blog.csdn.net/zhx19920405/article/details/51417250
                    #region IOS 微信端打开cookie会被删除，暂时取消cookie 验证
                    //var httpCookie = filterContext.HttpContext.Request.Cookies["userId"];

                    //var userAgent = filterContext.HttpContext.Request.Headers["User-Agent"];

                    //if(userAgent.Contains("iPhone", StringComparer.OrdinalIgnoreCase))
                    //{
                    //    if (String.IsNullOrWhiteSpace(httpCookie))
                    //    {
                    //        _logger.Info("LoginCheckFilterAttribute：获取Cookies失败！");
                    //    }
                    //    else
                    //    {
                    //        _logger.Info("LoginCheckFilterAttribute：Cookies = " + httpCookie);
                    //    }

                    //    if (!VolidateToken(httpCookie))
                    //    {
                    //        ReturnNoLoginStatus(filterContext);
                    //        return;
                    //    }
                    //}

                    #endregion


                    if (filterContext.HttpContext.Session != null)
                    {
                        var user = filterContext.HttpContext.Session.Get<UserDto> ("user");

                        //IOS 从session 获取失败，可以从header中再次获取
                        if (user == null || string.IsNullOrWhiteSpace(user.UserId))
                        {
                            var token = filterContext.HttpContext.Request.Headers["token"];
                            user = JsonConvert.DeserializeObject<UserDto>(token);
                        }

                        if (user == null || string.IsNullOrWhiteSpace(user.UserId))
                        {
                            _logger.Info("LoginCheckFilterAttribute：获取Session失败！");
                            ReturnNoLoginStatus(filterContext);
                            return;
                        }
                    }
                    else
                    {
                        filterContext.HttpContext.Response.Clear();
                        //filterContext.HttpContext.Response.Redirect("/User/LoginOn", true);
                    }


                }
                base.OnActionExecuting(filterContext);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        private static void ReturnNoLoginStatus(ActionExecutingContext filterContext)
        {
            //mvc6 判断是否是ajax请求
            //http://stackoverflow.com/questions/29282190/where-is-request-isajaxrequest-in-asp-net-core-mvc
            var isAjax = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                
                var json = new JsonResult(new ResponseBaseDto.BaseResult {
                    //StatusCode = filterContext.HttpContext.Response.StatusCode,
                    StatusCode = 302,   //未登录状态
                    ErrorMessage = "未登录，请先登录！" });
                filterContext.Result = json;
            }
            else
            {
                var obj =  new ObjectResult(new ResponseBaseDto.BaseResult
                {
                    StatusCode = 302,   //未登录状态
                    ErrorMessage = "未登录，请先登录！"
                });
                filterContext.Result = obj;
            }
            
        }

        private bool VolidateToken(string httpCookie)
        {
            string token = httpCookie;
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }
    }
}
