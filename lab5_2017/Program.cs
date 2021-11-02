﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3z
{
    class Program
    {
        static void CheckTest(string expected, string output)
        {
            if (output.Equals(expected))
                Console.WriteLine(" OK");
            else
                Console.WriteLine(" EROR!! oczekiwano: " + expected);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- TEST 1 ---");
            NumberInBase n1t1 = new NumberInBase();
            NumberInBase n2t1 = new NumberInBase(1234);
            NumberInBase n3t1 = new NumberInBase("101", 2);

            Console.Write("n1t1: " + n1t1.Print());
            CheckTest("(0)_10", n1t1.Print());
            Console.Write("n2t1: " + n2t1.Print());
            CheckTest("(1234)_10", n2t1.Print());
            Console.Write("n3t1: " + n3t1.Print());
            CheckTest("(101)_2", n3t1.Print());

            Console.WriteLine();
            Console.WriteLine("--- TEST 2 ---");
            NumbersConverter converter = new NumbersConverter();

            //Konwersja z systemu binarnego na dziesiętny
            Console.WriteLine();
            Console.WriteLine("--- TEST 3.1 ---");
            int n1t21 = converter.ConvertToDecimal(new NumberInBase("0", 2));
            int n2t21 = converter.ConvertToDecimal(new NumberInBase("1", 2));
            int n3t21 = converter.ConvertToDecimal(new NumberInBase("1101", 2));
            int n4t21 = converter.ConvertToDecimal(new NumberInBase("11001100", 2));
            int n5t21 = converter.ConvertToDecimal(new NumberInBase("11111", 2));
            int n6t21 = converter.ConvertToDecimal(new NumberInBase("1000000000000000", 2));

            Console.Write("n1t21: " + n1t21);
            CheckTest("0", n1t21.ToString());
            Console.Write("n2t21: " + n2t21);
            CheckTest("1", n2t21.ToString());
            Console.Write("n3t21: " + n3t21);
            CheckTest("13", n3t21.ToString());
            Console.Write("n4t21: " + n4t21);
            CheckTest("204", n4t21.ToString());
            Console.Write("n5t21: " + n5t21);
            CheckTest("31", n5t21.ToString());
            Console.Write("n6t21: " + n6t21);
            CheckTest("32768", n6t21.ToString());

            //Konwersja z systemów o podstawach 3 - 10 (bez użycia liter) na dziesiętny
            Console.WriteLine();
            Console.WriteLine("--- TEST 3.2 ---");
            int n1t22 = converter.ConvertToDecimal(new NumberInBase("111222", 3));
            int n2t22 = converter.ConvertToDecimal(new NumberInBase("3333333", 4));
            int n3t22 = converter.ConvertToDecimal(new NumberInBase("31415", 6));
            int n4t22 = converter.ConvertToDecimal(new NumberInBase("777666", 8));
            int n5t22 = converter.ConvertToDecimal(new NumberInBase("86420", 9));
            int n6t22 = converter.ConvertToDecimal(new NumberInBase("987123", 10));

            Console.Write("n1t22: " + n1t22);
            CheckTest("377", n1t22.ToString());
            Console.Write("n2t22: " + n2t22);
            CheckTest("16383", n2t22.ToString());
            Console.Write("n3t22: " + n3t22);
            CheckTest("4259", n3t22.ToString());
            Console.Write("n4t22: " + n4t22);
            CheckTest("262070", n4t22.ToString());
            Console.Write("n5t22: " + n5t22);
            CheckTest("57204", n5t22.ToString());
            Console.Write("n6t22: " + n6t22);
            CheckTest("987123", n6t22.ToString());

            //Konwersja z systemów o podstawach 11 - 30 (z użyciem liter) na dziesiętny
            Console.WriteLine();
            Console.WriteLine("--- TEST 3.3 ---");
            int n1t23 = converter.ConvertToDecimal(new NumberInBase("AA5", 11));
            int n2t23 = converter.ConvertToDecimal(new NumberInBase("FA01", 16));
            int n3t23 = converter.ConvertToDecimal(new NumberInBase("FBI", 23));
            int n4t23 = converter.ConvertToDecimal(new NumberInBase("101", 25));
            int n5t23 = converter.ConvertToDecimal(new NumberInBase("ALA", 28));
            int n6t23 = converter.ConvertToDecimal(new NumberInBase("Q22", 30));

            Console.Write("n1t23: " + n1t23);
            CheckTest("1325", n1t23.ToString());
            Console.Write("n2t23: " + n2t23);
            CheckTest("64001", n2t23.ToString());
            Console.Write("n3t23: " + n3t23);
            CheckTest("8206", n3t23.ToString());
            Console.Write("n4t23: " + n4t23);
            CheckTest("626", n4t23.ToString());
            Console.Write("n5t23: " + n5t23);
            CheckTest("8438", n5t23.ToString());
            Console.Write("n6t23: " + n6t23);
            CheckTest("23462", n6t23.ToString());


            //Konwersja z systemu dziesiętnego na binarny
            Console.WriteLine();
            Console.WriteLine("--- TEST 4.1 ---");
            NumberInBase n1t31 = converter.ConvertFromDecimal(9, 2);
            NumberInBase n2t31 = converter.ConvertFromDecimal(5461, 2);
            NumberInBase n3t31 = converter.ConvertFromDecimal(8191, 2);
            NumberInBase n4t31 = converter.ConvertFromDecimal(524288, 2);
            NumberInBase n5t31 = converter.ConvertFromDecimal(986895, 2);
            NumberInBase n6t31 = converter.ConvertFromDecimal(0, 2);

            Console.Write("n1t31: " + n1t31.Print());
            CheckTest("(1001)_2", n1t31.Print());
            Console.Write("n2t31: " + n2t31.Print());
            CheckTest("(1010101010101)_2", n2t31.Print());
            Console.Write("n3t31: " + n3t31.Print());
            CheckTest("(1111111111111)_2", n3t31.Print());
            Console.Write("n4t31: " + n4t31.Print());
            CheckTest("(10000000000000000000)_2", n4t31.Print());
            Console.Write("n5t31: " + n5t31.Print());
            CheckTest("(11110000111100001111)_2", n5t31.Print());
            Console.Write("n6t31: " + n6t31.Print());
            CheckTest("(0)_2", n6t31.Print());

            //Konwersja z systemu dziesiętnego na systemy o podstawach 3 - 10 (bez użycia liter)
            Console.WriteLine();
            Console.WriteLine("--- TEST 4.2 ---");
            NumberInBase n1t32 = converter.ConvertFromDecimal(429072, 3);
            NumberInBase n2t32 = converter.ConvertFromDecimal(4056, 4);
            NumberInBase n3t32 = converter.ConvertFromDecimal(9863, 6);
            NumberInBase n4t32 = converter.ConvertFromDecimal(342391, 8);
            NumberInBase n5t32 = converter.ConvertFromDecimal(464464, 9);
            NumberInBase n6t32 = converter.ConvertFromDecimal(998, 10);

            Console.Write("n1t32: " + n1t32.Print());
            CheckTest("(210210120120)_3", n1t32.Print());
            Console.Write("n2t32: " + n2t32.Print());
            CheckTest("(333120)_4", n2t32.Print());
            Console.Write("n3t32: " + n3t32.Print());
            CheckTest("(113355)_6", n3t32.Print());
            Console.Write("n4t32: " + n4t32.Print());
            CheckTest("(1234567)_8", n4t32.Print());
            Console.Write("n5t32: " + n5t32.Print());
            CheckTest("(777111)_9", n5t32.Print());
            Console.Write("n6t32: " + n6t32.Print());
            CheckTest("(998)_10", n6t32.Print());

            //Konwersja z systemu dziesiętnego na systemy o podstawach 11 - 30 (z użyciem liter)
            Console.WriteLine();
            Console.WriteLine("--- TEST 4.3 ---");
            NumberInBase n1t33 = converter.ConvertFromDecimal(10, 11);
            NumberInBase n2t33 = converter.ConvertFromDecimal(1845, 13);
            NumberInBase n3t33 = converter.ConvertFromDecimal(36618, 16);
            NumberInBase n4t33 = converter.ConvertFromDecimal(128007, 20);
            NumberInBase n5t33 = converter.ConvertFromDecimal(355593, 25);
            NumberInBase n6t33 = converter.ConvertFromDecimal(306854, 30);

            Console.Write("n1t33: " + n1t33.Print());
            CheckTest("(A)_11", n1t33.Print());
            Console.Write("n2t33: " + n2t33.Print());
            CheckTest("(ABC)_13", n2t33.Print());
            Console.Write("n3t33: " + n3t33.Print());
            CheckTest("(8F0A)_16", n3t33.Print());
            Console.Write("n4t33: " + n4t33.Print());
            CheckTest("(G007)_20", n4t33.Print());
            Console.Write("n5t33: " + n5t33.Print());
            CheckTest("(MINI)_25", n5t33.Print());
            Console.Write("n6t33: " + n6t33.Print());
            CheckTest("(BASE)_30", n6t33.Print());
        }
    }
}