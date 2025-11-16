using System;
using Tyuiu.KochetovAP.Sprint5.Task7.V11.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task7.V11
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();
            Console.Title = "Спринт #5 | Выполнил: Кочетов А. П. | ИБКСб-25 | Вариант 11";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Чтение данных из текстового файла                                 *");
            Console.WriteLine("* Задание #7                                                              *");
            Console.WriteLine("* Вариант #11                                                             *");
            Console.WriteLine("* Выполнил: Кочетов Андрей Павлович | ИБКСб-25                            *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл в котором есть набор символьных данных. Удалить все пробелы    *");
            Console.WriteLine("* и строчные русские буквы из файла.                                      *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            string path = @"C:\Users\Asus\source\repos\Tyuiu.KochetovAP.Sprint5\Sprint5Task7\InPutDataFileTask7V11.txt";
            Console.WriteLine("Данные находятся в файле: " + path);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                string result = ds.LoadDataAndSave(path);
                Console.WriteLine("Результат сохранен в файле: " + result);

                string resultText = System.IO.File.ReadAllText(result);
                Console.WriteLine("Обработанный текст: " + resultText);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}