using System.IO;

namespace CodingChallange2023
{
    internal static class HelperFunctions
    {
        public static string LoadEmbeddedFile(string filename)
        {
            using (Stream s = typeof(HelperFunctions).Assembly.GetManifestResourceStream($"CodingChallange2023.Resources.{filename}{(!filename.EndsWith("txt") ? ".txt" : "")}"))
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
    }
}
