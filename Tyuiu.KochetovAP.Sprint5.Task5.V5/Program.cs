using System;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

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

            string path = @"C:\Users\Asus\DataSprint5\InPutDataFileTask5V5.txt";

            Console.WriteLine("Данные находятся в файле: " + path);

            // Читаем и выводим реальное содержимое файла
            string fileContent = System.IO.File.ReadAllText(path);
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(fileContent);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double res = ds.LoadFromDataFile(path);

                // Дополнительная информация для наглядности
                string[] numbers = fileContent.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var integers = numbers
                    .Select(str => double.TryParse(str.Trim(), out double num) ? num : 0)
                    .Where(x => x == Math.Truncate(x))
                    .ToList();

                Console.WriteLine($"Целые числа в файле: {string.Join(" ", integers)}");
                Console.WriteLine($"Максимальное целое число = {integers.Max()}");
                Console.WriteLine($"Минимальное целое число = {integers.Min()}");
                Console.WriteLine($"Разница между максимальным и минимальным целыми числами = {res}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Нажмите любую клавишу для завершения...                                 *");
            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}