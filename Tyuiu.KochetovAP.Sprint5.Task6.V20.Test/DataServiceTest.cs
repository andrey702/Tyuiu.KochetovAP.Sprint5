using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.KochetovAP.Sprint5.Task6.V20.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task6.V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            string path = @"C:\Users\Asus\DataSprint5\InPutDataFileTask6V20.txt";

            Directory.CreateDirectory(Path.GetDirectoryName(path));


            string testData = "Это моя вторая строка для теста.";
            File.WriteAllText(path, testData);

            DataService ds = new DataService();
            int wait = 2;
            int res = ds.LoadFromDataFile(path);

            Assert.AreEqual(wait, res);
        }



    }
}