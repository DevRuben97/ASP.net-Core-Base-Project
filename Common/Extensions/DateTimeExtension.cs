using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
   public static class DateTimeExtension
    {
        /// <summary>
        /// Obtener el primer dia de una fecha.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }
        /// <summary>
        /// Obtener el primer dia de una fecha basado en un dia de la semana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfYear(this DateTime dt, DayOfWeek dow)
        {
            return dt.FirstDayOfYear().NextDay(dow, true);
        }
        /// <summary>
        /// Obtener el ultimo dia de una fecha
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dt)
        {
            return dt.FirstDayOfYear().AddYears(1).AddDays(-1);
        }
        /// <summary>
        /// Obtener el utimo dia de una fecha basado en una dia de la semana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime LastDayOfYear(this DateTime dt, DayOfWeek dow)
        {
            return dt.LastDayOfYear().PreviousDay(dow, true);
        }
        /// <summary>
        /// Obtener el primer dia de un mes
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        /// <summary>
        /// Obtener el primer dia de un mes basado en un dia de la semana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dt, DayOfWeek dow)
        {
            return dt.FirstDayOfMonth().NextDay(dow, true);
        }
        /// <summary>
        /// Obtener el ultimo dia de un mes
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }
        /// <summary>
        /// Obtener el ultimo dia de un mes basado en el dia de la semana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dt, DayOfWeek dow)
        {
            return dt.LastDayOfMonth().PreviousDay(dow, true);
        }
        /// <summary>
        /// Obtener el dia anterior
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime dt)
        {
            return dt.Date.AddDays(-1);
        }
        /// <summary>
        /// Obtener el dia anterior de un dia de semana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime dt, DayOfWeek dow)
        {
            return dt.PreviousDay(dow, false);
        }
        /// <summary>
        /// Obtener el dia anterior de una fecha basado en un dia de la semana.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow">Dia de la semana</param>
        /// <param name="includeThis"></param>
        /// <returns></returns>
        public static DateTime PreviousDay(this DateTime dt, DayOfWeek dow, bool includeThis)
        {
            int diff = dt.DayOfWeek - dow;
            if ((includeThis && diff < 0) || (!includeThis && diff <= 0)) diff += 7;
            return dt.Date.AddDays(-diff);
        }
        /// <summary>
        /// Obtener el dia siguiente
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime dt)
        {
            return dt.Date.AddDays(1);
        }
        /// <summary>
        /// Obtener el dia siguiente de un dia de la semana
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static DateTime NextDay(this DateTime dt, DayOfWeek dow)
        {
            return dt.NextDay(dow, false);
        }

        public static DateTime NextDay(this DateTime dt, DayOfWeek dow, bool includeThis)
        {
            int diff = dow - dt.DayOfWeek;
            if ((includeThis && diff < 0) || (!includeThis && diff <= 0)) diff += 7;
            return dt.Date.AddDays(diff);
        }
        /// <summary>
        /// Obtener la cantidad de dias en un año
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int DaysInYear(this DateTime dt)
        {
            return (dt.LastDayOfYear() - dt.FirstDayOfYear()).Days + 1;
        }
        /// <summary>
        /// Obtener la cantidad de dias en un año
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dow"></param>
        /// <returns></returns>
        public static int DaysInYear(this DateTime dt, DayOfWeek dow)
        {
            return (dt.LastDayOfYear(dow).DayOfYear - dt.FirstDayOfYear(dow).DayOfYear) / 7 + 1;
        }

        public static int DaysInMonth(this DateTime dt)
        {
            return (dt.LastDayOfMonth() - dt.FirstDayOfMonth()).Days + 1;
        }

        public static int DaysInMonth(this DateTime dt, DayOfWeek dow)
        {
            return (dt.LastDayOfMonth(dow).Day - dt.FirstDayOfMonth(dow).Day) / 7 + 1;
        }
        /// <summary>
        /// Detectar si es un año biniestro
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLeapYear(this DateTime dt)
        {
            return dt.DaysInYear() == 366;
        }
        /// <summary>
        /// Agregar semanas a una fecha
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static DateTime AddWeeks(this DateTime dt, int weeks)
        {
            return dt.AddDays(7 * weeks);
        }
        /// <summary>
        /// Formatear una fecha al formato dd/MM/yyyy
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToFormat(this DateTime dt)
        {

            return dt.ToString("dd/MM/yyyy");
        }
        /// <summary>
        /// Obtener la diferencia en dias entre dos fechas
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double DifferenceInDays(this DateTime a, DateTime b)
        {

            return (a - b).TotalDays;
        }
        /// <summary>
        /// Obtener la diferencia en meses entre dos fechas
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int DifferenceInMothods(this DateTime a, DateTime b)
        {
            return (a.Year - b.Year) * 12 + (a.Month - b.Month);
        }
        /// <summary>
        /// Obtener la diferencia en años entre dos fechas
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int DifferenceInYears(this DateTime a, DateTime b)
        {
            return a.Year - b.Year;
        }
        /// <summary>
        /// Obtener la diferencia en dias, meses y años entre dos fechas
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Difference(this DateTime a, DateTime b)
        {

             double Days = a.DifferenceInDays(b);
             int Mothods = a.DifferenceInMothods(b);
             int Years = a.DifferenceInYears(b);


            return $"La diferencia es: {Days} Dias, {Mothods} Meses, {Years} Años.";
        }
        /// <summary>
        /// Obtener la diferencia en dias, meses y años entre dos fechas retornando
        /// la diferencia en un array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int[] TotalDifference(this DateTime a, DateTime b)
        {

             int Days =Convert.ToInt32(a.DifferenceInDays(b));
             int Mothods = a.DifferenceInMothods(b);
             int Years = a.DifferenceInYears(b);


            return new int[] { Days, Mothods, Years };
        }
    }
}
