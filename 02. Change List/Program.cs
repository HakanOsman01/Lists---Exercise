using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArgs = command.Split();
                if(cmdArgs[0]== "Delete")
                {
                    int element = int.Parse(cmdArgs[1]);
                    DeleteElements(numbers,element);

                }else if(cmdArgs[0]== "Insert")
                {
                    int element = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    InsertElementAtIndex(numbers, element, index);

                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));

        }
        static void DeleteElements(List<int> numbers,int element)
        {
            numbers.RemoveAll(curElement=> element==curElement);
        }
        static void InsertElementAtIndex(List<int>numbers,int index,int element)
        {
            numbers.Insert(element, index);
        }
    }
}
