﻿namespace _03.Non_Digit_Count
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main()
        {
            var pattern = @"\D";
            var input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
