using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();
            string command;
            while((command=Console.ReadLine())!="course start")
            {
                string[] cmdArgs = command
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string action = cmdArgs[0];
                if(action== "Add")
                {
                    string lessonName = cmdArgs[1];
                    if (lessons.Contains(lessonName))
                    {
                        continue;
                    }
                    AddLesson(lessons, lessonName);
                }
                else if(action== "Insert")
                {
                    string lessonName = cmdArgs[1];
                    int index = int.Parse(cmdArgs[2]);
                    if (lessons.Contains(lessonName))
                    {
                        continue;
                    }

                    InsertLesson(lessons, index, lessonName);
                }
                else if(action=="Remove")
                {
                    string lessonName = cmdArgs[1];
                    if (!lessons.Contains(lessonName))
                    {
                        continue;
                    }
                    lessons.Remove(lessonName);
                    string exerciseTitle = lessonName + "-" + "Exercise";
                    if (lessons.Contains(exerciseTitle))
                    {
                        lessons.Remove(exerciseTitle);
                    }
                }
                else if(action== "Swap")
                {
                    string firstLessonName = cmdArgs[1];
                    string secondLessonName = cmdArgs[2];
                    if(lessons.Contains(firstLessonName) && lessons.Contains(secondLessonName))
                    {
                        SwapNamesTitle(lessons, firstLessonName, secondLessonName);
                    }
                    
                }else if(action== "Exercise")
                {
                    string lessonTitle = cmdArgs[1];
                    int indexOfLesson = lessons.IndexOf(lessonTitle);
                    string exerciseFormat = lessonTitle + "-" + "Exercise";
                    ExerciseInsertModify(lessons, indexOfLesson, lessonTitle, exerciseFormat);
                   
                }
                
            }
            for(int i = 0; i <lessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{lessons[i]}");
            }
        }  
        static void SwapNamesTitle(List<string>lessons,string firstName,string secondName)
        {
            string swap = firstName;
            string exersiceFirst = firstName + "-" + "Exercise";
            string exersiceSecond = secondName + "-" + "Exercise";
           
                int indexOfFirstLesson = lessons.IndexOf(firstName);
                int indexOfSecondLesson = lessons.IndexOf(secondName);
                lessons[indexOfFirstLesson] = secondName;
                lessons[indexOfSecondLesson] = swap;
                if (lessons.Contains(exersiceFirst))
                {
                    lessons.Remove(exersiceFirst);
                    lessons.Insert(indexOfSecondLesson+1, exersiceFirst);
                }
                if (lessons.Contains(exersiceSecond))
                {
                    lessons.Remove(exersiceSecond);
                    lessons.Insert(indexOfFirstLesson+1, exersiceSecond);
                }

            
        }
        static void AddLesson(List<string>lessons,string lessonTitel)
        {
            lessons.Add(lessonTitel);

        }
        static void InsertLesson(List<string>lessons,int index,string lessonTitel)
        {
            lessons.Insert(index, lessonTitel);
        }
        static void ExerciseInsertModify(List<string>lessons,int indexOflesson
            ,string lessonTitle,string exercise)
        {
            if (lessons.Contains(lessonTitle))
            {

                if (!(lessons.Contains(exercise)))
                {
                    lessons.Insert(indexOflesson + 1, exercise);
                }
            }
            else
            {
                lessons.Add(lessonTitle);
                lessons.Add(exercise);
            }
        }
    }
}
