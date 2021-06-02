using System;

namespace Utils
{
    public static class Interpreter
    {
        public static string[] Categories = new[]
        {
            string.Empty, "K", "M", "B", "T"
        };
        public static string numbersToLetters(long number)
        {
            int category = 0;

            if (number < 0) 
                throw new ArgumentOutOfRangeException(nameof(number), "число меньше 0");

            while (number >= 1000L)
            {
                number /= 1000L;
                category++;
            }
            return number + Categories[category];
        }
    }
}