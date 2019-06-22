using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // a * b = c
            string a = "";
            string b = "";
            string c = "";
            int n = equation.Length;
            int i = 0;
            int ques_mark = 0;
            //Extrct 3 numbers
            //first number
            while (i < n)
            {
                if (equation[i] == '?') ques_mark = 1;
                if (equation[i] == '*')
                {
                    i++;
                    break;
                }
                else
                {
                    a += equation[i];
                }
                i++;
            }
            //second number
            while (i < n)
            {
                if (equation[i] == '?') ques_mark = 2;
                if (equation[i] == '=')
                {
                    i++;
                    break;
                }
                else
                {
                    b += equation[i];
                }
                i++;
            }
            //third number
            while (i < n)
            {
                if (equation[i] == '?') ques_mark = 3;
                c += equation[i];
                i++;
            }
            // converting string to int
            int first = 0;
            int second = 0;
            int third = 0;
            if (ques_mark != 1)
            {
                first = int.Parse(a);
            }
            if (ques_mark != 2)
            {
                second = int.Parse(b);
            }
            if (ques_mark != 3)
            {
                third = int.Parse(c);
            }

            //finding third value
            int temp = 0;
            int Ceil_value = 0;
            if (ques_mark == 1)
            {
                temp = third / second;
                Ceil_value = (int)Math.Ceiling((double)third / second);
                if (temp != Ceil_value) return -1;
            }
            else if (ques_mark == 2)
            {
                temp = third / first;
                Ceil_value = (int)Math.Ceiling((double)third / first);
                if (temp != Ceil_value) return -1;
            }
            else
            {
                temp = first * second;
            }

            //calculating ans
            string temp2 = temp.ToString();
            switch (ques_mark)
            {
                case 1: //if question mark is present in first no.
                    if (a.Length != temp2.Length) return -1;

                    for (int j = 0; j < a.Length; j++)
                    {
                        if (a[j] == '?')
                            return temp2[j] - '0';
                        else if (a[j] != temp2[j])
                        {
                            return -1;
                        }
                    }
                    break;
                case 2://if question mark is present in second no.
                    if (b.Length != temp2.Length) return -1;
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (b[j] == '?')
                            return temp2[j] - '0';
                        else if (b[j] != temp2[j])
                        {
                            return -1;
                        }
                    }
                    break;
                case 3://if question mark is present in third no.
                    if (c.Length != temp2.Length) return -1;
                    for (int j = 0; j < c.Length; j++)
                    {
                        if (c[j] == '?')
                            return temp2[j] - '0';
                        else if (c[j] != temp2[j])
                        {
                            return -1;
                        }
                    }
                    break;
                    //default :
                    //return -1;
            }

            //throw new NotImplementedException();
            return -1;
        }
    }
}
