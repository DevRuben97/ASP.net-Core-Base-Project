using Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Session
{
  public  interface ICurrentUser
    {
        /// <summary>
        /// Obtener el usuario actual de la aplicación.
        /// </summary>
        /// <returns></returns>
        Task<CurrentUser> GetUser();
    }
}
