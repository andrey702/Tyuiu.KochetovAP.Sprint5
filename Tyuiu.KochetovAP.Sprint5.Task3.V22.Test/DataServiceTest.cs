
using System;
using Tyuiu.KochetovAP.Sprint5.Task3.V22.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task3.V22.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();
            int x = 3;

            string path = ds.SaveToFileTextData(x);

            Assert.IsTrue(File.Exists(path));

            double result;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                result = reader.ReadDouble();
            }

            double expected = -0.444;
            Assert.AreEqual(expected, result);
        }
    }
}