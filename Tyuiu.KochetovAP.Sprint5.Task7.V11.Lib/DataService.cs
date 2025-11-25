using System.IO;
using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task7.V11.Lib
{
    public class DataService : ISprint5Task7V11
    {
        public string LoadDataAndSave(string path)
        {
            string outputFile = @"C:\Users\Asus\DataSprint5\OutPutDataFileTask7V11.txt";

            string content = File.ReadAllText(path, Encoding.UTF8);
            string processedContent = ProcessContent(content);

            File.WriteAllText(outputFile, processedContent, Encoding.UTF8);

            return outputFile;
        }

        private string ProcessContent(string content)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in content)
            {
                if (c == ' ') continue;                   
                if (c >= 'а' && c <= 'я') continue;        
                if (c == 'ё') continue;                    

                result.Append(c);                          
            }

            return result.ToString();
        }
    }
}