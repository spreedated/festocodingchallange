namespace CodingChallange2023.Models
{
    internal class DeviceEncryption
    {
        public enum Types
        {
            RQ,
            NQ
        }

        public Types Type { get; set; }

        public char First { get; set; }
        public char Second { get; set; }
        public bool Value { get; set; }
    }
}