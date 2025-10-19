using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task0.V25.Lib
{
    public class DataService : ISprint5Task0V25
    {
        public string SaveToFileTextData(int x)
        {
            double y = (3 * Math.Pow(x, 4) + 1) / Math.Pow(x, 3);


            string result = Math.Round(y, 3).ToString(new CultureInfo("ru-RU"));


            string tempPath = Path.GetTempPath();

            
            string filePath = Path.Combine(tempPath, "OutPutFileTask0.txt");

            
            File.WriteAllText(filePath, result);

            
            return filePath;
        }
    }
}
