using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Test
{
    public class DataServiceTest
    {
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\Asus\DataSprint5\InPutDataFileTask5V5.txt";

            double res = ds.LoadFromDataFile(path);
            double wait = 0.83;

            if (res != wait)
            {
                throw new Exception($"Ожидалось {wait}, получено {res}");
            }
        }

        public void FileNotFoundLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\Asus\DataSprint5\NonExistentFile.txt";

            try
            {
                ds.LoadFromDataFile(path);
                throw new Exception("Ожидалось исключение FileNotFoundException");
            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}