using System;
using Tyuiu.KochetovAP.Sprint5.Task1.V22.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task1.V22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Кочетов А. П. | ИБКСб-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Работа с файлами                                                  *");
            Console.WriteLine("* Задание #1                                                              *");
            Console.WriteLine("* Вариант #22                                                             *");
            Console.WriteLine("* Выполнил: Кочетов А. П. | ИБКСб-25-1                                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дана функция F(x) = sin(x) + (cos(x)+1)/(2-x) + 2*x                     *");
            Console.WriteLine("* Выполнить табулирование на промежутке [-5, 5] с шагом 1.               *");
            Console.WriteLine("* Проверить деление на 0. При x = 2 вместо значения выводить 0.          *");
            Console.WriteLine("* Результат сохранить в файл OutPutFileTask1.txt и вывести как таблицу.  *");
            Console.WriteLine("* Округлить до двух знаков после запятой.                                *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();

            int start = -5;
            int stop = 5;

            
            string filePath = ds.SaveToFileTextData(start, stop);

            
            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("   x\t  F(x)");
            Console.WriteLine(" ----------------------");
            foreach (var line in lines)
            {
                Console.WriteLine("  " + line);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine($" Файл с результатом: {filePath}");
            Console.WriteLine(" Программа завершена. Нажмите любую клавишу для выхода.");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}