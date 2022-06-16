using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            List<int> secondPlayerCards = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                if (firstPlayerCards[0] > secondPlayerCards[0])
                {
                    AddCardsOnFirstWiningPlayer(firstPlayerCards, secondPlayerCards);
                }else if (firstPlayerCards[0] < secondPlayerCards[0])
                {
                    AddCardsOnSecondWiningPlayer(secondPlayerCards, firstPlayerCards);
                }
                firstPlayerCards.Remove(firstPlayerCards[0]);
                secondPlayerCards.Remove(secondPlayerCards[0]);
                if (firstPlayerCards.Count == 0)
                {
                    int sum = secondPlayerCards.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (secondPlayerCards.Count == 0)
                {
                    int sum = firstPlayerCards.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
        static void AddCardsOnFirstWiningPlayer(List<int> firstPlayerCards, List<int> secondPlayerCards)
        {
            firstPlayerCards.Add(firstPlayerCards[0]);
            firstPlayerCards.Add(secondPlayerCards[0]);
        }
        static void AddCardsOnSecondWiningPlayer(List<int>secondPlayerCards, List<int>firstPlayerCards)
        {
            secondPlayerCards.Add(secondPlayerCards[0]);
            secondPlayerCards.Add(firstPlayerCards[0]);
        }
    }
}
