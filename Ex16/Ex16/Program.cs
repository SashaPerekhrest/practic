using System;
using System.Linq.Expressions;

namespace Ex16
{
    class Program
    {
        static void Main(string[] args)
        {
            int index;
            double x, y;
            char[] ch = { '+', '-', '*', '/', ':' };
            Console.WriteLine("Калькулятор.Введите выражение вида: x * y < Enter > ");
            while (true)
            {
                string words = Console.ReadLine();
                Func<double, double, double> operation;
                if (words.Length == 0) return;
                if ((index = words.IndexOfAny(ch, 1)) != -1)
                {
                    string arg1 = words.Substring(0, index);
                    string arg2 = words.Substring(index + 1);
                    try
                    {
                        x = Convert.ToDouble(arg1);
                        y = Convert.ToDouble(arg2);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка ввода");
                        continue;
                    }
                    switch (words[index])
                    {
                        case '+': operation = (a, b) => a + b; break;
                        case '-': operation = (a, b) => a - b; break;
                        case '*': operation = (a, b) => a * b; break;
                        case ':': //Две последовательные метки разрешены
                        case '/' when arg2 != "0": operation = (a, b) => a / b; break;
                        default: operation = (a, b) => Double.PositiveInfinity;  break;
                    }
                    Console.WriteLine(operation(x,y));
                }
                else Console.WriteLine("Нет операции");
            }
        }
    }
}