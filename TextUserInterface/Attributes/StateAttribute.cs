using System;

namespace TextUserInterface.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class StateAttribute : Attribute
    {
        public enum Types
        {
            Empty,
            Unfinished,
            Complete,
        }

        public Types Type { get; init; }

        public StateAttribute(Types type) : base()
        {
            this.Type = type;
        }
    }
}
