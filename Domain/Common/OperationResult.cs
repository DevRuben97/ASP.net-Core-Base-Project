using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    /// <summary>
    /// Clase diseñada para retornar el resultado de una operación realizada
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Especifica si la operación realizada fue exitosa.
        /// </summary>
        public bool OpeationSuccess { get; set; }
        /// <summary>
        /// Mensaje resultante de la operación
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Infor4mación Adicional.
        /// </summary>
        public object Data { get; set; }
    }
}
