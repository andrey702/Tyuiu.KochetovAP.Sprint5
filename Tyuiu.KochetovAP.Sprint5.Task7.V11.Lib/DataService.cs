using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task7.V11.Lib
{
    public class DataService : ISprint5Task7V11
    {
        public string LoadDataAndSave(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден по пути: {path}");
            }

            string fileContent = File.ReadAllText(path, Encoding.UTF8);
            string processedContent = RemoveSpacesAndLowercaseRussianLetters(fileContent);

            string outputPath = Path.Combine(Path.GetTempPath(), "OutPutDataFileTask7V11.txt");

            File.WriteAllText(outputPath, processedContent, Encoding.UTF8);
            return outputPath;
        }

        private string RemoveSpacesAndLowercaseRussianLetters(string text)
        {
            string withoutLowercase = Regex.Replace(text, "[а-я]", "");

            string result = withoutLowercase
                .Replace(" ", "")    
                .Replace("?", "? ")  
                .Replace(".", ". "); 

            return result;
        }
    }
}