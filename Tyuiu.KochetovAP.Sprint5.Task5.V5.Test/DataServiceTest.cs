using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Test
{
    public class DataServiceTest
    {
        public static void RunTests()
        {
            Console.WriteLine("=== ТЕСТИРОВАНИЕ DATA SERVICE ===");
            Console.WriteLine();

            TestValidLoadFromDataFile();
            TestValidWithPathCombine();
            TestValidWithTempFileName();
            TestFileNotFound();
            TestNoIntegers();
            TestCreateTestFileInYourDirectory();
            TestCreateTempTestFile();

            Console.WriteLine();
            Console.WriteLine("=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
        }

        static void TestValidLoadFromDataFile()
        {
            try
            {
                DataService ds = new DataService();

                
                string yourDir = @"C:\Users\Asus\DataSprint5";
                string fileName = "InPutDataFileTask5V5.txt";
                string path = Path.Combine(yourDir, fileName);

                
                if (!File.Exists(path))
                {
                    Directory.CreateDirectory(yourDir);
                    File.WriteAllText(path, "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3");
                }

                double result = ds.LoadFromDataFile(path);

                if (Math.Abs(result - 30) < 0.001)
                    Console.WriteLine("✓ TestValidLoadFromDataFile: ПРОЙДЕН");
                else
                    Console.WriteLine($"✗ TestValidLoadFromDataFile: ОШИБКА. Ожидалось 30, получено {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidLoadFromDataFile: ОШИБКА - {ex.Message}");
            }
        }

        static void TestValidWithPathCombine()
        {
            try
            {
                DataService ds = new DataService();

                
                string yourDir = @"C:\Users\Asus\DataSprint5";
                string fileName = "TestCalculation.txt";
                string filePath = Path.Combine(yourDir, fileName);

                File.WriteAllText(filePath, "5 -2 10 3.14 8 -7 15");
                double result = ds.LoadFromDataFile(filePath);

                if (Math.Abs(result - 17) < 0.001)
                    Console.WriteLine("✓ TestValidWithPathCombine: ПРОЙДЕН");
                else
                    Console.WriteLine($"✗ TestValidWithPathCombine: ОШИБКА. Ожидалось 17, получено {result}");

                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidWithPathCombine: ОШИБКА - {ex.Message}");
            }
        }

        static void TestValidWithTempFileName()
        {
            try
            {
                DataService ds = new DataService();

                
                string tempFile = Path.GetTempFileName();
                File.WriteAllText(tempFile, "3 8 -4 20 -10 9 -3");

                double result = ds.LoadFromDataFile(tempFile);

                if (Math.Abs(result - 30) < 0.001)
                    Console.WriteLine("✓ TestValidWithTempFileName: ПРОЙДЕН");
                else
                    Console.WriteLine($"✗ TestValidWithTempFileName: ОШИБКА. Ожидалось 30, получено {result}");

                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidWithTempFileName: ОШИБКА - {ex.Message}");
            }
        }

        static void TestFileNotFound()
        {
            try
            {
                DataService ds = new DataService();

                string yourDir = @"C:\Users\Asus\DataSprint5";
                string nonExistentFile = Path.Combine(yourDir, "NonExistentFile.txt");

                ds.LoadFromDataFile(nonExistentFile);
                Console.WriteLine("✗ TestFileNotFound: ОШИБКА - Ожидалось исключение FileNotFoundException");
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

        static void TestNoIntegers()
        {
            try
            {
                DataService ds = new DataService();

                string tempFile = Path.GetTempFileName();
                File.WriteAllText(tempFile, "3.14 2.71 1.41 0.83");

                ds.LoadFromDataFile(tempFile);
                Console.WriteLine("✗ TestNoIntegers: ОШИБКА - Ожидалось исключение");

                File.Delete(tempFile);
            }
            catch (ArgumentException ex) when (ex.Message.Contains("нет целых чисел"))
            {
                Console.WriteLine("✓ TestNoIntegers: ПРОЙДЕН");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestNoIntegers: ОШИБКА - {ex.Message}");
            }
        }

        static void TestCreateTestFileInYourDirectory()
        {
            try
            {
                DataService ds = new DataService();

                string filePath = ds.CreateTestFileInYourDirectory();

                if (File.Exists(filePath))
                {
                    double result = ds.LoadFromDataFile(filePath);

                    if (Math.Abs(result - 30) < 0.001)
                        Console.WriteLine("✓ TestCreateTestFileInYourDirectory: ПРОЙДЕН");
                    else
                        Console.WriteLine($"✗ TestCreateTestFileInYourDirectory: ОШИБКА. Ожидалось 30, получено {result}");

                    File.Delete(filePath);
                }
                else
                {
                    Console.WriteLine("✗ TestCreateTestFileInYourDirectory: ОШИБКА - Файл не создан");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestCreateTestFileInYourDirectory: ОШИБКА - {ex.Message}");
            }
        }

        static void TestCreateTempTestFile()
        {
            try
            {
                DataService ds = new DataService();

                string tempFilePath = ds.CreateTempTestFile();

                if (File.Exists(tempFilePath))
                {
                    double result = ds.LoadFromDataFile(tempFilePath);

                    if (Math.Abs(result - 17) < 0.001)
                        Console.WriteLine("✓ TestCreateTempTestFile: ПРОЙДЕН");
                    else
                        Console.WriteLine($"✗ TestCreateTempTestFile: ОШИБКА. Ожидалось 17, получено {result}");

                    File.Delete(tempFilePath);
                }
                else
                {
                    Console.WriteLine("✗ TestCreateTempTestFile: ОШИБКА - Файл не создан");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestCreateTempTestFile: ОШИБКА - {ex.Message}");
            }
        }
    }
}