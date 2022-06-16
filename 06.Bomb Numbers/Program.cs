using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToList();
            int[] bombInfo = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();
            int bombNumber = bombInfo[0];
            int bombPower = bombInfo[1];
            while (true)
            {
                int indexOfBombNumber = numbers.IndexOf(bombNumber);
                if (indexOfBombNumber == -1)
                {
                    break;
                }
                DetonateBomb(numbers, indexOfBombNumber, bombPower);
            }

            Console.WriteLine(numbers.Sum());
        }
        static void DetonateBomb(List<int>numbers,int indexOfBombNumber,int bombPower)
        {
            int rightCount = indexOfBombNumber + bombPower;
            for (int cnt = indexOfBombNumber; cnt <= rightCount; cnt++)
            {
                if (indexOfBombNumber >= numbers.Count)
                {
                    break;
                }
                numbers.RemoveAt(indexOfBombNumber);
            }
            int leftCount = indexOfBombNumber - bombPower;
            if (leftCount < 0)
            {
                leftCount = 0;
            }
            for (int cnt = leftCount; cnt < indexOfBombNumber; cnt++)
            {
                if (leftCount >= numbers.Count)
                {
                    break;
                }
                numbers.RemoveAt(leftCount);
            }
        }
    }
}
