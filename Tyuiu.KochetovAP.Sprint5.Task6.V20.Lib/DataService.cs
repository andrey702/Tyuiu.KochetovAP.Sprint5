using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task6.V20.Lib
{
    public class DataService : ISprint5Task6V20
    {
        public int LoadFromDataFile(string path)
        {
            string content = File.ReadAllText(path);

            Regex regex = new Regex(@"\b[а-яёА-ЯЁ]{6}\b");
            return regex.Matches(content).Count;
        }
    }
}
