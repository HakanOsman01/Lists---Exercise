using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
            string command = Console.ReadLine();
            while (command != "3:1")
            {
                string[] cmdArgs = command
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
                string cmdType = cmdArgs[0];
                if (cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    Merge(words, startIndex, endIndex);
                }
                else if (cmdType == "divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partionsCount = int.Parse(cmdArgs[2]);
                    Divide(words, index,partionsCount);
                }
                command = Console.ReadLine();
            }
            string output = string.Join(' ', words);
            Console.WriteLine(output);
        }
        static void Merge(List<string>words,int startIndex,int endIndex)
        {
            if (!IsIndexValid(words, startIndex))
            {
                startIndex = 0;
            }
            if (!IsIndexValid(words, endIndex))
            {
                endIndex = words.Count - 1;
            }
            StringBuilder merge = new StringBuilder();
            for(int i = startIndex; i <= endIndex; i++)
            {
                merge.Append(words[startIndex]);
                words.RemoveAt(startIndex);
            }
            words.Insert(startIndex, merge.ToString());
        }
        static void Divide(List<string>words,int elementIndex,int partionsCount)
        {
            string word = words[elementIndex];
            if (partionsCount > words.Count)
            {
                return;
            }
            int partionLenght = word.Length / partionsCount;
            int partionRemainer = word.Length % partionsCount;
            int lastPartionCount = partionLenght + partionRemainer;
            List<string> partions = new List<string>();
            for(int i = 0; i <partionsCount; i++)
            {
                char[] currentPartion;
                if (i == partionsCount-1)
                {
                    currentPartion = word
                    .Skip(i * partionLenght)
                    .Take(lastPartionCount)
                    .ToArray();
                }
                else
                {
                    currentPartion = word
                   .Skip(i * partionLenght)
                   .Take(partionLenght)
                   .ToArray();
                }
                partions.Add(new string(currentPartion));
            }
            words.RemoveAt(elementIndex);
            words.InsertRange(elementIndex, partions);
        }
        static bool IsIndexValid(List<string>words,int index)
        {
            return index >= 0 && index < words.Count;
        }
    }
}
