using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
   public static class IntegerExtensions
    {
        /// <summary>
        /// Agregar ceros a la izquierda del valor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string LeadingZeros(this int value, int n)
        {
            return value.ToString().PadLeft(n, '0');
        }
        /// <summary>
        /// Agregar ceros a la izquierda del valor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string LeadingZeros(this int? value, int n)
        {
            if (value.HasValue)
            {
                return value.ToString().PadLeft(n, '0');
            }
            else
            {
                return "0";
            }
        }
        /// <summary>
        /// Convirte un entero nullable con valor a un nulo
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToNullValue(this int? value)
        {

            if (value.HasValue)
            {
                return (int?)null;
            }
            else
            {
                return value;
            }
        }
    }
}
