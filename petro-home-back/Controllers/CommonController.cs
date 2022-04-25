using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using petro_home_back.Model.Response;
using petro_home_back.Service;
using System.Globalization;

namespace petro_home_back.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]
    public class CommonController : ControllerBase
    {
        private readonly ResponseService _responseService;

        public CommonController()
        {
            _responseService = new();
        }

        [HttpPost]
        public CommonResult SetLanguage([FromForm]string lang)
        {
            CultureInfo cultureInfo;
            switch (lang)
            {
                case "en": cultureInfo = new("en"); break;
                case "ko": cultureInfo = new("ko"); break;
                default: lang = "en"; cultureInfo = new("en"); break;
            }

            Response.Cookies.Append("lang-type", lang);
//            Response.Cookies.Append(
//                CookieRequestCultureProvider.DefaultCookieName,
//                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
//                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
//            );
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            return _responseService.GetSuccessResult();
        }
    }
}
