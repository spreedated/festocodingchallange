using CodingChallange2022.Models;
using System.Collections.Generic;

namespace CodingChallange2022.Comparers
{
    public class PopulationEqualityComparer : IEqualityComparer<PopulationRecord>
    {
        bool IEqualityComparer<PopulationRecord>.Equals(PopulationRecord x, PopulationRecord y)
        {
            return x.Id == y.Id;
        }

        int IEqualityComparer<PopulationRecord>.GetHashCode(PopulationRecord obj)
        {
            return obj.GetHashCode();
        }
    }
}
