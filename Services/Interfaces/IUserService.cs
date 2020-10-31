using Domain.Common;
using Domain.DTOs.Security;
using Domain.DTOs.Security.Permissions;
using Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService: ICommonService<User, UserDto>
    {
        /// <summary>
        /// Authentica el Usuario con las credenciales suministradas.
        /// </summary>
        /// <param name="User">Nombre de Usuario o correo electronico</param>
        /// <param name="password">Clave de seguridad</param>
        /// <returns></returns>
        Task<OperationResult> Authenticate(string User, string password);

        Task<IEnumerable<UserModulesDto>> GetUserRolePermissions(int UserId);
    }
}
