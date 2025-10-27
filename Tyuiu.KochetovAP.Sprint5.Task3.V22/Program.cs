using System;
using Tyuiu.KochetovAP.Sprint5.Task3.V22.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task3.V22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Кочетов А. П. | ИБКСб-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Работа с файлами                                                  *");
            Console.WriteLine("* Задание #3                                                              *");
            Console.WriteLine("* Вариант #22                                                             *");
            Console.WriteLine("* Выполнил: Кочетов А. П. | ИБКСб-25-1                                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение: y(x) = (1 - x)^2 / (-3 * x)                             *");
            Console.WriteLine("* Вычислить значение при x = 3.                                           *");
            Console.WriteLine("* Округлить результат до трёх знаков после запятой.                      *");
            Console.WriteLine("* Сохранить результат в бинарный файл OutPutFileTask3.bin и вывести.     *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();
            int x = 3;

            string path = ds.SaveToFileTextData(x);

            double result;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                result = reader.ReadDouble();
            }

            Console.WriteLine($" При x = {x}, y = {result}");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($" Файл сохранён: {path}");
            Console.WriteLine(" Программа завершена. Нажмите любую клавишу для выхода.");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}