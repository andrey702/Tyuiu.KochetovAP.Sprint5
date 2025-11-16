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
        private string? testFolderPath;

        [TestInitialize]
        public void Initialize()
        {
            testFolderPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(testFolderPath!);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Directory.Exists(testFolderPath))
            {
                Directory.Delete(testFolderPath, true);
            }
        }

        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            DataService ds = new DataService();
            string inputPath = Path.Combine(testFolderPath!, "InPutDataFileTask7V11.txt");
            string testText = "Привет, как дела? Он написал письмо. Он ссорился с другом вчера.";

            File.WriteAllText(inputPath, testText, Encoding.UTF8);

            string resultPath = ds.LoadDataAndSave(inputPath);
            string result = File.ReadAllText(resultPath, Encoding.UTF8);

            string expected = "П,? О. О .";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckOnlySpacesAndLowercaseRemoval()
        {
            DataService ds = new DataService();
            string inputPath = Path.Combine(testFolderPath!, "InPutDataFileTask7V11.txt");
            File.WriteAllText(inputPath, "тест ТЕСТ 123", Encoding.UTF8);

            string resultPath = ds.LoadDataAndSave(inputPath);
            string result = File.ReadAllText(resultPath, Encoding.UTF8);

            Assert.AreEqual("ТЕСТ123", result);
        }

        [TestMethod]
        public void CheckPunctuationSpaces()
        {
            DataService ds = new DataService();
            string inputPath = Path.Combine(testFolderPath!, "InPutDataFileTask7V11.txt");
            File.WriteAllText(inputPath, "Привет? Как дела. Все хорошо!", Encoding.UTF8);

            string resultPath = ds.LoadDataAndSave(inputPath);
            string result = File.ReadAllText(resultPath, Encoding.UTF8);

            string expected = "П? К. !";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CheckFileNotFoundException()
        {
            DataService ds = new DataService();
            string nonExistentPath = Path.Combine(testFolderPath!, "nonexistent_file.txt");
            ds.LoadDataAndSave(nonExistentPath);
        }
    }
}