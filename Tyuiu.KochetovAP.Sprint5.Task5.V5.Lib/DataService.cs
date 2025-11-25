using System;
using System.IO;
using System.Linq;
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


            string fileContent = File.ReadAllText(path);


            fileContent = fileContent.Replace(',', '.');


            string[] numberStrings = fileContent
                .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            var numbers = numberStrings
                .Select(str =>
                {
                    if (double.TryParse(str.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double number))
                    {
                        return number;
                    }
                    throw new ArgumentException($"Некорректные данные в файле: '{str}'");
                })
                .ToList();


            if (numbers.Count == 0)
            {
                throw new ArgumentException("Файл пуст или не содержит корректных чисел");
            }

 
            var integers = numbers
                .Where(x => x == Math.Truncate(x)) 
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
    }
}