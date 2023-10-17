using CodingChallange2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextUserInterface.Attributes;
using static TextUserInterface.HelperFunctions;
using static CodingChallange2023.Logic.HelperFunctions;
using static CodingChallange2023.Logic.Constants;

namespace CodingChallange2023.Episodes
{
    [Chapter(2, "Chapter 2 - Knowledge Forge")]
    [State(StateAttribute.Types.Empty)]
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
        [State(StateAttribute.Types.Unfinished)]
        public static void Puzzle1()
        {
            IEnumerable<Hammer> hammerList = LoadHammers();
            Console.WriteLine($"\t- Loaded {hammerList.Count()} keys from \"hammer_collection.txt\"...");

            IEnumerable<string> possibleKeyList = LoadPossibleKeys();
            Console.WriteLine($"\t- Loaded {possibleKeyList.Count()} possible keys from \"21_keymaker_forge.txt\"...");

            bool dd = IsKeyLegit("FFFADCFAF", hammerList);
            bool dsd = IsKeyLegit("AFDFCDAFFE", hammerList);
        }

        private static IEnumerable<string> LoadPossibleKeys()
        {
            foreach (string line in LoadEmbeddedFile("21_keymaker_forge").Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                yield return line;
            }
        }

        private static bool IsKeyLegit(string key, IEnumerable<Hammer> hammerList)
        {
            string reversedEngineeredKey = key;
            bool areMatchingHammersFound = true;
            Stack<string> reversedKeys = new();

            while (areMatchingHammersFound)
            {
                areMatchingHammersFound = hammerList.Select(x => x.ConvertTo).Any(y => reversedEngineeredKey.Contains(y));

                foreach (Hammer hammer in hammerList)
                {
                    if (key.Contains(hammer.ConvertTo))
                    {
                        reversedEngineeredKey = reversedEngineeredKey.Replace(hammer.ConvertTo, "");
                        reversedKeys.Push(hammer.HammerType.ToString());
                    }
                }
            }

            return true;
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
