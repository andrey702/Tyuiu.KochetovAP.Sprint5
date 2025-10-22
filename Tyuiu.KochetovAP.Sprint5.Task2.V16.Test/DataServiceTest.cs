using Tyuiu.KochetovAP.Sprint5.Task2.V16.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task2.V16.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void SaveToFileTextData_CorrectResult()
        {
            
            DataService ds = new DataService();
            int[,] matrix = new int[,]
            {
                { 2, -4, -8 },
                { 3, -7, -2 },
                { 3, 8, 6 }
            };

            
            string path = ds.SaveToFileTextData(matrix);

            
            string[] lines = File.ReadAllLines(path);

            Assert.AreEqual("1; 0; 0", lines[0]);
            Assert.AreEqual("1; 0; 0", lines[1]);
            Assert.AreEqual("1; 1; 1", lines[2]);
        }
    }
}