using CodingChallange2022.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CodingChallange2022
{
    internal static class HelperFunctions
    {
        public static string LoadEmbeddedFile(string filename)
        {
            using (Stream s = typeof(HelperFunctions).Assembly.GetManifestResourceStream($"CodingChallange2022.Resources.{filename}{(!filename.EndsWith("txt") ? ".txt" : "")}"))
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

        public static IEnumerable<Employee> LoadOfficeDatabase(string database, char delimiter = ',')
        {
            foreach (string line in database.Split('\n').Where(x => !string.IsNullOrEmpty(x) && x.Length > 1))
            {
                string[] parts = line.Split(delimiter).Select(x => x.Trim()).ToArray();

                TimeOnly.TryParse(parts[3], CultureInfo.InvariantCulture, DateTimeStyles.None, out TimeOnly timeResult);

                yield return new()
                {
                    Username = parts[0],
                    Id = Convert.ToUInt64(parts[1]),
                    AccessKey = Convert.ToUInt32(parts[2]),
                    LoginTime = timeResult == default ? null : timeResult,
                };
            }
        }
    }
}
