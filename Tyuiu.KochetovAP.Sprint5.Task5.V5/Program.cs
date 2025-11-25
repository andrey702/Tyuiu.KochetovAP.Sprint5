using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Test;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.Title = "Спринт #5 | Выполнил: Кочетов А. П. | ИБКСб-25";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Чтение набора данных из текстового файла                          *");
            Console.WriteLine("* Задание #5                                                              *");
            Console.WriteLine("* Вариант #5                                                              *");
            Console.WriteLine("* Выполнил: Кочетов Андрей Павлович | ИБКСб-25                            *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор значений. Найти разницу между            *");
            Console.WriteLine("* максимальным и минимальным целыми числами в файле.                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");


            string yourDir = @"C:\Users\Asus\DataSprint5";
            string fileName = "InPutDataFileTask5V5.txt";
            string path = Path.Combine(yourDir, fileName);

            Console.WriteLine("Данные находятся в файле: " + path);


            if (!File.Exists(path))
            {
                Directory.CreateDirectory(yourDir);
                File.WriteAllText(path, "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3");
                Console.WriteLine("Файл создан автоматически");
            }

            try
            {
                string fileContent = File.ReadAllText(path);
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(fileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double res = ds.LoadFromDataFile(path);
                Console.WriteLine("Разница между максимальным и минимальным целыми числами = " + res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ЗАПУСК ТЕСТОВ:                                                          *");
            Console.WriteLine("***************************************************************************");

            DataServiceTest test = new DataServiceTest();
            test.RunAllTests();

            Console.ReadKey();
        }
    }
}