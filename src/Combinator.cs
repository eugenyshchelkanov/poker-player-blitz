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
        public int Priority { get; set; }
        public Card[] Cards { get; set; }

        public CombinationWithHighCard(Combination combination, params Card[] cards)
        {
            Combination = combination;
            Cards = cards;
            Priority = Helpers.GetHigh(cards);
        }
    }

    public static class Combinations
    {
        public static Combination StraightFlash = new Combination("StraightFlash", 9);
        public static Combination Quad = new Combination("Quad", 8);
        public static Combination FullHouse = new Combination("FullHouse", 7);
        public static Combination Flash = new Combination("Flash",6);
        public static Combination Straight = new Combination("Straight", 5);
        public static Combination Trio = new Combination("Trio", 4);
        public static Combination TwoPairs = new Combination("TwoPairs", 3);
        public static Combination Pair = new Combination("Pair", 2);
        public static Combination One = new Combination("One", 1);
    }

    public class Combinator
    {
        public CombinationWithHighCard[] Combinate(Card[] cards)
        {
            var result = new List<CombinationWithHighCard>();

            FindQuad(result, cards);
            FindFlash(result, cards);
            FindTrio(result, cards);
            FindTwoPairs(result, cards);
            FindPair(result, cards);

            return result.ToArray();
        }

        private void FindPair(List<CombinationWithHighCard> result, Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                var card1 = cards[i];
                for (int j = 0; j < cards.Length; j++)
                {
                    var card2 = cards[j];

                    if (i == j)
                        continue;

                    if (card1.Suit == card2.Suit)
                        result.Add(new CombinationWithHighCard(Combinations.Pair, card1, card2));
                }
            }
        }

        private void FindTrio(List<CombinationWithHighCard> result, Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                var card1 = cards[i];
                for (int j = 0; j < cards.Length; j++)
                {
                    var card2 = cards[j];
                    for (int k = 0; k < cards.Length; k++)
                    {
                        var card3 = cards[k];
                        
                        if (i == j || i == k || j == k)
                            continue;

                        if (card1.Suit == card2.Suit && card1.Suit == card3.Suit)
                            result.Add(new CombinationWithHighCard(Combinations.Trio, card1, card2, card3));
                    }
                }
            }
        }

        private void FindTwoPairs(List<CombinationWithHighCard> result, Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                var card1 = cards[i];
                for (int j = 0; j < cards.Length; j++)
                {
                    var card2 = cards[j];
                    for (int k = 0; k < cards.Length; k++)
                    {
                        var card3 = cards[k];
                        for (int l = 0; l < cards.Length; l++)
                        {
                            var card4 = cards[l];

                            if (i == j || i == k || i == l
                                || j == k || j == l
                                || k == l)
                                continue;

                            if (card1.Suit == card2.Suit && card3.Suit == card4.Suit)
                                result.Add(new CombinationWithHighCard(Combinations.TwoPairs, card1, card2, card3, card4));
                            if (card1.Suit == card3.Suit && card2.Suit == card4.Suit)
                                result.Add(new CombinationWithHighCard(Combinations.TwoPairs, card1, card2, card3, card4));
                            if (card1.Suit == card4.Suit && card2.Suit == card3.Suit)
                                result.Add(new CombinationWithHighCard(Combinations.TwoPairs, card1, card2, card3, card4));
                        }
                    }
                }
            }
        }

        private void FindQuad(List<CombinationWithHighCard> result, Card[] cards)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                var card1 = cards[i];
                for (int j = 0; j < cards.Length; j++)
                {
                    var card2 = cards[j];
                    for (int k = 0; k < cards.Length; k++)
                    {
                        var card3 = cards[k];
                        for (int l = 0; l < cards.Length; l++)
                        {
                            var card4 = cards[l];

                            if (i == j || i == k || i == l
                                || j == k || j == l
                                || k == l)
                                continue;

                            if (card1.Suit == card2.Suit && card1.Suit == card3.Suit && card1.Suit == card4.Suit)
                                result.Add(new CombinationWithHighCard(Combinations.Quad, card1, card2, card3, card4));
                        }
                    }
                }
            }
        }

        private void FindFlash(List<CombinationWithHighCard> result, Card[] cards)
        {
            var s1 = cards.Where(c => c.Suit == Suit.Clubs).ToArray();
            if (s1.Length == 5)
               result.Add(new CombinationWithHighCard(Combinations.Flash, s1));

            var s2 = cards.Where(c => c.Suit == Suit.Spades).ToArray();
            if (s2.Length == 5)
                result.Add(new CombinationWithHighCard(Combinations.Flash, s2));

            var s3 = cards.Where(c => c.Suit == Suit.Hearts).ToArray();
            if (s3.Length == 5)
                result.Add(new CombinationWithHighCard(Combinations.Flash, s3));

            var s4 = cards.Where(c => c.Suit == Suit.Diamonds).ToArray();
            if (s4.Length == 5)
                result.Add(new CombinationWithHighCard(Combinations.Flash, s4));
        }
    }
}
