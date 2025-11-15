using Tyuiu.KochetovAP.Sprint5.Task4.V30.Lib;
using System.IO;

namespace Tyuiu.KochetovAP.Sprint5.Task4.V30.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"InPutDataFileTask4V30.txt"; 

            File.WriteAllText(path, "2.5");
            double result = ds.LoadFromDataFile(path);
            double wait = 21.447;

            Assert.AreEqual(wait, result);

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
