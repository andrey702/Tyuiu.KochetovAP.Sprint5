using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Test
{
    public class DataServiceTest
    {
        public static void RunTests()
        {
            Console.WriteLine("Запуск тестов...");

            TestValidLoadFromDataFile();
            TestValidWithCommaDecimal();
            TestValidWithPointDecimal();
            TestFileNotFound();

            Console.WriteLine("Все тесты завершены!");
        }

        public static void TestValidLoadFromDataFile()
        {
            try
            {
                DataService ds = new DataService();
                string path = @"C:\Users\Asus\DataSprint5\InPutDataFileTask5V5.txt";

                double res = ds.LoadFromDataFile(path);
                double wait = 30;

                if (Math.Abs(res - wait) < 0.001)
                {
                    Console.WriteLine("✓ TestValidLoadFromDataFile: ПРОЙДЕН");
                }
                else
                {
                    Console.WriteLine($"✗ TestValidLoadFromDataFile: ОШИБКА. Ожидалось {wait}, получено {res}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidLoadFromDataFile: ОШИБКА - {ex.Message}");
            }
        }

        public static void TestValidWithCommaDecimal()
        {
            try
            {
                DataService ds = new DataService();
                string testFilePath = @"C:\Users\Asus\DataSprint5\TestFile1.txt";

                string testData = "3,09 3 3 7,48 -3,22 8 -4 0,83 -6 20 -4 -10 9 -3";
                File.WriteAllText(testFilePath, testData);

                double result = ds.LoadFromDataFile(testFilePath);
                double expected = 30;

                if (Math.Abs(result - expected) < 0.001)
                {
                    Console.WriteLine("✓ TestValidWithCommaDecimal: ПРОЙДЕН");
                }
                else
                {
                    Console.WriteLine($"✗ TestValidWithCommaDecimal: ОШИБКА. Ожидалось {expected}, получено {result}");
                }

                File.Delete(testFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidWithCommaDecimal: ОШИБКА - {ex.Message}");
            }
        }

        public static void TestValidWithPointDecimal()
        {
            try
            {
                DataService ds = new DataService();
                string testFilePath = @"C:\Users\Asus\DataSprint5\TestFile2.txt";

                string testData = "3.09 3 3 7.48 -3.22 8 -4 0.83 -6 20 -4 -10 9 -3";
                File.WriteAllText(testFilePath, testData);

                double result = ds.LoadFromDataFile(testFilePath);
                double expected = 30;

                if (Math.Abs(result - expected) < 0.001)
                {
                    Console.WriteLine("✓ TestValidWithPointDecimal: ПРОЙДЕН");
                }
                else
                {
                    Console.WriteLine($"✗ TestValidWithPointDecimal: ОШИБКА. Ожидалось {expected}, получено {result}");
                }

                File.Delete(testFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidWithPointDecimal: ОШИБКА - {ex.Message}");
            }
        }

        public static void TestFileNotFound()
        {
            try
            {
                DataService ds = new DataService();
                string path = @"C:\Users\Asus\DataSprint5\NonExistentFile.txt";

                ds.LoadFromDataFile(path);
                Console.WriteLine("✗ TestFileNotFound: ОШИБКА - Ожидалось исключение");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("✓ TestFileNotFound: ПРОЙДЕН");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestFileNotFound: ОШИБКА - {ex.Message}");
            }
        }
    }
}