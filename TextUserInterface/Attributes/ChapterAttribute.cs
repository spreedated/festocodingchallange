using System;

namespace TextUserInterface.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ChapterAttribute : Attribute
    {
        public int Order { get; init; }
        public string Chapter { get; init; }
        public ChapterAttribute(int order, string chapter)
        {
            this.Chapter = chapter;
            this.Order = order;
        }
    }
}
