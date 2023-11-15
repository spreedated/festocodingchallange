namespace CodingChallange2022.Models
{
    internal record PopulationRecord
    {
        public string Name { get; set; }
        public ulong Id { get; set; }
        public string HomePlanet { get; set; }
        public Cells[,] BloodSample { get; set; }

        public enum Cells
        {
            Unknown,
            None,
            P,
            I,
            C,
            O
        }
    }
}
