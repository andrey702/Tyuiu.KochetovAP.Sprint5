using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib
{
    public class DataService : ISprint5Task5V5
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            // Читаем весь текст из файла
            string fileContent = File.ReadAllText(path);

            // Разбиваем содержимое по пробелам и фильтруем пустые элементы
            string[] numberStrings = fileContent
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // Преобразуем строки в числа
            var numbers = numberStrings
                .Select(str =>
                {
                    if (double.TryParse(str.Trim(), out double number))
                    {
                        return number;
                    }
                    throw new ArgumentException($"Некорректные данные в файле: '{str}'");
                })
                .ToList();

            // Проверяем, что файл не пустой
            if (numbers.Count == 0)
            {
                throw new ArgumentException("Файл пуст или не содержит корректных чисел");
            }

            // Находим разницу между максимальным и минимальным ЦЕЛЫМИ числами
            var integers = numbers
                .Where(x => x == Math.Truncate(x)) // Отбираем только целые числа
                .ToList();

            if (integers.Count == 0)
            {
                throw new ArgumentException("В файле нет целых чисел");
            }

            double maxInteger = integers.Max();
            double minInteger = integers.Min();
            double difference = maxInteger - minInteger;

            return difference;
        }

        // Дополнительный метод для демонстрации работы с путями
        public string CreateTempDataFile()
        {
            string tempFilePath = Path.GetTempFileName();

            // Записываем тестовые данные в одну строку
            string testData = "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3";

            File.WriteAllText(tempFilePath, testData);
            Console.WriteLine($"Создан временный файл с тестовыми данными: {tempFilePath}");

            return tempFilePath;
        }
    }
}