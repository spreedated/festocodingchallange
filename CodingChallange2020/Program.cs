using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TextUserInterface.Attributes;
using static TextUserInterface.EngineBasics;
using static TextUserInterface.HelperFunctions;

namespace CodingChallange2020
{
    internal static class Program
    {
        private static string title = null;
        static void Main(string[] args)
        {
            title = typeof(Program).Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;
            Console.Clear();
            DisplayProgramHeader(title);
            ChapterSelection();
        }
#pragma warning disable S2190
        private static void ChapterSelection()
#pragma warning restore S2190
        {
            IEnumerable<Type> episodes = ShowPuzzleSelection();

            int min = episodes.Min(x => x.GetCustomAttribute<ChapterAttribute>().Order);
            int max = episodes.Max(x => x.GetCustomAttribute<ChapterAttribute>().Order);

            int userInput = GetUserSelection(min, max);

            if (userInput >= min && userInput <= max)
            {
                Console.Clear();
                DisplayProgramHeader(title);
                episodes.First(x => x.GetCustomAttribute<ChapterAttribute>().Order == userInput)
                    .GetMethod("Solve")
                    .Invoke(null, null);
                DisplaySolutionEnd();
            }

            ChapterSelection();
        }

        private static IEnumerable<Type> ShowPuzzleSelection()
        {
            Console.Clear();
            DisplayProgramHeader(title);

            string heading = "Select Puzzle";

            Console.WriteLine($"  {heading}");
            Console.WriteLine($"  {new string('=', heading.Length)}\n");

            Console.WriteLine($"\tPuzzles:\n");

            IEnumerable<Type> episodes = typeof(Program).Assembly.GetTypes()
                .Where(x => x.Namespace.Contains("Puzzles") && x.IsClass && x.CustomAttributes.Any(x => x.AttributeType == typeof(ChapterAttribute)))
                .OrderBy(x => x.GetCustomAttribute<ChapterAttribute>().Order);


            foreach (Type c in episodes)
            {
                ChapterAttribute ch = c.GetCustomAttribute<ChapterAttribute>();
                StateAttribute st = c.GetCustomAttribute<StateAttribute>();

                Console.Write($"\t  [{ch.Order}] {ch.Chapter}");
                if (st != null && st.Type != StateAttribute.Types.Complete)
                {
                    WriteColor(ConsoleColor.DarkRed, $" [{st.Type}]", false, true);
                }
                Console.Write('\n');
            }

            Console.WriteLine($"\n\t  [x] Exit");

            Console.Write("\n\n  Awaiting input: ");

            return episodes;
        }
    }
}