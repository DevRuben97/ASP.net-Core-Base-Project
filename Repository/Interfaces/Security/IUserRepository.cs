using Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Security
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Obtener la Información completa del usuario.
        /// </summary>
        /// <param name="Id">Id del Usuario</param>
        /// <returns></returns>
        Task<User> GetFullUserInfo(int Id);
        /// <summary>
        /// Get the user Role.
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        Task<Role> GetRole(int UserId);

    }
}
