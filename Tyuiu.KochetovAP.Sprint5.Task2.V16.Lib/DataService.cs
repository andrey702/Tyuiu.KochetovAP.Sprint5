using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task2.V16.Lib
{
    public class DataService : ISprint5Task2V16
    {
        public string SaveToFileTextData(int[,] matrix)
        {

            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }
            }

            
            string path = Path.Combine(Path.GetTempPath(), "OutPutFileTask2.csv");

            
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string line = $"{matrix[i, 0]};{matrix[i, 1]};{matrix[i, 2]}";
                    sw.WriteLine(line);
                }
            }

            return path;
        }

    }
    
}
