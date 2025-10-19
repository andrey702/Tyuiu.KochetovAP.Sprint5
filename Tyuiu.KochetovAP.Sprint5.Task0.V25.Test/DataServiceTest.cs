using Tyuiu.KochetovAP.Sprint5.Task0.V25.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task0.V25.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestSaveToFileTextData()
        {
           
            DataService ds = new DataService();
            int x = 3;

            
            string filePath = ds.SaveToFileTextData(x);
            string result = File.ReadAllText(filePath);

            
            double expected = 9.037; 
            double actual = Convert.ToDouble(result, System.Globalization.CultureInfo.InvariantCulture);

           
            Assert.AreEqual(expected, actual);
        }
    }
}