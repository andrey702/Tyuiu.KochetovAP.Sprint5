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
                .Where(x => Math.Abs(x - Math.Truncate(x)) < 0.000001)
                .ToList();

            if (integers.Count == 0)
            {
                throw new ArgumentException("В файле нет целых чисел");
            }

            double maxInteger = integers.Max();
            double minInteger = integers.Min();
            return maxInteger - minInteger;
        }


        public string CreateFileWithTempFileName()
        {
            string tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "10 5 -3 8 15 -7");
            return tempFile;
        }


        public string CreateFileWithCombine()
        {
            string tempDir = Path.GetTempPath();
            string fileName = "CustomDataFile.txt";
            string fullPath = Path.Combine(tempDir, fileName);
            File.WriteAllText(fullPath, "3 8 -4 20 -10 9 -3");
            return fullPath;
        }


        public string CreateFileInYourDirectory()
        {
            string yourDir = @"C:\Users\Asus\DataSprint5";
            string fileName = "InPutDataFileTask5V5.txt";
            string fullPath = Path.Combine(yourDir, fileName);
            File.WriteAllText(fullPath, "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3");
            return fullPath;
        }
    }
}