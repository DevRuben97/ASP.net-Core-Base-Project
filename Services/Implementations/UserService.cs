using AutoMapper;
using Domain.Common;
using Domain.DTOs.Security;
using Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Services.Base;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : CommonService<User, UserDto>, IUserService
    {
        private UserManager<User> _userManager;

        public UserService(IMapper mapper, IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork, UserManager<User> userManager) : base(mapper, genericRepository, unitOfWork)
        {
            this._userManager = userManager;
        }

        public async Task<OperationResult> Authenticate(string User, string password)
        {
            var user = await this._userManager.FindByNameAsync(User);
            if (user == null)
                user = await this._userManager.FindByEmailAsync(User);

            if (user== null)
            {
                return new OperationResult()
                {
                    Message = "Usuario o contraseña incorrectas",
                    OpeationSuccess = false
                };
            }
            else
            {
                var passwordCheckResult = await _userManager.CheckPasswordAsync(user, password);

                return new OperationResult()
                {
                    OpeationSuccess = passwordCheckResult,
                    Message = passwordCheckResult ? "Usuario Valido" : "El usuario o contraseña son invalidos",
                    Data= user
                };
            }
        }
    }
}
