using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using Tyuiu.KochetovAP.Sprint5.Task7.V11.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task7.V11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            DataService ds = new DataService();
            string path = Path.GetTempFileName();

            File.WriteAllText(path, "Привет, как дела? Он написал письмо. Он ссорился с другом вчера.", Encoding.UTF8);

            string resultPath = ds.LoadDataAndSave(path);
            string result = File.ReadAllText(resultPath, Encoding.UTF8);

            Assert.AreEqual("П,? О. О .", result);

            File.Delete(path);
            File.Delete(resultPath);
        }

        [TestMethod]
        public void CheckSpacesAndLowercaseRemoval()
        {
            DataService ds = new DataService();
            string path = Path.GetTempFileName();

            File.WriteAllText(path, "тест ТЕСТ 123", Encoding.UTF8);

            string resultPath = ds.LoadDataAndSave(path);
            string result = File.ReadAllText(resultPath, Encoding.UTF8);

            Assert.AreEqual("ТЕСТ123", result);

            File.Delete(path);
            File.Delete(resultPath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFound()
        {
            DataService ds = new DataService();
            ds.LoadDataAndSave("nonexistent.txt");
        }
    }
}