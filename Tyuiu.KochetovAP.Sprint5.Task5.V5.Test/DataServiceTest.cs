using Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = Path.GetTempFileName();
            string data = "-3.09 3 3 7.48 -3.22 17.29 8 -4 0.83 14.18 -6 8.15 -8.7 -3.06 20 -4 15.82 -10 9 -3";
            File.WriteAllText(path, data);

            DataService ds = new DataService();
            double wait = 30.000; 
            double res = ds.LoadFromDataFile(path);

            Assert.AreEqual(wait, res);

            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundLoadFromDataFile()
        {
            string path = Path.GetTempFileName();
            File.Delete(path);

            DataService ds = new DataService();
            double res = ds.LoadFromDataFile(path); 
        }

        [TestMethod]
        public void CheckRounding()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "5 10");

            DataService ds = new DataService();
            double res = ds.LoadFromDataFile(path); 

            Assert.AreEqual(5.000, res);

            File.Delete(path);
        }

        [TestMethod]
        public void TestWithOnlyIntegers()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "1 2 3 4 5");

            DataService ds = new DataService();
            double res = ds.LoadFromDataFile(path); 

            Assert.AreEqual(4.000, res);

            File.Delete(path);
        }

        [TestMethod]
        public void TestWithNegativeNumbers()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "-5 -10 -15");

            DataService ds = new DataService();
            double res = ds.LoadFromDataFile(path); 

            Assert.AreEqual(10.000, res);

            File.Delete(path);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNoIntegers()
        {
            string path = Path.GetTempFileName();
            File.WriteAllText(path, "1.5 2.7 3.14");

            DataService ds = new DataService();
            double res = ds.LoadFromDataFile(path);

            File.Delete(path);
        }
    }
}
