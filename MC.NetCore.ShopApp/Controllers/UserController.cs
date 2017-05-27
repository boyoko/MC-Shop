using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MC.NetCore.Repository;
using MC.NetCore.ShopApp.ResponseBaseDto;
using MC.NetCore.DomainModels.RequestDto;
using Microsoft.AspNetCore.Http;
using MC.NetCore.DomainModels.Dto;
using MC.NetCore.ShopApp.Extension;
using Microsoft.Extensions.Logging;

namespace MC.NetCore.ShopApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowAnyDomain")]
    public class UserController : Controller
    {
        private readonly IShopUserRepository _shopUserRepository;
        private readonly ILogger<UserController> _logger;


        public UserController(IShopUserRepository shopUserRepository
            , ILogger<UserController> logger)
        {
            _shopUserRepository = shopUserRepository;
            _logger = logger;
        }

        

        [HttpPost]
        public async Task<IActionResult> LoginOn([FromBody]LoginOnRequestDto request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                throw new ArgumentNullException(nameof(request.UserName));
            }
            try
            {
                //var result = _shopUserRepository.LoginOn(request).GetAwaiter().GetResult();
                var result = await _shopUserRepository.LoginOn(request);
                if (result != null)
                {
                    //…Ë÷√cookie
                    Response.Cookies.Append("userId", result.UserId);

                    _logger.LogInformation("---------userId-----------:" + result.UserId);


                    //…Ë÷√session
                    HttpContext.Session.Set<UserDto>("user", result);
                    return new ObjectResult(new BaseResult { StatusCode = Response.StatusCode, Value = result });
                }
                return new ObjectResult(new BaseResult { StatusCode = 400, ErrorMessage= "µ«¬º ß∞‹£°" });

            }
            catch (Exception ex)
            {
                _logger.LogError("LoginOn:" + ex.Message);
                return new ObjectResult(new BaseResult { StatusCode = Response.StatusCode, ErrorMessage = ex.Message });
            }
            
        }


        

        public IActionResult LoginOut()
        {
            var httpCookie = Request.Cookies["userId"];
            if (!string.IsNullOrEmpty(httpCookie))
            {
                Response.Cookies.Delete("userId");
            }

            if (HttpContext.Session.Get("user") != null)
            {
                HttpContext.Session.Remove("user");
                HttpContext.Session.Clear();
            }
            return new ObjectResult(new BaseResult { StatusCode = Response.StatusCode});
        }

    }
}