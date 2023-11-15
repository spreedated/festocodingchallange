namespace CodingChallange2023.Models
{
    internal class DeviceCryptedLine
    {
        public DeviceEncryption.Types Type { get; set; }
        public string First {  get; set; }
        public string Second {  get; set; }
        public bool[] Value { get; set; }
    }
}
