using CodingChallange2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static CodingChallange2022.HelperFunctions;

namespace CodingChallange2022.Episodes
{
    internal static class Intro
    {
        private static IEnumerable<Employee> employees;

        public static void Solve()
        {
            Console.WriteLine("Intro:\n");
            Console.WriteLine("\t\t\"Your Coffee Mug\"\n\n");

            employees = LoadOfficeDatabase(LoadEmbeddedFile("office_database"));

            Console.WriteLine($"\t- Loaded {employees.Count()} Employees from \"office_database.txt\"...");

            Employee[] p1employees = Puzzle1().ToArray();
            Employee[] p2employees = Puzzle2().ToArray();
            Employee[] p3employees = Puzzle3().ToArray();

            Console.WriteLine("\n\nThe thief:\n\n");

            Console.WriteLine($"\t- The mug thief is... \"{p1employees.Intersect(p2employees).Intersect(p3employees).FirstOrDefault()?.Username}\"!");

            Console.ReadKey();
        }

        private static IEnumerable<Employee> Puzzle1()
        {
            Console.WriteLine("\n\nPuzzle 1:\n\n");

            Console.Write($"\t- Searching for employees with numbersequence \"814\" in their ID");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(800);
                Console.Write('.');
            }
            Console.Write('\n');

            IEnumerable<Employee> matches = employees.Where(e => e.Id.ToString().Contains("814"));

            Console.WriteLine($"\t- Found {matches.Count()} employees!");
            Console.WriteLine($"\t- Sum of ID numbers of matches is {matches.Sum(e => (Int64)e.Id)}");

            return matches;
        }

        private static IEnumerable<Employee> Puzzle2()
        {
            Console.WriteLine("\n\nPuzzle 2:\n\n");

            Console.Write($"\t- Searching for employees with module \"5\" access in their AccessKey");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(800);
                Console.Write('.');
            }
            Console.Write('\n');

            IEnumerable<Employee> matches = employees.Where(e => Convert.ToString(e.AccessKey, 2).PadLeft(8, '0')[4] == '1');

            Console.WriteLine($"\t- Found {matches.Count()} employees!");
            Console.WriteLine($"\t- Sum of ID numbers of matches is {matches.Sum(e => (Int64)e.Id)}");

            return matches;
        }

        private static IEnumerable<Employee> Puzzle3()
        {
            Console.WriteLine("\n\nPuzzle 3:\n\n");

            Console.Write($"\t- Searching for employees logged in before \"07:14\"");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(800);
                Console.Write('.');
            }
            Console.Write('\n');

            IEnumerable<Employee> matches = employees.Where(e => e.LoginTime != null && e.LoginTime < new TimeOnly(7, 14));

            Console.WriteLine($"\t- Found {matches.Count()} employees!");
            Console.WriteLine($"\t- Sum of ID numbers of matches is {matches.Sum(e => (Int64)e.Id)}");

            return matches;
        }
    }
}
