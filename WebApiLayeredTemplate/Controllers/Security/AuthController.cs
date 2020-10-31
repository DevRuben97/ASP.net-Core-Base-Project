using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Helpers;
using Domain.Common;
using Domain.DTOs.Security;
using Domain.Entities.Security;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace API.Controllers.Security
{
    [Route(ApiRoutes.CONTROLLER)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        private readonly ILogger<AuthController> _logger;

        private readonly IConfiguration _config;
        public AuthController(
            IUserService userService, 
            ILogger<AuthController> logger, 
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _userService = userService;
        }

        [HttpPost]
        [Route(ApiRoutes.Action)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDto login)
        {
            try
            {

                var result = await this._userService.Authenticate(login.UserName, login.Password);
                if (result.OpeationSuccess)
                {
                    var user = (User)result.Data;
                    var token = GenerateJwt(user);
                    var permissions = _userService.GetUserRolePermissions(user.UserRoles.FirstOrDefault().RoleId);
                    var obj = new
                    {
                        user.UserName,
                        user.Email,
                        FullName = $"{user.Name} {user.SurName}",
                        token,
                        permissions
                    };

                    return Ok(new RequestResult(true, "Inicio de sesión completado", obj));

                }
                else
                {
                    return Ok(new RequestResult(false, "Usuario o contraseña incorrecta"));
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex.Data);
                return Ok(new RequestResult(false, null));
            }
        }

        public async Task<string> GenerateJwt(User user)
        {
            return await Task.Run(() =>
            {

                var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
                new Claim (ClaimTypes.Name, $"{user.Name} {user.SurName}"),
                new Claim(ClaimTypes.Email, user.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    NotBefore = DateTime.Now.Date,
                    SigningCredentials = creds,
                    Audience = _config.GetSection("JwtSecurityToken.ValidIssuer").Value,
                    Issuer = _config.GetSection("JwtSecurityToken.ValidIssuer").Value,
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            });
    }
    }
}
