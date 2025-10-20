using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task1.V22.Lib
{
    public class DataService : ISprint5Task1V22
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask1.txt");

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int x = startValue; x <= stopValue; x++)
                {
                    double y;

                    if (x == 2)
                    {
                        y = 0; 
                    }
                    else
                    {
                        y = Math.Sin(x) + (Math.Cos(x) + 1) / (2 - x) + 2 * x;
                    }

                    y = Math.Round(y, 2);

                    
                    writer.WriteLine(y.ToString().Replace(",", ".").Replace('.', ','));
                    
                }
            }

            return path;
        }
    }
}
