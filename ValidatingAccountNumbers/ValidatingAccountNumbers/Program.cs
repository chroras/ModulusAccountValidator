using System;
using System.IO;
using System.Linq;

namespace ValidatingAccountNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program accountchecker = new Program();

            if (accountchecker.CheckBankAccount("050022", "058999"))
                Console.Out.Write("Account is valid");
            else
                Console.Out.Write("Account is invalid");
        }

        public bool CheckBankAccount(string sortCode, string accountNumber)
        {
            //Get the line
            var modulusCodeLine = File.ReadLines("ModulusTable.txt")
                       .Select((x, i) => new { Line = x, LineNumber = i })
                       .Where(x => x.Line.Contains(sortCode))
                       .ToList().FirstOrDefault();

            //If it is a Mod10 or MOD11
            if (modulusCodeLine.Line.Contains("Mod"))
                ValidateMod(modulusCodeLine.Line);

            //If DBLAL
            if (modulusCodeLine.Line.Contains("DblAl"))
                ValidateDblAl(modulusCodeLine.Line);
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

        public bool ValidateDblAl(string modulusCodeLine)
        {
            string sum = string.Empty;
            int count = 0;
            foreach (char number in modulusCodeLine.Replace(" ", string.Empty).Substring(0, 12))
            {
                sum += ((int)char.GetNumericValue(number) * (int)char.GetNumericValue(modulusCodeLine.Replace(" ", string.Empty).Substring(17)[count])).ToString();
                count++;
            }
            int result = 0;
            int remainder = 0;
            foreach (char sumNumber in sum)
            {
                result += sumNumber;
            }
            result = result / 10;
            remainder = result % 11;
            if (remainder > 0)
                return false;
            Console.Out.Write(result.ToString());
        
            return true;
        }
    }
}
