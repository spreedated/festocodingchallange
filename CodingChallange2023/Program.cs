using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TextUserInterface.Attributes;
using static TextUserInterface.EngineBasics;
using static TextUserInterface.HelperFunctions;

namespace CodingChallange2023
{
    internal static class Program
    {
        private static Type selectedChapter = null;
        private static string title = null;

        static void Main(string[] args)
        {
            //DisplayEnd();
            title = typeof(Program).Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Console.Clear();
            DisplayProgramHeader(title);
            ChapterSelection();
        }

        private static void ChapterSelection()
        {
            IEnumerable<Type> episodes = ShowChapterSelection();

            int min = episodes.Min(x => x.GetCustomAttribute<ChapterAttribute>().Order);
            int max = episodes.Max(x => x.GetCustomAttribute<ChapterAttribute>().Order);

            int userInput = GetUserSelection(min, max);

            if (userInput >= min && userInput <= max)
            {
                selectedChapter = episodes.First(x => x.GetCustomAttribute<ChapterAttribute>().Order == userInput);
                ShowPuzzleSelection(selectedChapter.GetCustomAttribute<ChapterAttribute>().Chapter);
                PuzzleSelection();
                return;
            }

            ChapterSelection();
        }

        private static void PuzzleSelection()
        {
            switch (GetUserSelection(-2, 3))
            {
                case -2:
                    ChapterSelection();
                    break;
                case -1:
                    Console.Clear();
                    selectedChapter.GetMethod("Solve").Invoke(null, null);
                    break;
                case 0:
                    Console.Clear();
                    selectedChapter.GetMethod("Story").Invoke(null, null);
                    break;
                case 1:
                    Console.Clear();
                    selectedChapter.GetMethod("Puzzle1").Invoke(null, null);
                    break;
                case 2:
                    Console.Clear();
                    selectedChapter.GetMethod("Puzzle2").Invoke(null, null);
                    break;
                case 3:
                    Console.Clear();
                    selectedChapter.GetMethod("Puzzle3").Invoke(null, null);
                    break;
            }

            DisplaySolutionEnd();
            ShowPuzzleSelection(selectedChapter.GetCustomAttribute<ChapterAttribute>().Chapter);
            PuzzleSelection();
        }

        private static IEnumerable<Type> ShowChapterSelection()
        {
            Console.Clear();
            DisplayProgramHeader(title);

            string heading = "Chapter selection";

            Console.WriteLine($"  {heading}");
            Console.WriteLine($"  {new string('=', heading.Length)}\n");

            Console.WriteLine($"\tSelect your Chapter:\n");

            IEnumerable<Type> episodes = typeof(Program).Assembly.GetTypes()
                .Where(x => x.Namespace.Contains("Episodes") && x.IsClass && x.CustomAttributes.Any(x => x.AttributeType == typeof(ChapterAttribute)))
                .OrderBy(x => x.GetCustomAttribute<ChapterAttribute>().Order);

            foreach (Type c in episodes)
            {
                ChapterAttribute ch = c.GetCustomAttribute<ChapterAttribute>();
                StateAttribute st = c.GetCustomAttribute<StateAttribute>();

                Console.Write($"\t  [{ch.Order}] {ch.Chapter}");
                if (st != null)
                {
                    WriteColor(st.Type != StateAttribute.Types.Complete ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen, $" [{st.Type}]", false, true);
                }
                Console.Write('\n');
            }

            Console.WriteLine($"\n\t  [x] Exit");

            Console.Write("\n\n  Awaiting input: ");

            return episodes;
        }

        private static void ShowPuzzleSelection(string heading)
        {
            Console.Clear();
            DisplayProgramHeader(title);

            Console.WriteLine($"  {heading}");
            Console.WriteLine($"  {new string('=', heading.Length)}\n");

            Console.WriteLine($"\tSelect Puzzle:\n");

            Console.WriteLine($"\t  [a] Show all!");
            Console.WriteLine($"\t  [0] Story");
            Console.WriteLine($"\t  [1] Puzzle 1");
            Console.WriteLine($"\t  [2] Puzzle 2");
            Console.WriteLine($"\t  [3] Puzzle 3");
            Console.WriteLine($"\n\t  [r] Return");

            Console.Write("\n\n  Awaiting input: ");
        }
    }
}