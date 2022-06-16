using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();
            string command;
            while ((command=Console.ReadLine())!="End")

            {
                string[] cmdArgs = command.
                    Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdType = cmdArgs[0];
                if (cmdType=="Add")
                {
                    int appendNumber = int.Parse(cmdArgs[1]);
                    numbers.Add(appendNumber);

                }
                else if (cmdType == "Insert")
                {
                    int insertNumber = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    if (index <0 || index>=numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.Insert(index, insertNumber);
                }
                else if (cmdType == "Remove")
                {
                    int removeIndex = int.Parse(cmdArgs[1]);
                    if(removeIndex<0 || removeIndex >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers.RemoveAt(removeIndex);
                }else if (cmdType == "Shift")
                {
                    string direction = cmdArgs[1];
                    int count = int.Parse(cmdArgs[2]);
                    if (direction == "left")
                    {
                        ShiftLeftMethod(numbers, count);
                    }else if (direction == "right")
                    {
                        ShiftRightMethod(numbers, count);
                    }
                }
               
            }
            Console.WriteLine(string.Join(' ',numbers));
        }
        static void ShiftLeftMethod(List<int>numbers,int count)
        {
            int realPerformanCount = count % numbers.Count;
            for(int curShift = 1; curShift <= realPerformanCount; curShift++)
            {
                int firstElment = numbers.First();
                numbers.Remove(firstElment);
                numbers.Add(firstElment);
            }
        }
        static void ShiftRightMethod(List<int>numbers,int count)
        {
            int realPerformanCount = count % numbers.Count;
            for (int curShift = 1; curShift <= realPerformanCount; curShift++)
            {
                int lastElement = numbers.Last();
                numbers.RemoveAt(numbers.Count-1);
                numbers.Insert(0,lastElement);
            }
        }
    }
}
