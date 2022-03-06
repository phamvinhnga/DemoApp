using DemoABC.Base.interfaces;
using DemoABC.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoABC.Filters
{
    public class NotAllowSpecialCharactersAttribute : ActionFilterAttribute
    {
        private readonly string _property;
        private readonly Regex _charSet = new Regex("[^A-Za-z0-9]");

        public NotAllowSpecialCharactersAttribute(
            string property
        )
        {
            _property = property;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var input = context.ActionArguments.First().Value;
            var value = input.GetType().GetProperty(_property).GetValue(input, null).ToString();

            if (_charSet.IsMatch(value)) {
                throw new NotAllowSpecialCharaterException($"Property { _property } has special character.");
            }

            base.OnActionExecuting(context);
        }
    }
}
