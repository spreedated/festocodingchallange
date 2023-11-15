using System.Numerics;

namespace CodingChallange2022.Models
{
    internal record Planet
    {
        public string Name { get; set; }
        public Vector3 Coordinate { get; set; }
    }
}
