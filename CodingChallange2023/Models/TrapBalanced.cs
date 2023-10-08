using System.Linq;

namespace CodingChallange2023.Models
{
    internal record TrapBalanced
    {
        public int Id { get; set; }
        public ulong[] Left { get; set; }
        public ulong[] Right { get; set; }

        public bool IsTrapSafe
        {
            get
            {
                //Rule of equality
                if ((this.Left == null || this.Right == null) || this.Left.Length != this.Right.Length)
                {
                    return false;
                }

                //Rule of diversity
                if (this.Left.Intersect(this.Right).Any())
                {
                    return false;
                }

                //Calculate the difference in times larger
                //from both sides highest denominator
                decimal factor = 0m;
                if (this.Left.Max() > this.Right.Max())
                {
                    factor = (decimal)this.Left.Max() / this.Right.Max();
                }
                else
                {
                    factor = (decimal)this.Right.Max() / this.Left.Max();
                }
                //If one sides denomintor is 20,000 times larger than the other
                //it's unlikely to be safe
                if (factor > 20000m)
                {
                    return false;
                }

                //Second rule of equality, by calculation
                if (this.Left.Sum(x => (decimal)1/x) != this.Right.Sum(x => (decimal)1 / x))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
