﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TextUserInterface.Attributes;

namespace CodingChallange2020.Puzzles
{
    [Chapter(1, "Training III")]
    [State(StateAttribute.Types.Unfinished)]
    internal static class TrainingIII
    {
        private static List<char> permutationList = new();

        public static void Solve()
        {
            var u = GeneratePermutations("aaa");
            string found = null;

            foreach (string perm in u)
            {
                byte[] md5 = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(perm));

                if (Convert.ToHexString(md5).ToLower().StartsWith("19acf8371f"))
                {
                    found = perm;
                    break;
                }
            }
        }

        private static List<string> GeneratePermutations(string input)
        {
            char[] array = input.ToCharArray().OrderBy(c => c).ToArray();
            Span<char> spanInput = array.AsSpan();

            List<string> result = new()
            {
                new string(spanInput)
            };

            while (NextPermutation(spanInput))
            {
                result.Add(new string(spanInput));
            }

            return result;
        }

        public static bool NextPermutation(Span<char> input)
        {
            int i = input.Length - 2;
            while (i >= 0 && input[i] >= input[i + 1])
            {
                i--;
            }

            if (i < 0)
            {
                return false;
            }

            int j = input.Length - 1;

            while (input[j] <= input[i])
            {
                j--;
            }

            (input[i], input[j]) = (input[j], input[i]);

            Reverse(input, i + 1);

            return true;
        }

        private static void Reverse(Span<char> input, int start)
        {
            int i = start;
            int j = input.Length - 1;

            while (i < j)
            {
                (input[i], input[j]) = (input[j], input[i]);
                i++;
                j--;
            }
        }
    }
}
