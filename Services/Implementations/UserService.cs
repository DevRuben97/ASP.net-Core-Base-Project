using AutoMapper;
using Domain.Common;
using Domain.DTOs.Security;
using Domain.DTOs.Security.Permissions;
using Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Repository.Interfaces.Security;
using Services.Base;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : CommonService<User, UserDto>, IUserService
    {
        private UserManager<User> _userManager;

        private IUserRepository _UserRepository;

        public UserService(IMapper mapper, IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork, UserManager<User> userManager, IUserRepository userRepository) : base(mapper, genericRepository, unitOfWork)
        {
            this._userManager = userManager;
            this._UserRepository = userRepository;
        }
        /// <summary>
        /// Get the user based en userName and Password
        /// </summary>
        /// <param name="User"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Get the user Roles permissions:
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserModulesDto>> GetUserRolePermissions(int UserId)
        {
            var role = await this._UserRepository.GetRole(UserId);

            var permissions = role.Permissions.Select(s => s.Module).ToList();
            var list = _mapper.Map<List<UserModulesDto>>(permissions);

            return list;
        }
    }
}
