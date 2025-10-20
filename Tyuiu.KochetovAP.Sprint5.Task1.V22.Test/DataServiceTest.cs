using Tyuiu.KochetovAP.Sprint5.Task1.V22.Lib;

namespace Tyuiu.KochetovAP.Sprint5.Task1.V22.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
           
            DataService ds = new DataService();
            int start = -5;
            int stop = 5;

           
            string path = ds.SaveToFileTextData(start, stop);

            
            Assert.IsTrue(File.Exists(path));
        }
    }
}
