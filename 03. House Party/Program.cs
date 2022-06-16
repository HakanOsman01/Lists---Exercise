using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guestsList = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i<n; i++)
            {
                string[] cmdAgs = Console.ReadLine().
               Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
                string name = cmdAgs[0];
                if (cmdAgs.Length == 3)
                {
                    if (guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }
                    guestsList.Add(name);
                }else if (cmdAgs.Length == 4)
                {
                    if (!guestsList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }
                    guestsList.Remove(name);
                }
               
            }
            PrintListGuest(guestsList);
           
        }
        static void PrintListGuest(List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
