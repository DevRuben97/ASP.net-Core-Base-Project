using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Validaciones de los objectos enviados por el cliente.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errores = context.ModelState
                    .Where(s => s.Value.Errors.Count > 0)
                    .ToDictionary(key => key.Key, name => name.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                var result = new RequestResult();
                result.HasValidationErrors = true;
                result.Message = "La información suminstrada es invalida.";

                foreach(var error in errores)
                {
                    foreach(var subError in error.Value)
                    {
                        var validation = new ObjectErrors()
                        {
                            FieldName = error.Key,
                            Message = subError
                        };

                        result.ValidationErrors.Add(validation);
                    }
                }

                context.Result = new OkObjectResult(result);
                return;
            }
            else
            {
               await next();
            }
        }
    }
}
