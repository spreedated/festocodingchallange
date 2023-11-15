using System;
using System.Security.Cryptography;
using System.Text;
using TextUserInterface.Attributes;

namespace CodingChallange2020.Puzzles
{
    [Chapter(0, "Training II")]
    [State(StateAttribute.Types.Complete)]
    internal static class TrainingII
    {
        public static void Solve()
        {
            Console.WriteLine($"\tComputing MD5 Hash of \"Ok, got it. Easy!\"...");
            byte[] mD5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes("Ok, got it. Easy!"));
            Console.WriteLine($"\tFirst five characters are \"{Convert.ToHexString(mD5)[..5].ToUpper()}\"!");
        }
    }
}
