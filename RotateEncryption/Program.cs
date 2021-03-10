using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RotateEncryption
{
    public class CryptoRotation
    {
        public static string Encrypt(string input)
        {
            if (string.IsNullOrEmpty(input) ||
                !(!string.IsNullOrEmpty(input) && (input.Length >= 1 && input.Length <= 1000)) ||
                !(Regex.IsMatch(input, @"[a-z]", RegexOptions.Singleline | RegexOptions.Compiled)))
            {
                throw new ArgumentException(("Note:\n1. Text input cannot be null/empty\n2. It can only contains 'a-z'\n3. Length must be between 1-100"));
            }
            return Rotate(input);
        }
        private static string Rotate(string input)
        {
            int l = input.Length;
            int m = CalculateM(l);
            int rowCol = Convert.ToInt32(Math.Sqrt(m));
            string[, ] arrayInput = new string[rowCol, rowCol];
            StringBuilder stringBuilder = new StringBuilder();
            int counter = 0;
            input = input.PadRight(m, '*');
            input = new string(
                        input.ToCharArray().Reverse().ToArray()
                    );
            for (int row = 0; row < rowCol; row++)
            {
                for (int col = 0; col < rowCol; col++)
                {
                    arrayInput[row, col] = input[counter++].ToString();
                }
            }

            for (int row = rowCol-1; row >=0; row--)
            {
                for (int col = 0; col < rowCol; col++)
                {
                    stringBuilder
                        .Append(arrayInput[col, row]);
                    
                }
            }
            stringBuilder = stringBuilder.Replace("*","");
            return stringBuilder.ToString();
            
        }

        private static int CalculateM(int length)
        {
            double result = 0;
            int start = length;
            do
            {
                result = start++;
            } while ((Math.Sqrt(result) % Math.Floor(Math.Sqrt(result)) != 0));
            return Convert.ToInt32(result);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input text: ");
                string input = Console.ReadLine();
                string output = CryptoRotation.Encrypt(input);
                Console.WriteLine($"Original text: {input}");
                Console.WriteLine($"Encrypted text: {output}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"ParamError: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UnknownError: {ex.Message}");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
