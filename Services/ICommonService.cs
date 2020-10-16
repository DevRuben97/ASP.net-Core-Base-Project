using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public  interface ICommonService<T, Dto> where T : class, IAuditableEntity, IEntity
    {
        /// <summary>
        /// Crear un nuevo registro del tipo de entidad especificado.
        /// </summary>
        /// <param name="Item">Entidad a registrar</param>
        Task<OperationResult> CreateOneAsync(Dto Item);
        /// <summary>
        /// Actualizar un registro del tipo de entidad especicado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<OperationResult> UpdateAsync(Dto item);

        /// <summary>
        /// Cambiar el estado de un registro.
        /// </summary>
        /// <param name="id">Id del registro</param>
        /// <param name="state">El Estado ha cambiar</param>
        /// <returns></returns>
        Task<OperationResult> ChangeStateAsync(int id, string state);

        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Obtener un registro por id.
        /// </summary>
        /// <param name="id">Id del registro</param>
        /// <returns></returns>
        Task<Dto> FindByIdAsync(int Id);
    }
}
