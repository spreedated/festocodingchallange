using CodingChallange2023.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodingChallange2023
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ShowIntroduction();

            int userinputChapter = GetUserSelection(0,4);
            string selectedChapter = null;
            string selectedPuzzle = null;

            switch (userinputChapter)
            {
                case 0:
                    selectedChapter = "Tutorial";
                    ShowChapterSelection("Tutorial - Titan's Gateway");
                    break;
                case 1:
                    ShowChapterSelection("Chapter 1 - Cosmo Plaza");
                    selectedChapter = "1";
                    break;
                case 2:
                    ShowChapterSelection("Chapter 2");
                    selectedChapter = "2";
                    break;
                case 3:
                    ShowChapterSelection("Chapter 3");
                    selectedChapter = "3";
                    break;
                case 4:
                    ShowChapterSelection("Final Chapter");
                    selectedChapter = "4";
                    break;
            }

            int userinputPuzzle = GetUserSelection(-2,3);

            Console.Clear();

            switch (userinputPuzzle)
            {
                case -2:
                    //go back
                    break;
                case -1:
                    typeof(Program).Assembly.GetTypes().First(x => x.IsClass && x.Name == selectedChapter).GetMethod("Solve").Invoke(null, null);
                    break;
                case 0:
                    typeof(Program).Assembly.GetTypes().First(x => x.IsClass && x.Name == selectedChapter).GetMethod("Story").Invoke(null,null);
                    break;
                case 1:
                    typeof(Program).Assembly.GetTypes().First(x => x.IsClass && x.Name == selectedChapter).GetMethod("Puzzle1").Invoke(null, null);
                    break;
                case 2:
                    typeof(Program).Assembly.GetTypes().First(x => x.IsClass && x.Name == selectedChapter).GetMethod("Puzzle2").Invoke(null, null);
                    break;
                case 3:
                    typeof(Program).Assembly.GetTypes().First(x => x.IsClass && x.Name == selectedChapter).GetMethod("Puzzle3").Invoke(null, null);
                    break;
            }

            int userinputFinished = GetUserSelection(0, 1);

            //Episodes.Tutorial.Solve();
            //Episodes.Chapter1.Solve();
        }

        private static void ShowIntroduction()
        {
            Console.Clear();

            string heading = "Festo Coding Challenge 2023";

            Console.WriteLine($"\t\t{heading}");
            Console.WriteLine($"\t\t{new string('=', heading.Length)}\n\n");

            Console.WriteLine($"\tSelect your Chapter:\n");

            Console.WriteLine($"\t  [0] Tutorial");
            Console.WriteLine($"\t  [1] Chapter 1");
            Console.WriteLine($"\t  [2] Chapter 2");
            Console.WriteLine($"\t  [3] Chapter 3");
            Console.WriteLine($"\t  [4] Final Chapter");
            Console.WriteLine($"\n\t  [x] Exit");
        }

        private static void ShowChapterSelection(string heading)
        {
            Console.Clear();

            Console.WriteLine($"\t\t{heading}");
            Console.WriteLine($"\t\t{new string('=', heading.Length)}\n\n"); ;

            Console.WriteLine($"\tSelect Puzzle:\n");

            Console.WriteLine($"\t  [a] Show all!");
            Console.WriteLine($"\t  [0] Story");
            Console.WriteLine($"\t  [1] Puzzle 1");
            Console.WriteLine($"\t  [2] Puzzle 2");
            Console.WriteLine($"\t  [3] Puzzle 3");
            Console.WriteLine($"\n\t  [r] Return");
        }

        private static int GetUserSelection(int min, int max)
        {
            string input = Console.ReadLine();

            if (input == "x" || input == "X")
            {
                Environment.Exit(0);
            }

            if (!int.TryParse(input, out int intinput) || (intinput > min && intinput < max))
            {
                return GetUserSelection(min, max);
            }

            return intinput;
        }
    }
}