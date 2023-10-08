using System;

namespace CodingChallange2023.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class StateAttribute : Attribute
    {
        public enum Types
        {
            Uncomplete,
            Finished,
            Empty
        }

        public Types Type { get; init; }

        public StateAttribute(Types type) : base()
        {
            this.Type = type;
        }
    }
}
