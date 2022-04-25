using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySql.Data.MySqlClient;
using petro_home_back.Data.Advice.Exceptions;
using petro_home_back.Model.Response;
using petro_home_back.Service;

namespace petro_home_back.Data.Advice
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public HttpResponseExceptionFilter()
        {
            _responseService = new();
            _exceptionDict = new();
        }
        private ExceptionDict _exceptionDict;
        private readonly ResponseService _responseService;
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) 
        {
            _exceptionDict.InitLang(context.HttpContext.Request.Cookies["lang-type"] ?? "ko");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
            else if (context.Exception is MySqlException mysqlException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.Unknown, mysqlException.Message));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is UserNotFoundException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.UserNotFound, _exceptionDict.GetMessage(ExceptionKoList.UserNotFound)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is SignInFailedException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.SignInFailed, _exceptionDict.GetMessage(ExceptionKoList.SignInFailed)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is SignUpFailedException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.SignUpFailed, _exceptionDict.GetMessage(ExceptionKoList.SignUpFailed)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is AccessDeniedException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.AccessDenied, _exceptionDict.GetMessage(ExceptionKoList.AccessDenied)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is CommunicationException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.CommunicationError, _exceptionDict.GetMessage(ExceptionKoList.CommunicationError)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ResourceNotExistException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.ResourceNotExist, _exceptionDict.GetMessage(ExceptionKoList.ResourceNotExist)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is NotOwnerException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.NotOwner, _exceptionDict.GetMessage(ExceptionKoList.NotOwner)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is AuthenticationEntryPointException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.ForbiddenWord, _exceptionDict.GetMessage(ExceptionKoList.ForbiddenWord)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is AuthenticationEntryPointException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.FileUpload, _exceptionDict.GetMessage(ExceptionKoList.FileUpload)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is AuthenticationEntryPointException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.FileDownload, _exceptionDict.GetMessage(ExceptionKoList.FileDownload)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception is AuthenticationEntryPointException)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.ExpiredUser, _exceptionDict.GetMessage(ExceptionKoList.ExpiredUser)));
                context.ExceptionHandled = true;
            }
            else if (context.Exception != null)
            {
                context.Result = SetObjectResult(_responseService.GetFailResult(ExceptionKoList.Unknown, context?.Exception?.Message ?? _exceptionDict.GetMessage(ExceptionKoList.Unknown)));
                if (context != null)
                {
                    context.ExceptionHandled = true;
                }
            }
        }

        private ObjectResult SetObjectResult(ICommonResult exception)
        {
            return new ObjectResult(_responseService.GetFailResult(exception.Code, exception.Msg))
            {
                StatusCode = 401,
            };
        }
    }
}
