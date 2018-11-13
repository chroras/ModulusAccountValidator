using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ValidatingAccountNumbers.Services
{
    public class AlgorithmsService: IAlgorithmsInterface
    {
        public async Task<bool> Mod()
        {
            //Get the line
            var modulusCodeLine = File.ReadLines("ModulusTable.txt")
                       .Select((x, i) => new { Line = x, LineNumber = i })
                       .Where(x => x.Line.Contains(""))
                       .ToList().FirstOrDefault();

            //If it is a Mod10 or MOD11
            if (modulusCodeLine.Line.Contains("Mod"))
                ValidateMod(modulusCodeLine.Line);
            return true;
        }
        public bool ValidateMod(string modulusCodeLine)
        {
            string sum = string.Empty;
            int result = 0;
            int count = 0;
            var weights = (modulusCodeLine.Substring(20)).Split(' ').Select(int.Parse).ToArray();

            foreach (char number in modulusCodeLine.Replace(" ", string.Empty).Substring(0, 12))
            {
                //Exception 7
                if (weights[12] == 9 && count < 9)
                    result += (0 * weights[count]);
                else
                    result += (int)char.GetNumericValue(number) * weights[count];
                count++;
            }
            int remainder = 0;
            if (modulusCodeLine.Contains("Mod10"))
            {
                result = result / 10;
                remainder = result % 10;
            }
            else if (modulusCodeLine.Contains("Mod11"))
            {
                result = result / 11;
                remainder = result % 11;
            }

            if (remainder.ToString() == (modulusCodeLine.Replace(" ", string.Empty).Substring(11, 11).ToString() + modulusCodeLine.Replace(" ", string.Empty).Substring(12, 12).ToString()))
            {
                //Exception 4
                return true;
            }
            if (remainder > 0)
                return false;
            return true;
        }

    }


}
