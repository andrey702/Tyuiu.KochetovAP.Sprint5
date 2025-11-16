using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KochetovAP.Sprint5.Task5.V5.Lib
{
    public class DataService : ISprint5Task5V5
    {
        public double LoadFromDataFile(string path)
        {
            string content = File.ReadAllText(path);
            string[] values = content.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int min = int.MaxValue;
            int max = int.MinValue;
            bool foundIntegers = false;

            foreach (string value in values)
            {
                if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    if (num == (int)num)
                    {
                        int intVal = (int)num;
                        foundIntegers = true;
                        if (intVal < min) min = intVal;
                        if (intVal > max) max = intVal;
                    }
                }
            }

            if (!foundIntegers)
                throw new Exception("В файле не найдено целых чисел");

            return Math.Round((double)(max - min), 3);
        }
    }
}