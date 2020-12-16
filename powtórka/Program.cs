using System;

namespace powtórka
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            // Console.WriteLine(CalculateEaster(2021));
            DrawSigns(7);
            //CheckDailyEarnings(160);
            //Console.WriteLine(CalculateNElementOfFibonacciSequence(10));

            int[][] tablicaPostrzepiona = new int[3][];
            tablicaPostrzepiona[0] = new int[5] { 1, -58, 3, 4, 5 };
            tablicaPostrzepiona[1] = new int[3] { 10, 20, 30 };
            tablicaPostrzepiona[2] = new int[] { 12, 50, 60, 70, 32 };

            //FindMaxAndMinValueInArray(tablicaPostrzepiona);
            //Console.WriteLine(GetDepartment("[ID/Kowalski marketing/154/2012]"));
            //Console.WriteLine(GetDepartment("[ID/Sosnowska kadry/12/2019]"));


        }
        //-----------------ZADANIE 1-----------------------------------------------------------
        static DateTime CalculateEaster(int year)
        {
            if (CalculateF(year) <= 31)
            {
                return new DateTime(year, 03, CalculateF(year));
            }
            else if (CalculateG(year) == 25 || CalculateG(year) == 26)
            {
                return new DateTime(year, 04, 19);
            }
            else 
            {
                return new DateTime(year, 04, CalculateG(year));
            }
        }

        static int CalculateA(int year)
        {
            return year % 19;
        }

        static int CalculateB(int year)
        {
            return year % 4;
        }

        static int CalculateC(int year)
        {
            return year % 7;
        }

        static int CalculateD(int year)
        {
            return (19 * CalculateA(year) + CalculateX(year) ) % 30;
        }

        static int CalculateE(int year)
        {
            return (2 * CalculateB(year) + 4 * CalculateC(year) + 6 * CalculateD(year) + CalculateY(year)) % 7;
        }

        static int CalculateF(int year)
        {
            return 22 + CalculateD(year) + CalculateE(year);
        }

        static int CalculateG(int year)
        {
            return CalculateD(year) + CalculateE(year) - 9;
        }

        static int CalculateX(int year)
        {
            if (year < 1583) return 15;
            if (year >= 1583 && year < 1800) return 22;
            if (year >= 1700 && year < 1900) return 23;
            if (year >= 1900 && year < 2200) return 24;
            else return -1;
        }

        static int CalculateY(int year)
        {
            if ((year < 1583) || (year >= 2100 && year < 2200)) return 6;
            if (year >= 1583 && year < 1700) return 2;
            if (year >= 1700 && year < 1800) return 3;
            if (year >= 1800 && year < 1900) return 4;
            if (year >= 1900 && year < 2100) return 5;
            else return -1;
        }

        //---------------------------ZADANIE 2 -------------------------------------------

        static void DrawGiantSlalom(int value) 
        {
            for (int i = 1; i <= value; i++) 
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine((new string('*', value)));
                }
                else
                {
                    Console.WriteLine((new string(' ', value-1)) + new string('*', value));
                }
            }
        }

        static void DrawZorro(int value)
        {

          Console.WriteLine((new string('*', value)));
            for (int i = 1; i < value-1; i++) 
            {         
                 Console.WriteLine((new string(' ', value - i -1 )) + "*");  
            }
          Console.WriteLine((new string('*', value)));

        }

        static void DrawT(int value)
        {

            Console.WriteLine((new string('*', value)));
            for (int i = 1; i < value; i++)
            {
               Console.WriteLine((new string(' ', value / 2)) + "*");
            }
           

        }

        static void DrawSigns(int value)
        {
            DrawGiantSlalom(value);
            DrawZorro(value);
            DrawT(value);
        }

        //-------------------------------ZADANIE 3--------------------------------------------------------

        public static double  Wariant1(int hours) 
        {
            return 50 * hours;
        }

        public static double Wariant2(int hours)
        {
            double wynik = 0.1;

            for (int i = 2; i <= hours; i++)
            {
                wynik = wynik * 2;
            }
            return wynik;
        }

        public static void CheckDailyEarnings(int hours) 
        {
            if (Wariant1(hours) > Wariant2(hours))
            {
                Console.WriteLine("Wybierz stałą stawkę");
            }
            else if (Wariant1(hours) < Wariant2(hours))
            {
                Console.WriteLine("Wybierz stawkę rosnącą");
            }else
            {
                Console.WriteLine("To nie ma znaczenia co wybierzesz");
            }
        }

        //------------------------ZADANIE 4--------------------------------------------------------

        public static int CalculateNElementOfFibonacciSequence(int n) 
        {
            if ((n == 1) || (n == 2))
                return 1;
            else
                return CalculateNElementOfFibonacciSequence(n - 1) + CalculateNElementOfFibonacciSequence(n - 2);
        }
        //--------------------ZADANIE 5-------------------------------------------------------------------


        static void FindMaxAndMinValueInArray(int[][] array)
        {

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < array.Length; i++) 
            {
                for (int j = 0; j < array[i].Length; j++) 
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }

                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }

                }
            }

            Console.WriteLine($"Największa wartość w tablicy to {max}, a najmniejsza wartość w tablicy to {min}");
        }

        //-----------------------ZADANIE 6----------------------------------------------------

        static String GetDepartment(String id)
        { 
            int lastIndex = 0;
            int counter = 0;
            int space = id.IndexOf(' ');

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == '/')
                {
                    counter++;
                    if (counter == 2) {
                        lastIndex = i;
                        break;
                    }
                }
            }
            return id.Substring(space + 1, id.Length - (space + (id.Length - lastIndex + 1)));
        }

    }
}
