using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodingChallange2023.Models
{
    internal record TrapBalanced
    {
        public int Id { get; set; }
        public ulong[] Left { get; set; }
        public ulong[] Right { get; set; }

        private static decimal CalculateFractionResult(IEnumerable<ulong> sequence)
        {
            ulong gcd = sequence.ToArray()[0];

            foreach (ulong i in sequence.Skip(1))
            {
                gcd += gcd * i;
            }

            gcd -= sequence.ToArray()[0];

            List<decimal> gcdResults = new();

            foreach (ulong i in sequence)
            {
                gcdResults.Add((decimal)i / gcd);
            }

            return gcdResults.Sum(x => x);
        }

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

                if (CalculateFractionResult(this.Left) != CalculateFractionResult(this.Right))
                {
                    return false;
                }

                //Calculate the difference in times larger
                //from both sides highest denominator
                //decimal factor = 0m;
                //if (this.Left.Max() > this.Right.Max())
                //{
                //    factor = (decimal)this.Left.Max() / this.Right.Max();
                //}
                //else
                //{
                //    factor = (decimal)this.Right.Max() / this.Left.Max();
                //}
                ////If one sides denomintor is 20,000 times larger than the other
                ////it's unlikely to be safe
                //if (factor > 20000m)
                //{
                //    return false;
                //}

                //Second rule of equality, by calculation
                //if (this.Left.Cast<BigInteger>().Sum(x => BigInteger.Divide(1,x)) != this.Right.Cast<BigInteger>().Sum(x => BigInteger.Divide(1, x)))
                //{
                //    return false;
                //}

                //# ### #
                //List<BigInteger> leftList = new();
                //List<BigInteger> rightList = new();

                //foreach (ulong inte in this.Left)
                //{
                //    leftList.Add(BigInteger.Divide(1,inte));
                //}

                //foreach (ulong inte in this.Right)
                //{
                //    rightList.Add(BigInteger.Divide(1, inte));
                //}

                //BigInteger left = default;

                //foreach (BigInteger bint in leftList)
                //{
                //    BigInteger.Add(left, bint);
                //}

                //BigInteger right = default;

                //foreach (BigInteger bint in rightList)
                //{
                //    BigInteger.Add(right, bint);
                //}

                //if (BigInteger.Compare(left,right) != 0)
                //{
                //    return false;
                //}
                //# ### #

                return true;
            }
        }
    }
}
