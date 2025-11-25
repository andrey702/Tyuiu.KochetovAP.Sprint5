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
            double difference = maxInteger - minInteger;


            string tempDir = Path.GetTempPath();
            string resultFileName = "CalculationResult.txt";
            string resultPath = Path.Combine(tempDir, resultFileName);
            File.WriteAllText(resultPath, $"Разница: {difference}, Максимум: {maxInteger}, Минимум: {minInteger}");

            return difference;
        }


        public string CreateFileWithTempFileName()
        {
            string tempFile = Path.GetTempFileName();
            string testData = "10 5 -3 8 15 -7";
            File.WriteAllText(tempFile, testData);
            return tempFile;
        }

        public string CreateFileWithCombineAndTempPath()
        {
            string tempDir = Path.GetTempPath();
            string fileName = "TestDataFile.txt";
            string fullPath = Path.Combine(tempDir, fileName);
            string testData = "3 8 -4 20 -10 9 -3";
            File.WriteAllText(fullPath, testData);
            return fullPath;
        }

 
        public string CreateFileInYourDirectory()
        {
            string yourDir = @"C:\Users\Asus\DataSprint5";
            string fileName = "InPutDataFileTask5V5.txt";
            string fullPath = Path.Combine(yourDir, fileName);
            string testData = "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3";
            File.WriteAllText(fullPath, testData);
            return fullPath;
        }


        public string DemonstrateAllPathMethods()
        {
            string result = "Демонстрация методов работы с путями:\n\n";


            string tempFile1 = Path.GetTempFileName();
            File.WriteAllText(tempFile1, "Данные для Path.GetTempFileName()");
            result += $"1. Path.GetTempFileName(): {tempFile1}\n";


            string tempDir = Path.GetTempPath();
            string fileName2 = "CombineTempFile.txt";
            string tempFile2 = Path.Combine(tempDir, fileName2);
            File.WriteAllText(tempFile2, "Данные для Path.Combine() + Path.GetTempPath()");
            result += $"2. Path.Combine() + Path.GetTempPath(): {tempFile2}\n";

 
            string yourDir = @"C:\Users\Asus\DataSprint5";
            string fileName3 = "YourDirFile.txt";
            string tempFile3 = Path.Combine(yourDir, fileName3);
            File.WriteAllText(tempFile3, "Данные для Path.Combine() с вашей директорией");
            result += $"3. Path.Combine() с вашей директорией: {tempFile3}";

            return result;
        }
    }
}