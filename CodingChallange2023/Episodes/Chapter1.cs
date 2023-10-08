using CodingChallange2023.Attributes;
using CodingChallange2023.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodingChallange2023.HelperFunctions;

namespace CodingChallange2023.Episodes
{
    internal static class Chapter1
    {
        public static void Solve()
        {
            Console.WriteLine("Chapter 1:\n");
            Console.WriteLine("\t\t\"Cosmo Plaza\"\n\n");

            //Puzzle1();
            Puzzle2();
            Puzzle3();
            Story();
        }

        #region Puzzle 1
        [State(StateAttribute.Types.Finished)]
        public static void Puzzle1()
        {
            IEnumerable<Hammer> hammerList = LoadHammers();

            Console.WriteLine($"\t- Loaded {hammerList.Count()} keys from \"hammer_collection.txt\"...");

            IEnumerable<IEnumerable<HammerAndPosition>> forgeSequences = LoadForgeSequences();

            Console.WriteLine($"\t- Loaded {forgeSequences.Count()} forge sequences from \"11_keymaker_recipe.txt\"...");

            List<string> forgedKeys = new();
            foreach (IEnumerable<HammerAndPosition> forgeSequence in forgeSequences)
            {
                string result = Forge(forgeSequence, hammerList);
                if (result != null)
                {
                    forgedKeys.Add(result);
                }
            }

            if (!forgedKeys.Any())
            {
                Console.WriteLine($"\t- Found no valid forge sequencies...");
                return;
            }

            Console.WriteLine($"\t- Found {forgedKeys.Count} valid forge sequences...\n");

            for (int i = 0; i < forgedKeys.Count; i++)
            {
                Console.WriteLine($"\t- Sequence #{i+1} forges key \"{forgedKeys[i]}\"");
            }
        }

        private static IEnumerable<Hammer> LoadHammers()
        {
            foreach (string line in LoadEmbeddedFile("hammer_collection").Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                yield return new()
                {
                    Index = Convert.ToInt32(line[..line.IndexOf('.')]),
                    HammerType = line[(line.IndexOf(' ') + 1)..][0],
                    ConvertTo = line[(line.IndexOf('>') + 2)..].Trim()
                };
            }
        }

        private static IEnumerable<IEnumerable<HammerAndPosition>> LoadForgeSequences()
        {
            foreach (string line in LoadEmbeddedFile("11_keymaker_recipe").Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                Queue<HammerAndPosition> forgeSequence = new();

                foreach (string hammerAndPosition in line.Split('-').Select(x => x.Trim().Trim('(').Trim(')')))
                {
                    forgeSequence.Enqueue(new()
                    {
                        Hammer = Convert.ToInt32(hammerAndPosition[..hammerAndPosition.IndexOf(',')]),
                        Position = Convert.ToInt32(hammerAndPosition[(hammerAndPosition.IndexOf(',')+1)..].Trim())
                    });
                }

                yield return forgeSequence;
            }
        }

        private static bool TryApplyHammer(int index, char input, IEnumerable<Hammer> hammerList, out string transformation)
        {
            transformation = null;

            if (!hammerList.Any(x => x.Index == index) || hammerList.First(x => x.Index == index).HammerType != input)
            {
                return false;
            }

            transformation = hammerList.First(x => x.Index == index).ConvertTo;

            return true;
        }

        private static string Forge(IEnumerable<HammerAndPosition> forgeSequence, IEnumerable<Hammer> hammerList)
        {
            string key = "A";

            foreach(HammerAndPosition hap in forgeSequence)
            {
                if (hap.Position -1 > key.Length-1 || !TryApplyHammer(hap.Hammer, key[hap.Position-1], hammerList, out string transformation))
                {
                    return null;
                }
                key = key.Remove(hap.Position - 1, 1).Insert(hap.Position-1, transformation);
            }

            return key;
        }
        #endregion

        #region Puzzle 2
        [State(StateAttribute.Types.Empty)]
        public static void Puzzle2()
        {

        }
        #endregion

        #region Puzzle 3
        [State(StateAttribute.Types.Uncomplete)]
        public static void Puzzle3()
        {
            IEnumerable<TrapBalanced> trapList = LoadBalancedTraps();

            Console.WriteLine($"\t- Loaded {trapList.Count()} balanced traps from \"13_trap_balance.txt\"...");

            var ss = trapList.Count(x => x.IsTrapSafe);
            var sss = trapList.Count(x => !x.IsTrapSafe);

            var tt = trapList.Where(x => x.IsTrapSafe).Sum(x => x.Id);
        }

        private static IEnumerable<TrapBalanced> LoadBalancedTraps()
        {
            foreach (string line in LoadEmbeddedFile("13_trap_balance").Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()))
            {
                string[] weights = line[(line.IndexOf(':') + 1)..].Trim().Split('-').Select(x => x.Trim()).ToArray();

                if (weights.Length != 2)
                {
                    yield return null;
                }

                yield return new()
                {
                    Id = Convert.ToInt32(line[..line.IndexOf(':')]),
                    Left = weights[0].Split(' ').Select(x => Convert.ToUInt64(x)).ToArray(),
                    Right = weights[1].Split(' ').Select(x => Convert.ToUInt64(x)).ToArray()
                };
            }
        }
        #endregion

        #region Story
        [State(StateAttribute.Types.Empty)]
        public static void Story()
        {
            Console.WriteLine($"\t- By overlaying all three plates on the \"cipher_matrix.png\" we see the following symobls...\n\n");
        }
        #endregion
    }
}
