using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Domain.DTOs.Security;
using Domain.Entities.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace API.Controllers.Security
{
    [Route(ApiRoutes.CONTROLLER)]
    [ApiController]
    public class UserController : InitialController<User, UserDto>
    {

        public UserController(ICommonService<User, UserDto> service, ILogger<User> logger) : base(service, logger)
        {
            this._ControllerName = "Usuarios";
        }
        [HttpPost]
        public override Task<IActionResult> New(UserDto item)
        {
            return base.New(item);
        }
    }
}
