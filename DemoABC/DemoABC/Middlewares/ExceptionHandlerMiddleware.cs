using DemoABC.Base;
using DemoABC.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemoABC.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(NotAllowSpecialCharaterException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsJsonAsync(ex.Message);

                Log.Error(ex.Message);
            }                
            catch(LoginException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Locked;

                await context.Response.WriteAsJsonAsync(ex.Message);

                Log.Warning(ex.Message);
            }            
            catch(RegisterException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var errors = ex.Message.ConvertFromJson<List<IdentityError>>();

                foreach (var item in errors)
                {
                    await context.Response.WriteAsJsonAsync(item.Description);

                    Log.Warning(item.Description);
                }
            }
        }
    }
}
