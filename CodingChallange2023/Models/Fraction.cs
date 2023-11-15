using System.Numerics;
using TextUserInterface.Attributes;

namespace CodingChallange2023.Models
{
    [Authors("S.E.")]
    public readonly struct Fraction<T> where T : struct, INumber<T>
    {
        public T Numerator { get; }
        public T Denominator { get; }

        public Fraction(T numerator, T denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public static bool operator ==(Fraction<T> a, Fraction<T> b)
        {
            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(Fraction<T> a, Fraction<T> b)
        {
            return !(a == b);
        }

        public static Fraction<T> operator +(Fraction<T> a, Fraction<T> b)
        {
            if (a.Denominator == b.Denominator) return new(a.Numerator + b.Numerator, a.Denominator);

            T c = a.Denominator * b.Numerator + b.Denominator * a.Numerator;
            T cc = a.Denominator * b.Denominator;

            return new(c, cc);
        }

        public static Fraction<T> operator -(Fraction<T> a, Fraction<T> b)
        {
            if (a.Denominator == b.Denominator) return new(a.Numerator - b.Numerator, a.Denominator);

            T c = a.Denominator * b.Numerator - b.Denominator * a.Numerator;
            T cc = a.Denominator * b.Denominator;

            return new(c, cc);
        }

        public static Fraction<T> operator *(Fraction<T> a, Fraction<T> b)
            => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction<T> operator *(Fraction<T> a, T b)
            => new(a.Numerator * b, a.Denominator * b);

        public static Fraction<T> operator /(Fraction<T> a, Fraction<T> b)
        {
            return a * new Fraction<T>(b.Denominator, b.Numerator);
        }

        public static Fraction<T> operator /(Fraction<T> a, T b)
        {
            return a * new Fraction<T>(T.One, b);
        }

        /// <summary>
        /// Greatest Common Factor
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        public static T GetGCF(Fraction<T> fraction)
        {
            T a = fraction.Numerator;
            T b = fraction.Denominator;

            while (b != T.Zero)
            {
                T temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public static Fraction<T> Reduce(Fraction<T> a)
        {
            T gcf = GetGCF(a);

            return new(a.Numerator / gcf, a.Denominator / gcf);
        }

        public override bool Equals(object obj)
            => obj is Fraction<T> f && f == this;

        public override int GetHashCode()
            => this.Denominator.GetHashCode() + this.Numerator.GetHashCode();
    }
}
