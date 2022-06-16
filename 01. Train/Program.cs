using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> vagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ');
                if (cmdArgs[0] == "Add")
                {
                    int passendgers = int.Parse(cmdArgs[1]);
                    vagons.Add(passendgers);
                }
                else
                {
                    int passendgers = int.Parse(cmdArgs[0]);
                    for(int i = 0; i < vagons.Count; i++)
                    {
                        if (vagons[i] + passendgers <= capacity)
                        {
                            vagons[i] += passendgers;
                            break;
                        }
                    }
                    
                }
                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ",vagons));
        }
    }
}
