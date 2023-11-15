using CodingChallange2022.Comparers;
using CodingChallange2022.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CodingChallange2022.HelperFunctions;

namespace CodingChallange2022.Episodes
{
    internal static class Episode1
    {
        private static IEnumerable<Employee> employees;
        private static IEnumerable<PopulationRecord> population;
        private static IEnumerable<Planet> galaxyMap;
        private static IEnumerable<SecurityLogRecord> securityLog;

        public static void Solve()
        {
            Console.WriteLine("Intro:\n");
            Console.WriteLine("\t\t\"Your Coffee Mug\"\n\n");

            employees = LoadOfficeDatabase(LoadEmbeddedFile("office_database"));

            Console.WriteLine($"\t- Loaded {employees.Count()} Employees from \"office_database.txt\"...");

            Puzzle1();
            Puzzle2();
            Puzzle3();
        }

        private static void Puzzle3()
        {
            securityLog = LoadSecurityMap().OrderBy(x => x.Place).ThenBy(y => y.Time);

            IEnumerable<string> people = securityLog.Where(w => w.InNames != null).Select(x => x.InNames).SelectMany(y => y)
                .Union(securityLog.Where(w => w.OutNames != null).Select(x => x.OutNames).SelectMany(y => y));

            var ss = securityLog.Count(x => x.InNames != null && x.InNames.Any(y => y == "Shakuntala Lee")) + securityLog.Count(x => x.OutNames != null && x.OutNames.Any(y => y == "Shakuntala Lee"));

            var sx = people.Count(x => x == "Shakuntala Lee");
        }

        private static IEnumerable<SecurityLogRecord> LoadSecurityMap()
        {
            SecurityLogRecord.Places currentPlace = SecurityLogRecord.Places.Unknown;
            SecurityLogRecord record = new();

            foreach (string line in LoadEmbeddedFile("security_log").Split('\n'))
            {
                if (string.IsNullOrEmpty(line) && record.Time != default)
                {
                    record.Place = currentPlace;
                    yield return record;
                    record = new();
                }

                if (TimeOnly.TryParse(line, CultureInfo.InvariantCulture, DateTimeStyles.None, out TimeOnly t))
                {
                    record.Time = t;
                    continue;
                }

                if (line.StartsWith("in:"))
                {
                    record.InNames = line[(line.IndexOf(':')+1)..].Split(',').Select(x => x.Trim()).ToArray();
                    continue;
                }

                if (line.StartsWith("out:"))
                {
                    record.OutNames = line[(line.IndexOf(':')+1)..].Split(',').Select(x => x.Trim()).ToArray();
                    continue;
                }

                if (line.StartsWith("Place:"))
                {
                    FieldInfo fi = typeof(SecurityLogRecord.Places)
                        .GetFields(BindingFlags.Static | BindingFlags.Public)
                        .Where(y => y.CustomAttributes.Any())
                        .FirstOrDefault(x => x.GetCustomAttribute<DescriptionAttribute>().Description == line[(line.IndexOf(':') + 1)..].Trim());

                    currentPlace = fi == null ? SecurityLogRecord.Places.Unknown : (SecurityLogRecord.Places)fi.GetValue(null);
                    continue;
                }
            }
        }

        private static void Puzzle2()
        {
            galaxyMap = LoadGalaxyMap();

            g3.Vector3d bestFitPlane = new g3.OrthogonalPlaneFit3(galaxyMap.Select(x => new g3.Vector3d(x.Coordinate.X, x.Coordinate.Y, x.Coordinate.Z))).Normal;

            //TODO: finish
        }

        private static void Puzzle1()
        {
            population = LoadPopulationDatabase();
            Console.WriteLine($"\t- Loaded Populations Database with {population.Count()} entries from \"population.txt\"...");

            IEnumerable<PopulationRecord> positiveSamples = GetNumberOfPositiveBloodSamples().Distinct(new PopulationEqualityComparer());

            Console.WriteLine($"\t- {positiveSamples.Count()} of blood smaples with PICO Bots found...");

            Console.WriteLine($"\t- Sum of ID's with is \"{positiveSamples.Distinct().Sum(x => (Int64)x.Id)}\"...");
        }

        private static IEnumerable<Planet> LoadGalaxyMap()
        {
            foreach(string line in LoadEmbeddedFile("galaxy_map").Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                yield return new()
                {
                    Name = line[..line.IndexOf(':')].Trim(),
                    Coordinate = new()
                    {
                        X = float.Parse(line[(line.IndexOf('(')+1)..line.IndexOf(',')].Trim()),
                        Y = float.Parse(line[(line.IndexOf(',')+1)..line.LastIndexOf(',')].Trim()),
                        Z = float.Parse(line[(line.LastIndexOf(',')+1)..line.IndexOf(')')].Trim())
                    }
                };
            }
        }

        private static IEnumerable<PopulationRecord> GetNumberOfPositiveBloodSamples()
        {
            foreach (PopulationRecord p in population.Where(x => x.BloodSample != null))
            {
                //hor
                for (short i = 0; i < p.BloodSample.GetLength(0); i++)
                {
                    StringBuilder horLine = new();

                    for (short ii = 0; ii < p.BloodSample.GetLength(1); ii++)
                    {
                        if (p.BloodSample[i, ii] != PopulationRecord.Cells.Unknown)
                        {
                            horLine.Append(p.BloodSample[i, ii] == PopulationRecord.Cells.None ? " " : p.BloodSample[i, ii].ToString());
                        }
                    }

                    if (horLine.ToString().ToLower().Contains("pico") || horLine.ToString().ToLower().Contains("ocip"))
                    {
                        yield return p;
                    }
                }
                //###

                //vert
                for (short ii = 0; ii < p.BloodSample.GetLength(1); ii++)
                {
                    StringBuilder vertLine = new();

                    for (short i = 0; i < p.BloodSample.GetLength(0); i++)
                    {
                        if (p.BloodSample[i, ii] != PopulationRecord.Cells.Unknown)
                        {
                            vertLine.Append(p.BloodSample[i, ii] == PopulationRecord.Cells.None ? " " : p.BloodSample[i, ii].ToString());
                        }
                    }

                    if (vertLine.ToString().ToLower().Contains("pico") || vertLine.ToString().ToLower().Contains("ocip"))
                    {
                        yield return p;
                    }
                }
                //# ### #
            }
        }

        private static IEnumerable<PopulationRecord> LoadPopulationDatabase()
        {
            string filecontents = LoadEmbeddedFile("population");

            PopulationRecord record = null;
            short breakCount = 0;
            short bloodRecordPosition = 0;

            foreach (string item in filecontents.Split('\n').Where(x => !string.IsNullOrEmpty(x)))
            {
                if (item.Contains("+--------+"))
                {
                    breakCount++;
                }

                if (breakCount >= 2)
                {
                    breakCount = 0;
                    bloodRecordPosition = 0;
                    yield return record;
                }

                if (item.StartsWith("Name"))
                {
                    record = new()
                    {
                        Name = item[(item.IndexOf(':') + 1)..].Trim()
                    };
                    continue;
                }

                if (record == null)
                {
                    continue;
                }

                if (item.StartsWith("ID"))
                {
                    record.Id = Convert.ToUInt64(item[(item.IndexOf(':') + 1)..].Trim());
                    continue;
                }

                if (item.StartsWith("Home"))
                {
                    record.HomePlanet = item[(item.IndexOf(':') + 1)..].Trim();
                    continue;
                }

                if (item.Trim().StartsWith('|'))
                {
                    if (record.BloodSample == null)
                    {
                        record.BloodSample = new PopulationRecord.Cells[6, 8];
                    }

                    short c = 0;

                    foreach (char g in item.Trim().Trim('|'))
                    {
                        if (g == ' ')
                        {
                            record.BloodSample[bloodRecordPosition, c] = PopulationRecord.Cells.None;
                            c++;
                            continue;
                        }

                        if (!Enum.TryParse(g.ToString().ToUpper(), out PopulationRecord.Cells cellResult))
                        {
                            cellResult = PopulationRecord.Cells.Unknown;
                        }

                        record.BloodSample[bloodRecordPosition, c] = cellResult;
                        c++;
                    }

                    bloodRecordPosition++;

                    continue;
                }
            }

        }
    }
}
