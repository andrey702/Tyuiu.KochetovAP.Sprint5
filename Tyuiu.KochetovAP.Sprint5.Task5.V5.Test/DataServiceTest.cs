using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Test
{
    public class DataServiceTest
    {
        public DataServiceTest() { }

        public void RunAllTests()
        {
            Console.WriteLine("=== ТЕСТИРОВАНИЕ DATA SERVICE ===");
            Console.WriteLine();

            TestValidLoadFromDataFile();
            TestFileNotFound();
            TestNoIntegers();
            TestPathGetTempFileName();
            TestPathCombineWithTempPath();

            Console.WriteLine();
            Console.WriteLine("=== ТЕСТИРОВАНИЕ ЗАВЕРШЕНО ===");
        }

        public void TestValidLoadFromDataFile()
        {
            try
            {
                DataService ds = new DataService();


                string tempDir = Path.GetTempPath();
                string fileName = "TestData.txt";
                string path = Path.Combine(tempDir, fileName);

                File.WriteAllText(path, "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3");

                double result = ds.LoadFromDataFile(path);

                if (Math.Abs(result - 30) < 0.001)
                    Console.WriteLine("✓ TestValidLoadFromDataFile: ПРОЙДЕН");
                else
                    Console.WriteLine($"✗ TestValidLoadFromDataFile: ОШИБКА. Ожидалось 30, получено {result}");

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestValidLoadFromDataFile: ОШИБКА - {ex.Message}");
            }
        }

        public void TestFileNotFound()
        {
            try
            {
                DataService ds = new DataService();

                string tempDir = Path.GetTempPath();
                string nonExistentFile = Path.Combine(tempDir, "NonExistentFile.txt");

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

        public void TestNoIntegers()
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

        public void TestPathGetTempFileName()
        {
            try
            {
                DataService ds = new DataService();


                string tempFile = Path.GetTempFileName();
                File.WriteAllText(tempFile, "5 -2 10 3.14 8 -7 15");

                double result = ds.LoadFromDataFile(tempFile);

                if (Math.Abs(result - 17) < 0.001)
                    Console.WriteLine("✓ TestPathGetTempFileName: ПРОЙДЕН (Path.GetTempFileName)");
                else
                    Console.WriteLine($"✗ TestPathGetTempFileName: ОШИБКА. Ожидалось 17, получено {result}");

                File.Delete(tempFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestPathGetTempFileName: ОШИБКА - {ex.Message}");
            }
        }

        public void TestPathCombineWithTempPath()
        {
            try
            {
                DataService ds = new DataService();


                string tempDir = Path.GetTempPath();
                string fileName = "TestCombine.txt";
                string filePath = Path.Combine(tempDir, fileName);

                File.WriteAllText(filePath, "3 8 -4 20 -10 9 -3");
                double result = ds.LoadFromDataFile(filePath);

                if (Math.Abs(result - 30) < 0.001)
                    Console.WriteLine("✓ TestPathCombineWithTempPath: ПРОЙДЕН (Path.Combine + Path.GetTempPath)");
                else
                    Console.WriteLine($"✗ TestPathCombineWithTempPath: ОШИБКА. Ожидалось 30, получено {result}");

                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ TestPathCombineWithTempPath: ОШИБКА - {ex.Message}");
            }
        }
    }
}