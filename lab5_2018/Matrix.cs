using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLibrary
{
    abstract class Matrix
    {
        public int Rows, Columns;
        public Matrix(int rows, int columns, double[,] matrix)
        {
            if (null == matrix || rows > matrix.GetLength(0) || columns > matrix.GetLength(1))
            {
                Rows = Columns = -1;
                return;
            }
            this.Rows = rows;
            this.Columns = columns;
        }
        abstract public double GetValue(int rowInd, int colInd);
        abstract public void SetValue(int rowInd, int colInd, double value);
        virtual public void Print()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    System.Console.Write(0);
                }
                System.Console.Write('\n');
            }
        }
        protected bool badIndex(int row, int col)
        {
            return (row < 0 || row >= Rows || col < 0 || col >= Columns);
        }
    }

    class ArrayMatrix : Matrix
    {
        protected double[,] table;
        public ArrayMatrix(int rows, int columns, double[,] matrix) : base(rows, columns, matrix)
        {
            table = matrix;
        }
        override public double GetValue(int row, int col)
        {
            if (!badIndex(row, col))
                return table[row, col];
            else
                return double.MinValue;
        }
        override public void SetValue(int row, int col, double value)
        {
            if (!badIndex(row, col)) 
                table[row, col] = value;
        }
        override public void Print()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    System.Console.Write(table[row, col]);
                }
                System.Console.Write('\n');
            }
        }
    }

    class TriangleMatrix : Matrix
    {
        protected double[][] table;
        public TriangleMatrix(int size, double[,] matrix) : base(size, size, matrix)
        {
            if (Rows < 0) return;
            table = new double[Rows][];
            for (int row = 0; row < Rows; row++)
            {
                table[row] = new double[row + 1];
                for (int col = 0; col <= row; col++)
                {
                    table[row][col] = matrix[row, col];
                }
            }
        }
        override public double GetValue(int row, int col)
        {
            if (badIndex(row, col))
                return double.MinValue;
            if (inTriangle(row, col))
                return table[row][col];
            else
                return 0;
        }
        override public void SetValue(int row, int col, double value)
        {
            if (! badIndex(row, col) && inTriangle(row, col))
                table[row][col] = value;
        }
        override public void Print()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    System.Console.Write(table[row][col]);
                }
                System.Console.Write('\n');
            }
        }

        bool inTriangle(int row, int col)
        {
            return col <= row;
        }
    }
}
