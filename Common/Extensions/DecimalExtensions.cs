using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Comvertir un valor de tipo decimal a un string en formato de moneda
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrencyFormat(this decimal value)
        {

            return value.ToString("C2");
        }
        /// <summary>
        /// Comvertir un valor de tipo decimal a un string en formato de moneda
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCurrencyFormat(this decimal? value)
        {
            if (value.HasValue)
            {

                return value.Value.ToString("C2");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
