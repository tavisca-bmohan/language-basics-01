using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public class FixMultiplication
    {
        public static int FindDigit(string equation)
        {
            // a * b = c
            //Extrct 3 numbers

            var indexOfMultiply = equation.IndexOf('*');
            var indexOfEqual = equation.IndexOf('=');
            var multiplier1 = equation.Substring(0, indexOfMultiply);
            var multiplier2 = equation.Substring(indexOfMultiply + 1, indexOfEqual - indexOfMultiply - 1);
            var result = equation.Substring(indexOfEqual + 1, equation.Length - indexOfEqual - 1);

            var missingDigitPlaceHolder = multiplier1.Contains('?') ? 1 : multiplier2.Contains('?') ? 2 : 3;    //finding position of '?' in the string

            //Console.WriteLine($"{multiplier1} {multiplier2} {result}")

            // converting string to int
            int first = 0;
            int second = 0;
            int third = 0;
            if (missingDigitPlaceHolder != 1)
                int.TryParse(multiplier1, out first);

            if (missingDigitPlaceHolder != 2)
                int.TryParse(multiplier2, out second);

            if (missingDigitPlaceHolder != 3)
                int.TryParse(result, out third);

            //finding third value
            int temp = 0;
            int Ceil_value = 0;

            if (missingDigitPlaceHolder == 1 && second != 0)
            {
                temp = third / second;
                Ceil_value = (int)Math.Ceiling((double)third / second);
                if (temp != Ceil_value) return -1;
            }
            else if (missingDigitPlaceHolder == 2 && first != 0)
            {
                temp = third / first;
                Ceil_value = (int)Math.Ceiling((double)third / first);
                if (temp != Ceil_value) return -1;
            }
            else if (missingDigitPlaceHolder == 3)
            {
                temp = first * second;
            }

            //calculating ans
            string temp2 = temp.ToString();
            var numberContainsMissingDigit = missingDigitPlaceHolder == 1 ? multiplier1 : missingDigitPlaceHolder == 2 ? multiplier2 : result;

            if (numberContainsMissingDigit.Length != temp2.Length)
                return -1;
            for (int i = 0; i < numberContainsMissingDigit.Length; i++)
            {
                if (numberContainsMissingDigit[i] == '?')
                    return temp2[i] - '0';
                else if (numberContainsMissingDigit[i] != temp2[i])
                    return -1;
            }

            return -1;
        }
    }
}
