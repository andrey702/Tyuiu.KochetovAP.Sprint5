using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task3.V22.Lib
{
    public class DataService : ISprint5Task3V22
    {
        public string SaveToFileTextData(int x)
        {
            
            double y = Math.Pow(1 - x, 2) / (-3 * x);
            y = Math.Round(y, 3);

            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(y);
            }

            return path;
        }
    }
}
