using System;
using System.IO;
using System.Text;
using Tyuiu.KochetovAP.Sprint5.Task7.V11.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task7.V11.Test;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирование DataService ===");

        Test1_RemoveSpacesAndRussianLetters();
        Test2_KeepUppercaseAndNumbers();
        Test3_EmptyFile();

        Console.WriteLine("\nВсе тесты завершены!");
        Console.ReadKey();
    }

    static void Test1_RemoveSpacesAndRussianLetters()
    {
        Console.WriteLine("\nТест 1: Удаление пробелов и строчных русских букв");

        string path = @"C:\Users\Asus\DataSprint5\test1.txt";
        File.WriteAllText(path, "Привет, как дела? Он написал письмо.", Encoding.UTF8);

        DataService ds = new DataService();
        string resultPath = ds.LoadDataAndSave(path);
        string result = File.ReadAllText(resultPath, Encoding.UTF8);

        Console.WriteLine($"Ожидалось: П,?ОН.");
        Console.WriteLine($"Получено: {result}");
        Console.WriteLine($"Тест пройден: {result == "П,?ОН."}");
    }

    static void Test2_KeepUppercaseAndNumbers()
    {
        Console.WriteLine("\nТест 2: Сохранение заглавных букв и чисел");

        string path = @"C:\Users\Asus\DataSprint5\test2.txt";
        File.WriteAllText(path, "123 ABC ТЕСТ test", Encoding.UTF8);

        DataService ds = new DataService();
        string resultPath = ds.LoadDataAndSave(path);
        string result = File.ReadAllText(resultPath, Encoding.UTF8);

        Console.WriteLine($"Ожидалось: 123ABCTЕСТtest");
        Console.WriteLine($"Получено: {result}");
        Console.WriteLine($"Тест пройден: {result == "123ABCTЕСТtest"}");
    }

    static void Test3_EmptyFile()
    {
        Console.WriteLine("\nТест 3: Пустой файл");

        string path = @"C:\Users\Asus\DataSprint5\test3.txt";
        File.WriteAllText(path, "", Encoding.UTF8);

        DataService ds = new DataService();
        string resultPath = ds.LoadDataAndSave(path);
        string result = File.ReadAllText(resultPath, Encoding.UTF8);

        Console.WriteLine($"Ожидалось: (пустая строка)");
        Console.WriteLine($"Получено: '{result}'");
        Console.WriteLine($"Тест пройден: {result == ""}");
    }
}