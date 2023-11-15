using System;

namespace TextUserInterface.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class AuthorsAttribute : Attribute
    {
        public string[] Authors { get; init; }
        public AuthorsAttribute(params string[] authors)
        {
            this.Authors = authors;
        }
    }
}
