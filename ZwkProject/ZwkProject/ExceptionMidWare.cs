using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ZwkProject
{
    public class ExceptionMidWare
    {

        private readonly RequestDelegate _next;


        public ExceptionMidWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
