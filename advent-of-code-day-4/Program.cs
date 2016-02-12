﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace advent_of_code_day_4
{
    internal class Program
    {
        private const string Input = "ckczppom";

        static void Main(string[] args)
        {
            SolvePuzzle(Input);
        }

        private static void SolvePuzzle(string input)
        {
            var i = 1;
            while (true)
            {
                var testing = input + i;
                var result = GenerateMd5Hash(testing);

                Console.WriteLine("Testing: " + testing + " | Result: " + result);

                if (result.StartsWith("00000", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Final Result: " + testing);
                    break;
                }

                i++;
            }

            Console.ReadLine();
        }

        private static string GenerateMd5Hash(string source)
        {
            var sb = new StringBuilder();
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));

                foreach (var t in data)
                {
                    sb.Append(t.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}