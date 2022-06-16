using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = Console.ReadLine()
          .Split("|", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
            List<string> numbers = new List<string>();
            for(int i = 0; i<input.Count; i++)
            {
                numbers = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                for (int j = 0; j < numbers.Count; j++)
                {

                    Console.Write($"{numbers[j]} ");


                }
            }
           
            
        }
    }
}
