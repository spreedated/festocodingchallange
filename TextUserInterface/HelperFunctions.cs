using System;
using System.IO;
using System.Reflection;

namespace TextUserInterface
{
    public static class HelperFunctions
    {
        public static string LoadEmbeddedFile(string filename)
        {
            using (Stream s = Assembly.GetCallingAssembly().GetManifestResourceStream($"{Assembly.GetCallingAssembly().GetName().Name}.Resources.{filename}{(!filename.EndsWith("txt") ? ".txt" : "")}"))
            {
                if (s == null)
                {
                    return null;
                }

                using (StreamReader r = new(s))
                {
                    return r.ReadToEnd();
                }
            }
        }

        public static int GetUserSelection(int min, int max)
        {
            string input = Console.ReadLine();

            if (input == "x" || input == "X")
            {
                Environment.Exit(0);
            }

            if (input == "a" || input == "A")
            {
                return -1;
            }

            if (input == "r" || input == "R")
            {
                return -2;
            }

            if (!int.TryParse(input, out int intinput) || !(intinput >= min && intinput <= max))
            {
                return GetUserSelection(min, max);
            }

            return intinput;
        }
    }
}
