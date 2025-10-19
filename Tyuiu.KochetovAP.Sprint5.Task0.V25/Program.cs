using System;
using Tyuiu.KochetovAP.Sprint5.Task0.V25.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task0.V25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Кочетов А. П. | ИБКСб-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Работа с файлами                                                  *");
            Console.WriteLine("* Задание #0                                                              *");
            Console.WriteLine("* Вариант #25                                                             *");
            Console.WriteLine("* Выполнил: Кочетов А. П. | ИБКСб-25-1                                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение, вычислить его значение при x = 3.                       *");
            Console.WriteLine("* Результат сохранить в текстовый файл OutPutFileTask0.txt и вывести на   *");
            Console.WriteLine("* консоль. Округлить до трёх знаков после запятой.                        *");
            Console.WriteLine("* Формула: y(x) = (3*x^4 + 1) / (x^3)                                     *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            int x = 3;

            string filePath = ds.SaveToFileTextData(x);
            string result = File.ReadAllText(filePath);

            Console.WriteLine($" Значение функции при x = {x} записано в файл:");
            Console.WriteLine($" {filePath}");
            Console.WriteLine($" Результат вычисления: {result}");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Программа завершена. Нажмите любую клавишу для выхода.                  *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}