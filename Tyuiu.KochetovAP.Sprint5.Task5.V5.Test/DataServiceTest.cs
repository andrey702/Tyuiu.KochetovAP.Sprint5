using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Test
{
    public class DataServiceTest
    {
        public static void RunTests()
        {
            Console.WriteLine("=== ТЕСТИРОВАНИЕ МЕТОДОВ РАБОТЫ С ПУТЯМИ ===");
            Console.WriteLine();

            TestPathGetTempFileName();
            TestPathCombineWithTempPath();
            TestPathCombineWithYourDirectory();

            Console.WriteLine();
            Console.WriteLine("=== ВСЕ МЕТОДЫ ПРОТЕСТИРОВАНЫ ===");
        }

        static void TestPathGetTempFileName()
        {
            try
            {
                DataService ds = new DataService();
                string tempFile = ds.CreateFileWithTempFileName();

                if (File.Exists(tempFile))
                {
                    double result = ds.LoadFromDataFile(tempFile);
                    Console.WriteLine($"✓ Path.GetTempFileName(): Файл создан, результат = {result}");
                    File.Delete(tempFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Path.GetTempFileName(): ОШИБКА - {ex.Message}");
            }
        }

        static void TestPathCombineWithTempPath()
        {
            try
            {
                DataService ds = new DataService();
                string filePath = ds.CreateFileWithCombine();

                if (File.Exists(filePath))
                {
                    double result = ds.LoadFromDataFile(filePath);
                    Console.WriteLine($"✓ Path.Combine() + Path.GetTempPath(): Файл создан, результат = {result}");
                    File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Path.Combine() + Path.GetTempPath(): ОШИБКА - {ex.Message}");
            }
        }

        static void TestPathCombineWithYourDirectory()
        {
            try
            {
                DataService ds = new DataService();
                string filePath = ds.CreateFileInYourDirectory();

                if (File.Exists(filePath))
                {
                    double result = ds.LoadFromDataFile(filePath);
                    Console.WriteLine($"✓ Path.Combine() с вашей директорией: Файл создан, результат = {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Path.Combine() с вашей директорией: ОШИБКА - {ex.Message}");
            }
        }
    }
}