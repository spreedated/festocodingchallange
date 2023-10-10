using CodingChallange2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextUserInterface.Attributes;

namespace CodingChallange2023.Episodes
{
    [Chapter(2, "Chapter 2")]
    internal class Chapter2
    {
        public static void Solve()
        {
            Console.WriteLine("Chapter X:\n");
            Console.WriteLine("\t\t\"---\"\n\n");

            Puzzle1();
            Puzzle2();
            Puzzle3();
            Story();
        }

        #region Puzzle 1
        [State(StateAttribute.Types.Empty)]
        public static void Puzzle1()
        {
            
        }
        #endregion

        #region Puzzle 2
        [State(StateAttribute.Types.Empty)]
        public static void Puzzle2()
        {

        }
        #endregion

        #region Puzzle 3
        [State(StateAttribute.Types.Empty)]
        public static void Puzzle3()
        {
            
        }
        #endregion

        #region Story
        [State(StateAttribute.Types.Empty)]
        public static void Story()
        {

        }
        #endregion
    }
}
