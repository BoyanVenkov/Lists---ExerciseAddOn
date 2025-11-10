using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingFundamentalsCourse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "course start")
            {
                string[] parts = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                string lessonTitle = parts[1];

                switch (command)
                {
                    case "Add":
                        if (!schedule.Contains(lessonTitle))
                        {
                            schedule.Add(lessonTitle);
                        }
                        break;

                    case "Insert":
                        int index = int.Parse(parts[2]);
                        if (!schedule.Contains(lessonTitle) && index >= 0 && index <= schedule.Count)
                        {
                            schedule.Insert(index, lessonTitle);
                        }
                        break;

                    case "Remove":
                        if (schedule.Contains(lessonTitle))
                        {
                            schedule.Remove(lessonTitle);
                        }
                        string exerciseToRemove = lessonTitle + "-Exercise";
                        if (schedule.Contains(exerciseToRemove))
                        {
                            schedule.Remove(exerciseToRemove);
                        }
                        break;

                    case "Swap":
                        string lessonToSwap = parts[2];
                        if (schedule.Contains(lessonTitle) && schedule.Contains(lessonToSwap))
                        {
                            int firstIndex = schedule.IndexOf(lessonTitle);
                            int secondIndex = schedule.IndexOf(lessonToSwap);

                            string temp = schedule[firstIndex];
                            schedule[firstIndex] = schedule[secondIndex];
                            schedule[secondIndex] = temp;

                            string firstExercise = lessonTitle + "-Exercise";
                            string secondExercise = lessonToSwap + "-Exercise";

                            if (schedule.Contains(firstExercise))
                            {
                                schedule.Remove(firstExercise);
                                int newIndex = schedule.IndexOf(lessonTitle);
                                schedule.Insert(newIndex + 1, firstExercise);
                            }

                            if (schedule.Contains(secondExercise))
                            {
                                schedule.Remove(secondExercise);
                                int newIndex = schedule.IndexOf(lessonToSwap);
                                schedule.Insert(newIndex + 1, secondExercise);
                            }
                        }
                        break;

                    case "Exercise":
                        string exercise = lessonTitle + "-Exercise";
                        if (schedule.Contains(lessonTitle))
                        {
                            int lessonIndex = schedule.IndexOf(lessonTitle);
                            if (!schedule.Contains(exercise))
                            {
                                schedule.Insert(lessonIndex + 1, exercise);
                            }
                        }
                        else
                        {
                            schedule.Add(lessonTitle);
                            schedule.Add(exercise);
                        }
                        break;
                }
            }
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}