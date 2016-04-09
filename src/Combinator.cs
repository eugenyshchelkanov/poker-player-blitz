using System;
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
        public int Rank { get; set; }
        public Card[] Cards { get; set; }

        public CombinationWithHighCard(Combination combination, int rank, Card[] cards)
        {
            Combination = combination;
            Rank = rank;
            Cards = cards;
        }
    }

    public static class Combinations
    {
    }

    public class Combinator
    {
        public CombinationWithHighCard Combinate(Card[] cards)
        {
            return null;
        }
    }
}
