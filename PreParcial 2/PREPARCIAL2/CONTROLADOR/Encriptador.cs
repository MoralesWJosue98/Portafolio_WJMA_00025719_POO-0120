using System;
using System.Text;
using System.Security.Cryptography;

namespace PREPARCIAL2.CONTROLADOR
{
    public static class Encriptador
    {
        public static string CrearMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                Console.WriteLine(sb.ToString());
                return sb.ToString();
            }
        }

        public static bool CompararMD5(string cadena, string pMD5)
        {
            // Hash the input.
            string hashOfInput = CrearMD5(cadena);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return (0 == comparer.Compare(hashOfInput, pMD5));
        }
    }
}