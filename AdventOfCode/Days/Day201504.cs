/*
 *  Copyright (c) Johan Boström. All rights reserved.
 *  Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
 */

namespace AdventOfCode.Days
{
    using System.Security.Cryptography;
    using System.Text;

    public class Day201504 : IDay
    {
        public int Year => 2015;
        public int Day => 4;

        public DayResult GetResult(string input)
        {
            var i = 0;
            int startWith5 = 0, startWith6 = 0;

            using (var md5Hash = MD5.Create())
            {
                while (startWith5 == 0 || startWith6 == 0)
                {
                    i++;
                    var hash = GetMd5Hash(md5Hash, input + i);

                    if (startWith5 == 0 && hash.StartsWith("00000"))
                    {
                        startWith5 = i;
                    }

                    if (startWith6 == 0 && hash.StartsWith("000000"))
                    {
                        startWith6 = i;
                    }
                }
            }

            return new DayResult(startWith5.ToString(), startWith6.ToString());
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}