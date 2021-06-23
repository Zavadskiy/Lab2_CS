using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_3a
{
    class Program
    {
        public static string ToBinary(float f)
        {
            byte[] b = BitConverter.GetBytes(f);
            int i = BitConverter.ToInt32(b, 0);
            string result = Convert.ToString(i, 2);
            return new String('0', 32 - result.Length) + result;
        }
        public static float FromBinary(string s)
        {
            int i = Convert.ToInt32(s, 2);
            byte[] b = BitConverter.GetBytes(i);
            return BitConverter.ToSingle(b, 0);
        }
        static void Main(string[] args)
        {
            
            string exString, mantisaString, result;
            Console.Write("Перше число = ");
            float number1 = float.Parse(Console.ReadLine());
            Console.Write("Друге число = ");
            float number2 = float.Parse(Console.ReadLine());
            string string1 = ToBinary(number1);
            Console.WriteLine(string1);

            string string2 = ToBinary(number2);
            Console.WriteLine(string2);
            int sign1 = int.Parse(string1[0].ToString());
            int sign2 = int.Parse(string2[0].ToString());
            int ex1 = Convert.ToInt32(string1.Substring(1, 8), 2);

            int ex2 = Convert.ToInt32(string2.Substring(1, 8), 2);
            int mant1 = Convert.ToInt32(string1.Substring(9), 2); 

            int mant2 = Convert.ToInt32(string2.Substring(9), 2);
            int singResult = 0, exResult = ex1, mantResult = 0;

            mant1 = mant1 + (1 << 23);
            mant2 = mant2 + (1 << 23);

            
            if (ex1 > ex2)
            {
                exResult = ex1;
                mant2 = mant2 >> (ex1 - ex2);
            }
            if (ex2 > ex1)
            {
                exResult = ex2;
                mant1 = mant1 >> (ex2 - ex1);
            }
            
            Console.WriteLine("Результат експоненти: " + new string('0', 8 - Convert.ToString(exResult, 2).Length) + Convert.ToString(exResult, 2));//створюємо строку і присвоюємо значення 0 на розмір, якого не вистачає до 8 біт, а потім доповнюємо ex
            Console.WriteLine("Мантиса першого числа: " + new string('0', 32 - Convert.ToString(mant1, 2).Length) + Convert.ToString(mant1, 2));//аналогічно для 32
            Console.WriteLine("Мантиса другого числа: " + new string('0', 32 - Convert.ToString(mant2, 2).Length) + Convert.ToString(mant2, 2));//аналогічно для 32
            
            if (sign1 == sign2)
            {
                singResult = sign1;
                mantResult = mant1 + mant2;
            }
            else if (mant1 > mant2 && sign1 == 0 && sign2 == 1)
            {
                singResult = 0;
                mantResult = mant1 - mant2;
            }
            else if (mant2 > mant1 && sign1 == 0 && sign2 == 1)
            {
                singResult = 1;
                mantResult = mant2 - mant1;
            }
            else if (mant1 > mant2 && sign1 == 1 && sign2 == 0)
            {
                singResult = 1;
                mantResult = mant1 - mant2;
            }
            else if (mant2 > mant1 && sign1 == 1 && sign2 == 0)
            {
                singResult = 0;
                mantResult = mant2 - mant1;
            }




            Console.WriteLine("Добавити значення: " +
                new string('0', 32 - Convert.ToString(mantResult, 2).Length) + Convert.ToString(mantResult, 2));

            while ((mantResult >> 24) > 0)
            {
                mantResult = mantResult >> 1;
                exResult++;
            }
            while ((mantResult & (1 << 23)) != (1 << 23))
            {
                mantResult = mantResult << 1;
                exResult--;
            }

            mantResult = mantResult & ((1 << 23) - 1);

            exString = new string('0', 8 - Convert.ToString(exResult, 2).Length) + Convert.ToString(exResult, 2);
            mantisaString = new string('0', 23 - Convert.ToString(mantResult, 2).Length) + Convert.ToString(mantResult, 2);
            result = singResult.ToString() + exString + mantisaString;
            Console.WriteLine("Експонента = " + Convert.ToString(exResult, 2));
            Console.WriteLine("Мантисса = " + Convert.ToString(mantResult, 2));
            Console.WriteLine("Результат в bit = " + result);
            Console.WriteLine("Результат = " + FromBinary(result));
        }
    }
}
