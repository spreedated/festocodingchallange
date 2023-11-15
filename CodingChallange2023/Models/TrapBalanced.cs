using System.Collections.Generic;
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
                if (this.Left.Intersect(this.Right).Any() || this.Left.Distinct().Count() != this.Left.Length || this.Right.Distinct().Count() != this.Right.Length)
                {
                    return false;
                }

                //Rule of equality, by calculation
                IEnumerable<Fraction<ulong>> leftSide = this.Left.Select(x => new Fraction<ulong>(1, x));
                IEnumerable<Fraction<ulong>> rightSide = this.Right.Select(x => new Fraction<ulong>(1, x));

                Fraction<ulong> leftFractions = new(1, 1);
                foreach (var item in leftSide)
                {
                    leftFractions += item;
                }
                Fraction<ulong> rightFractions = new(1, 1);
                foreach (var item in rightSide)
                {
                    rightFractions += item;
                }

                if (Fraction<ulong>.Reduce(leftFractions) != Fraction<ulong>.Reduce(rightFractions))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
