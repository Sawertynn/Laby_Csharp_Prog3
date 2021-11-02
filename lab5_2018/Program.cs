﻿using System;

namespace MatrixLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== ETAP 1 =====");

            Matrix m1 = new ArrayMatrix(3, 2, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });

            Console.WriteLine("Macierz M1:");
            m1.Print();

            Matrix m2 = new ArrayMatrix(3, 2, null);

            Console.WriteLine("Macierz M2 (brak tablicy wartości w konstruktorze): ");
            Console.WriteLine("Rows: {0}, Columns: {1}    -    Powinno być -1; -1\n", m2.Rows, m2.Columns);

            Matrix m3 = new ArrayMatrix(3, 3, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });

            Console.WriteLine("Macierz M2 (niezgodne wymiary): ");
            Console.WriteLine("Rows: {0}, Columns: {1}    -    Powinno być -1; -1\n", m3.Rows, m3.Columns);

            double val = m1.GetValue(0, 1);

            Console.WriteLine("Element [0, 1] z M1:");
            Console.WriteLine("{0}    -    Powinno być 2\n", val);

            val = m1.GetValue(3, 2);

            Console.WriteLine("Element [3, 2] z M1:");
            Console.WriteLine("{0}    -    Powinno być {1}\n", val, double.MinValue);

            m1.SetValue(2, 1, 100);

            Console.WriteLine("Macierz M1 po zmianie wartości:");
            m1.Print();

            m1.SetValue(-1, 0, 99.99);

            Console.WriteLine("Macierz M1 po zmianie wartości poza macierzą (Powinna być identyczna jak wyżej):");
            m1.Print();

            Console.WriteLine("===== ETAP 2 =====");

            Matrix m4 = new TriangleMatrix(5, new double[,] { { 1, 2, 0, 0, 0 }, { 3, 1, 0, 0, 0 }, { 0, 6, 1, 0, 0 }, { 2, 3, 0, 1, 0 }, { 0, 0, 0, 0, 1 } });

            Console.WriteLine("Macierz M4:");
            m4.Print();

            Matrix m5 = new TriangleMatrix(3, null);

            Console.WriteLine("Macierz M5 (brak tablicy wartości w konstruktorze): ");
            Console.WriteLine("Rows: {0}, Columns: {1}    -    Powinno być -1; -1\n", m5.Rows, m5.Columns);

            Matrix m6 = new TriangleMatrix(3, new double[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });

            Console.WriteLine("Macierz M6 (niezgodne wymiary): ");
            Console.WriteLine("Rows: {0}, Columns: {1}    -    Powinno być -1; -1\n", m3.Rows, m3.Columns);

            val = m4.GetValue(0, 1);

            Console.WriteLine("Element [0, 1] z M4:");
            Console.WriteLine("{0}    -    Powinno być 0\n", val);

            val = m4.GetValue(2, 2);

            Console.WriteLine("Element [2, 2] z M4:");
            Console.WriteLine("{0}    -    Powinno być 1\n", val);

            val = m4.GetValue(-2, 0);

            Console.WriteLine("Element poza macierzą z M4:");
            Console.WriteLine("{0}    -    Powinno być {1}\n", val, double.MinValue);

            Console.WriteLine("===== ETAP 3 =====");

            m4.SetValue(4, 4, 100);

            Console.WriteLine("Macierz M4 po zmianie wartości:");
            m4.Print();

            m4.SetValue(-1, 0, 99.99);

            Console.WriteLine("Macierz M4 po zmianie wartości poza macierzą (Powinna być identyczna jak wyżej):");
            m4.Print();

            m4.SetValue(0, 2, 99.99);

            Console.WriteLine("Macierz M4 po zmianie wartości ponad główną przekątną (Powinna być identyczna jak wyżej):");
            m4.Print();
        }
    }
}