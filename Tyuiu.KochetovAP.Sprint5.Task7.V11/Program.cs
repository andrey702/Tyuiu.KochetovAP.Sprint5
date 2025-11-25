using System;
using Tyuiu.KochetovAP.Sprint5.Task7.V11.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task7.V11
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.Title = "Спринт #5 | Выполнил: Кочетов А. П. | ИБКСб-25-1 | Вариант 11";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка текстовых файлов                                        *");
            Console.WriteLine("* Задание #7                                                              *");
            Console.WriteLine("* Вариант #11                                                             *");
            Console.WriteLine("* Выполнил: Кочетов Андрей Павлович | ИБКСб-25-1                          *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор символьных данных. Удалить все пробелы    *");
            Console.WriteLine("* и строчные русские буквы из файла. Полученный результат сохранить в     *");
            Console.WriteLine("* файл OutPutDataFileTask7V11.txt.                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            string path = @"C:\Users\Asus\DataSprint5\InPutDataFileTask7V11.txt";


            if (System.IO.File.Exists(path))
            {
                string inputText = System.IO.File.ReadAllText(path);
                Console.WriteLine("Исходные данные из файла:");
                Console.WriteLine(inputText);
            }
            else
            {
                Console.WriteLine("Файл не найден: " + path);
                Console.WriteLine("Убедитесь, что файл существует по указанному пути.");
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                string result = ds.LoadDataAndSave(path);
                Console.WriteLine("Результат сохранен в файле:");
                Console.WriteLine(result);


                string resultText = System.IO.File.ReadAllText(result);
                Console.WriteLine();
                Console.WriteLine("Обработанный текст:");
                Console.WriteLine(resultText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при выполнении: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}