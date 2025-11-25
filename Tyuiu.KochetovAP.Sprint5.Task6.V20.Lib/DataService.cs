

using System.IO;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task6.V20.Lib
{
    public class DataService : ISprint5Task6V20
    {
        public int LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string text = File.ReadAllText(path);

            string pattern = @"\b[a-zA-Zа-яА-Я]{6}\b";
            MatchCollection matches = Regex.Matches(text, pattern);

            return matches.Count;
        }
    }
}