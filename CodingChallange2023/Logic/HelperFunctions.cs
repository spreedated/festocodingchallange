using System;
using System.Collections.Generic;
using System.Linq;
using static TextUserInterface.HelperFunctions;

namespace CodingChallange2023.Logic
{
    internal static class HelperFunctions
    {
        public static IEnumerable<string> LoadSymoblsFromEmbeddedFile(string filename)
        {
            string file = LoadEmbeddedFile(filename);

            int symbolHeight = 7;
            int linesBetweenSymbols = 1;
            int skip = 0;

            for (int i = 0; i < (int)Math.Ceiling((double)file.Split('\n').Length / (symbolHeight + linesBetweenSymbols)); i++)
            {
                yield return string.Join('\n', file.Split('\n').Skip(skip).Take(symbolHeight));
                skip += symbolHeight + linesBetweenSymbols;
            }
        }

        public static void EchoSymbols(IEnumerable<string> symbols)
        {
            int spacesBetweenSymbols = 7;

            for (int i = 0; i < symbols.First().Split('\n').Length; i++)
            {
                Console.WriteLine($"\t  {string.Join(new string(' ', spacesBetweenSymbols), symbols.Select(x => x.Split('\n')[i].PadRight(15)))}");
            }
        }
    }
}
