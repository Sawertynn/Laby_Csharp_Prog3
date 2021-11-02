using System;
using System.Collections.Generic;
using System.Text;

namespace p3z
{
    class NumberInBase
    {
        int b = 10;
        string number;
        public NumberInBase() 
        {
            number = "0";
        }
        public NumberInBase(int n)
        {
            number = n.ToString();
        }
        public NumberInBase(string s, int b)
        {
            this.b = b;
            number = s;
        }
        public string Print()
        {
            return $"({number})_{b}";
        }
        public int GetBase() { return b; }
        public string GetNumber() { return number; }
    }

    class NumbersConverter
    {
        static int lowBase = 2, maxBase = 30, limit = 1000000;
        int[][] bases;
        public NumbersConverter()
        {
            bases = new int[maxBase + 1][];
            for (int num = lowBase; num <= maxBase; num++)
            {
                double range = Math.Log(limit, num);
                int size = System.Convert.ToInt32(Math.Ceiling(range));
                bases[num] = new int[size + 1];
                bases[num][0] = 1;
                for (int pow = 1; pow < size; pow++)
                    bases[num][pow] = bases[num][pow - 1] * num;
            }
        }
        public int ConvertToDecimal(NumberInBase nib)
        {
            int ans = 0;
            int b = nib.GetBase();
            char[] digits = nib.GetNumber().ToCharArray();
            int n = digits.Length;

            for (int i = 0; i < n; i++)
            {
                int value = CharToInt(digits[n-i-1]);
                ans += bases[b][i] * value;
            }

            return ans;
        }

        public NumberInBase ConvertFromDecimal(int n, int b)
        {
            string digits = "";
            char ch;

            do
            {
                ch = IntToChar(n % b);
                digits = ch + digits;
                n /= b;
            } while (n > 0);

            return new NumberInBase(digits, b);
        }

        static int CharToInt(char digit)
        {
            if (digit >= '0' && digit <= '9')
                return digit - '0';
            if (digit >= 'A' && digit <= 'Z')
                return digit - 'A' + 10;
            if (digit >= 'a' && digit <= 'z')
                return digit - 'a' + 10;
            else
                return -1;
        }
        static char IntToChar(int value)
        {
            if (value >= 0 && value <= 9)
                return (char)(value + '0');
            if (value >= 10 && value < 10 + maxBase)
                return (char)(value + 'A' - 10) ;
            return '#';
        }
    }
}
