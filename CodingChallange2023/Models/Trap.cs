using System.Collections.Generic;
using System.Linq;

namespace CodingChallange2023.Models
{
    internal record Trap
    {
        public int Id { get; set; }
        public Stack<string> Seqeunce { get; set; }

        public bool IsTrapSafe
        {
            get
            {
                if (this.Seqeunce == null || !this.Seqeunce.Any())
                {
                    return false;
                }

                bool b = false;

                foreach (string l in this.Seqeunce.Reverse().ToArray())
                {
                    switch (l)
                    {
                        case "inactive":
                        case "disabled":
                        case "quiet":
                        case "standby":
                        case "idle":
                            b = true;
                            break;
                        case "live":
                        case "armed":
                        case "ready":
                        case "primed":
                        case "active":
                            b = false;
                            break;
                        case "flipped":
                        case "toggled":
                        case "reversed":
                        case "inverted":
                        case "switched":
                            b = !b;
                            break;
                    }
                }

                return b;
            }
        }
    }
}
