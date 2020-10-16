using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        /// Guardar todos los cambios realizados en las entidandes en la base de datos 
        /// </summary>
        /// <returns></returns>
        Task<OperationResult> CommitChanges();
    }
}
