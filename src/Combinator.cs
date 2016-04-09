using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple.Comb
{
    public class Combination
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Combination(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }

    public class CombinationWithHighCard
    {
        public Combination Combination { get; set; }
        public int Priority { get; set; }
        public Card[] Cards { get; set; }

        public CombinationWithHighCard(Combination combination, Card[] cards)
        {
            Combination = combination;
            Cards = cards;
            Priority = GetHigh(cards);
        }

        private static int GetHigh(Card[] cards)
        {
            if (cards.Length == 0)
                return 0;
            return cards.Select(c => Helpers.GetPoinsByRank(c.Rank)).Max();
        }
    }

    public static class Combinations
    {
        public static Combination StraightFlash = new Combination("StraightFlash", 8);
        public static Combination Quad = new Combination("Quad", 7);
        public static Combination FullHouse = new Combination("FullHouse",6);
        public static Combination Flash = new Combination("Flash",5);
        public static Combination Straight = new Combination("Straight", 4);
        public static Combination Trio = new Combination("Trio", 3);
        public static Combination TwoPairs = new Combination("TwoPairs", 2);
        public static Combination Pair = new Combination("Pair", 1);
        public static Combination Nothing = new Combination("Nothing", 0);
    }

    public class Combinator
    {
        public CombinationWithHighCard Combinate(Card[] cards)
        {
            return null;
        }

        private CombinationWithHighCard FindFlash(Card[] cards)
        {
            var s1 = cards.Where(c => c.Suit == Suit.Clubs).ToArray();
            if (s1.Length == 5)
                return new CombinationWithHighCard(Combinations.Flash, s1);

            var s2 = cards.Where(c => c.Suit == Suit.Spades).ToArray();
            if (s2.Length == 5)
                return new CombinationWithHighCard(Combinations.Flash, s2);

            var s3 = cards.Where(c => c.Suit == Suit.Hearts).ToArray();
            if (s3.Length == 5)
                return new CombinationWithHighCard(Combinations.Flash, s3);

            var s4 = cards.Where(c => c.Suit == Suit.Diamonds).ToArray();
            if (s4.Length == 5)
                return new CombinationWithHighCard(Combinations.Flash, s4);

            return null;
        }
    }
}
