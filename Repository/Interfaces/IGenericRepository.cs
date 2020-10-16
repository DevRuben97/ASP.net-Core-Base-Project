using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
   public interface IGenericRepository<T> where T: class, IAuditableEntity
    {
        /// <summary>
        /// Crear un nuevo registro del tipo de entidad especicado.
        /// </summary>
        /// <param name="Item">Entidad a registrar</param>
        Task CreateOne(T Item);
        /// <summary>
        /// Actualizar un registro del tipo de entidad especicado.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
      Task Update(T item);
        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
      Task<IEnumerable<T>> All();
        /// <summary>
        /// Obtener una o varios registros que cumplan con una condicion.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
      Task<IEnumerable<T>> Find(Expression<Func<T, bool>> filter);


    }
}
