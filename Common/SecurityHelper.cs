using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
   public static class SecurityHelper
    {
        /// <summary>
        /// Generar un token numerico
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateNumberToken(int Length)
        {
            StringBuilder build = new StringBuilder();
            Random Aleatorio = new Random();

            for (int e = 0; e < Length; e++)
            {
                build.Append(Aleatorio.Next(0, 9));
            }
            return build.ToString();
        }

        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("D");
        }
        /// <summary>
        /// Generar una contraseña valida por la longitud especificada
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRamdonPassword(int length)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            string[] Ramdonchars = new string[]{
                "ABCDEFGHJKLMNOPQRSTUVWXYZ", //MAYUSCULAS
                "abcdefghijkmnopqrstuvwxyz", //minusculas
                "0123456789", //Numeros
                "!@$?_-" //Carecteres especiales
            };

            int? lastRnindex = null;
            int index = 0;
            while (index <= length)
            {
                int rn = random.Next(0, Ramdonchars.Length);
                if (lastRnindex != rn)
                {
                    char[] array = Ramdonchars[rn].ToCharArray();
                    builder.Append(array[random.Next(0, array.Length)]);
                    lastRnindex = rn;
                    index++;
                }
            }
            return builder.ToString();
        }

        public static string GetStringHash(string value)
        {
            using (SHA256 sha = SHA256.Create())
            {

                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(value));

                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public static bool VerifyHash(string input, string hash)
        {

            var hashOfInput = GetStringHash(input);


            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
