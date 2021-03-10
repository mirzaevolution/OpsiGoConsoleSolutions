using System;

namespace NumberSumCombinations
{
    class Program
    {
        static void GetCombinations(int[] array, int index, int number, int reducedNumber)
        {
            if (reducedNumber < 0) return;

            if (reducedNumber == 0)
            {
                for (int i = index-1; i >=0; i--)
                    Console.Write(array[i] + " ");
                Console.WriteLine();
                return;
            }
            int previousNumber = (index == 0) ? 1 : array[index - 1];
 
            for (int i = number;  i >= previousNumber; i--)
            {
                array[index] = i;

                GetCombinations(array, index + 1, number, reducedNumber - i);
            }
        }
        static void Main(string[] args)
        {

            if(int.TryParse(Console.ReadLine(), out int number))
            {
                GetCombinations(new int[number], 0, number-1, number);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
            Console.ReadLine();
        }
    }
}
