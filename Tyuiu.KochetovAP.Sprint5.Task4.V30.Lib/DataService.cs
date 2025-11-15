using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task4.V30.Lib
{
    public class DataService : ISprint5Task4V30
    {
        public double LoadFromDataFile(string path)
        {

            string text = File.ReadAllText(path);
            // Используем инвариантную культуру для точек
            double x = double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);

            double y = (Math.Pow(x, 3) - Math.Tan(x)) + 2.03 * x;
            return Math.Round(y, 3);
        }
    }
}
