using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
   public static class StringExtensions
    {
        /// <summary>
        /// Convertir un valor de moneda en un decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal CurrencyToDecimal(this string value)
        {

            return decimal.Parse(value, System.Globalization.NumberStyles.Currency);
        }
        /// <summary>
        /// Remover los espacios en blanco
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveWhiteSpaces(this string value)
        {
            return value.Replace(" ", "");
        }
        /// <summary>
        /// Obtener el numero de palabras en un texto
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int WordsCount(this string value)
        {

            int count = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == ' ' || value[i] == '\n' || value[i] == '\t')
                {
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// Obtener el numero de palabras de un string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int LettersCount(this string value)
        {

            return value.ToCharArray()
            .Where(s => !char.IsWhiteSpace(s))
            .Count();
        }
    }
}
