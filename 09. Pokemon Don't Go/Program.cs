using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distancePokemon = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToList();
            int sum = 0;
            while (distancePokemon.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    int lastElement = distancePokemon.Last();
                    int firstElement = distancePokemon.First();
                    sum += firstElement;
                    distancePokemon.RemoveAt(0);
                    distancePokemon.Insert(0, lastElement);
                    DecreaseAndIncreaseValues(distancePokemon,firstElement);
                    continue;
                }else if (index >=distancePokemon.Count)
                {
                    int lastElement = distancePokemon.Last();
                    distancePokemon.RemoveAt(distancePokemon.Count - 1);
                    sum += lastElement;
                    int firstElement = distancePokemon.First();
                    distancePokemon.Add(firstElement);
                    DecreaseAndIncreaseValues(distancePokemon, lastElement);
                    continue;

                }
                int removeValue = distancePokemon[index];
                distancePokemon.RemoveAt(index);
                sum += removeValue;
                DecreaseAndIncreaseValues(distancePokemon, removeValue);
            }
            Console.WriteLine(sum);
        }
       
        static void DecreaseAndIncreaseValues(List<int>distancePokemon,int value)
        {
            for (int i = 0; i < distancePokemon.Count; i++)
            {
                if (distancePokemon[i] > value)
                {
                    distancePokemon[i] -= value;
                }else
                {
                    distancePokemon[i] += value;
                }
            }
        }
    }
}
