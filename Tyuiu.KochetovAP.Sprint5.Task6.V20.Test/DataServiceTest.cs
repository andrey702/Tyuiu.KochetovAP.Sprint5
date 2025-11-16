using Tyuiu.KochetovAP.Sprint5.Task6.V20.Lib;
using System.IO;

namespace Tyuiu.KochetovAP.Sprint5.Task6.V20.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            string path = Path.GetTempFileName();

            try
            {
                File.WriteAllText(path, "Это моя вторая строка для теста.");

                DataService ds = new DataService();
                int wait = 2; 
                int res = ds.LoadFromDataFile(path);
                Assert.AreEqual(wait, res);
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        [TestMethod]
        public void ValidLoadFromDataFileWithMoreWords()
        {
            string path = Path.GetTempFileName();

            try
            {
                File.WriteAllText(path, "Это моя вторая строка для теста. Добавим победа радость.");

                DataService ds = new DataService();
                int wait = 3; 
                int res = ds.LoadFromDataFile(path);
                Assert.AreEqual(wait, res);
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        [TestMethod]
        public void ValidLoadFromDataFileWithMixedLength()
        {
            string path = Path.GetTempFileName();

            try
            {
                File.WriteAllText(path, "кот дом победа университет радость данные");

                DataService ds = new DataService();
                int wait = 2; 
                int res = ds.LoadFromDataFile(path);
                Assert.AreEqual(wait, res);
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        [TestMethod]
        public void ValidLoadFromDataFileEmpty()
        {
            string path = Path.GetTempFileName();

            try
            {
                File.WriteAllText(path, "");

                DataService ds = new DataService();
                int wait = 0;
                int res = ds.LoadFromDataFile(path);
                Assert.AreEqual(wait, res);
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }
    }
}