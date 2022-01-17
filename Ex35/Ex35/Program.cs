using System;

namespace Ex35
{
    class Program
    {
        static void Main(string[] args)
        {
            int index;
            double x, y;
            var z = double.NaN;
            char[] ch = { '+', '-', '*', '/', ':' };
            Console.WriteLine("Калькулятор.Введите выражение вида: x * y < Enter > для ввода значения из памяти используй m");
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
                        x = arg1 == "m" ? z : Convert.ToDouble(arg1);
                        y = arg2 == "m" ? z :Convert.ToDouble(arg2);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка ввода, поменяйте переменные в строке {0}",words);
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

                    z = operation(x, y);
                    Console.WriteLine(z);
                }
                else Console.WriteLine("Нет такой операции, замените знак в строке {0}", words);
            }
        }
    }
}