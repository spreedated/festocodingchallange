﻿using CodingChallange2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TextUserInterface.Attributes;
using static TextUserInterface.HelperFunctions;
using static CodingChallange2023.Logic.HelperFunctions;
using static CodingChallange2023.Logic.Constants;

namespace CodingChallange2023.Episodes
{
    [Chapter(0, "Tutorial - Titan's Gateway")]
    [State(StateAttribute.Types.Complete)]
    internal static class Tutorial
    {
        public static void Solve()
        {
            Console.WriteLine("Tutorial:\n");
            Console.WriteLine("\t\t\"Titan's Gateway\"\n\n");

            Puzzle1();
            Puzzle2();
            Puzzle3();
            Story();
        }

        #region Puzzle 1
        [Authors(AUTHOR_MAIN, AUTHOR_SIDEKICK_1)]
        [State(StateAttribute.Types.Complete)]
        public static void Puzzle1()
        {
            IEnumerable<Key> keys = LoadKeys();

            Console.WriteLine($"\t- Loaded {keys.Count()} keys from \"01_keymaker_ordered.txt\"...");

            Key[] orderedKeys = keys.Where(x => x.IsOrdered).ToArray();

            if (!orderedKeys.Any())
            {
                Console.WriteLine($"\t- No ordered keys found...\n");
                return;
            }

            Console.WriteLine($"\t- Found {orderedKeys.Length} ordered keys...\n");

            for (int i = 0; i < orderedKeys.Length; i++)
            {
                Console.WriteLine($"\t- Key #{i + 1} \"{orderedKeys[i].Value}\"");
            }
        }

        private static IEnumerable<Key> LoadKeys()
        {
            foreach (string line in LoadEmbeddedFile("01_keymaker_ordered").Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()))
            {
                yield return new()
                {
                    Value = line,
                };
            }
        }
        #endregion

        #region Puzzle 2
        [State(StateAttribute.Types.Complete)]
        public static void Puzzle2()
        {
            IEnumerable<DeviceEncryption> cryptionMatrix = LoadEncryptionMatrix();

            Console.WriteLine($"\t- Encryption Matrix:\n\n\t");
            Console.WriteLine(string.Join('\n', LoadEmbeddedFile("02_encryption_matrix").Split('\n').Select(x => $"\t\t{x}")));

            IEnumerable<DeviceCryptedLine> encryptedLines = LoadEncryptedLines();

            Console.WriteLine($"\n\n\t- Display:\n\n\t");
            Console.WriteLine(string.Join('\n', LoadEmbeddedFile("02_crypted").Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => $"\t\t{x}")));
            Console.WriteLine("");

            IEnumerable<DeviceCryptedLine> decryptedLines = DecryptLines(cryptionMatrix, encryptedLines);

            for (int i = 0; i < decryptedLines.Count(); i++)
            {
                Console.WriteLine($"\t- Sequence from {i + 1} decrypted line \"{string.Join("", decryptedLines.ToArray()[i].Value.Select(x => x ? '1' : '0'))}\"...");
            }

            Console.WriteLine($"\n\t- Final result is \"{string.Join("", decryptedLines.SelectMany(x => x.Value).Select(y => y ? '1' : '0'))}\" by concatinating {encryptedLines.Count()} encrypted lines!");
        }

        private static IEnumerable<DeviceEncryption> LoadEncryptionMatrix()
        {
            foreach (string line in LoadEmbeddedFile("02_encryption_matrix").Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()))
            {
                yield return new()
                {
                    Type = line.Contains("R;") ? DeviceEncryption.Types.RQ : DeviceEncryption.Types.NQ,
                    Value = line.EndsWith('1'),
                    First = line[..1][0],
                    Second = line[(line.IndexOf(';') + 1)..].Trim()[..1][0]
                };
            }
        }

        private static IEnumerable<DeviceCryptedLine> LoadEncryptedLines()
        {
            foreach (string line in LoadEmbeddedFile("02_crypted").Split('\n').Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim()))
            {
                yield return new()
                {
                    Type = line.Contains("R;") ? DeviceEncryption.Types.RQ : DeviceEncryption.Types.NQ,
                    First = line[..line.IndexOf(';')],
                    Second = line[(line.IndexOf(' ') + 1)..(line.IndexOf(' ') + 5)]
                };
            }
        }

        private static DeviceCryptedLine[] DecryptLines(IEnumerable<DeviceEncryption> cryptionMatrix, IEnumerable<DeviceCryptedLine> cryptedLines)
        {
            DeviceCryptedLine[] crypted = cryptedLines.ToArray();

            foreach (DeviceCryptedLine crypt in crypted)
            {
                bool[] values = new bool[(crypt.First.Length + crypt.Second.Length) / 2];

                for (int i = 0; i < (crypt.First.Length + crypt.Second.Length) / 2; i++)
                {
                    values[i] = cryptionMatrix.Where(x => x.Type == crypt.Type).First(y => y.First == crypt.First[i] && y.Second == crypt.Second[i]).Value;
                }

                crypt.Value = values;
            }

            return crypted;
        }
        #endregion

        #region Puzzle 3
        [Authors(AUTHOR_MAIN, AUTHOR_SIDEKICK_1)]
        [State(StateAttribute.Types.Complete)]
        public static void Puzzle3()
        {
            IEnumerable<Trap> trapList = LoadTrapLog();
            Console.WriteLine($"\t- Loaded Trap Log with {trapList.Count()} entries from \"03_trap_logs.txt\"...");

            Console.WriteLine($"\t- {trapList.Count(x => x.IsTrapSafe)} safe traps found...");

            Console.WriteLine($"\t- Sum of ID's of safe traps \"{trapList.Where(x => x.IsTrapSafe).Sum(x => (Int64)x.Id)}\"...");
        }

        public static IEnumerable<Trap> LoadTrapLog()
        {
            string trapfile = LoadEmbeddedFile("03_trap_logs");

            foreach (string line in trapfile.Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                yield return new()
                {
                    Id = Convert.ToInt32(line[..line.IndexOf(':')]),
                    Seqeunce = new(line[(line.IndexOf(':') + 1)..].Split().Where(x => !string.IsNullOrEmpty(x)))
                };
            }
        }
        #endregion

        #region Story
        [State(StateAttribute.Types.Complete)]
        public static void Story()
        {
            Console.WriteLine($"\t- By overlaying all three plates on the \"cipher_matrix.png\" we see the following symbols...\n\n");
            EchoSymbols(LoadSymoblsFromEmbeddedFile("story_plates_tut"));
        }
        #endregion
    }
}
