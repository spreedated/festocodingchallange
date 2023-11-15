using System;

namespace CodingChallange2022.Models
{
    internal sealed record Employee
    {
        public string Username { get; set; }
        public ulong Id { get; set; }
        public uint AccessKey { get; set; }
        public TimeOnly? LoginTime { get; set; }
    }
}
