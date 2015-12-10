using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day4 : IDay
    {
        public int GetDayNumber()
        {
            return 4;
        }

        public DayResult GetResult(string input)
        {
            string hash = "";
            int i = 0;

            using (MD5 md5Hash = MD5.Create())
            {
                while (!hash.StartsWith("00000"))
                {
                    i++;
                    hash = GetMd5Hash(md5Hash, input + i.ToString());
                }
            }

            return new DayResult(i.ToString());
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
