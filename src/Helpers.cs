using System;
using System.Linq;

namespace Nancy.Simple.Comb
{
    public static class Helpers
    {
        public static int GetPoinsByRank(string rank)
        {
            int result;
            if (int.TryParse(rank, out result))
                return result;
            if (string.Compare(rank, "J", StringComparison.InvariantCultureIgnoreCase) == 0)
                return 11;
            if (string.Compare(rank, "Q", StringComparison.InvariantCultureIgnoreCase) == 0)
                return 12;
            if (string.Compare(rank, "K", StringComparison.InvariantCultureIgnoreCase) == 0)
                return 13;
            if (string.Compare(rank, "A", StringComparison.InvariantCultureIgnoreCase) == 0)
                return 14;
            return 0;
        }

        public static int GetHigh(Card[] cards)
        {
            if (cards.Length == 0)
                return 0;
            return cards.Select(c => GetPoinsByRank(c.Rank)).Max();
        }

        public static bool IsStraight(Card[] cards, int count)
        {
            var sortedRanks = cards
               .Select(c => Helpers.GetPoinsByRank(c.Rank))
               .OrderBy(x => x)
               .ToArray();

            var co = 0;
            for (int i = 0; i < sortedRanks.Length; i++)
            {
                if (i != 0 && (sortedRanks[i - 1] == 14
                        ? sortedRanks[i] != 2
                        : sortedRanks[i] != sortedRanks[i - 1] + 1))
                {
                    co = 0;
                }
                co++;
            }
            return co >= count;
        }

        public static bool IsStraight(Card[] cards)
        {
            var sortedRanks = cards
               .Select(c => Helpers.GetPoinsByRank(c.Rank))
               .OrderBy(x => x)
               .ToArray();
            for (int i = 0; i < sortedRanks.Length; i++)
            {
                if (i != 0)
                {
                    if ((sortedRanks[i - 1] == 14
                        ? sortedRanks[i] != 2
                        : sortedRanks[i] != sortedRanks[i - 1] + 1))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsFlash(Card[] cards, int count)
        {
            var c1 = cards.Count(c => c.Suit == Suit.Clubs);
            var c2 = cards.Count(c => c.Suit == Suit.Spades);
            var c3 = cards.Count(c => c.Suit == Suit.Hearts);
            var c4 = cards.Count(c => c.Suit == Suit.Diamonds);
            var max = new[] {c1, c2, c3, c4}.Max();
            return max >= count;
        }

        public static bool IsFlash(Card[] cards)
        {
            return
                cards.All(c => c.Suit == Suit.Clubs)
                || cards.All(c => c.Suit == Suit.Spades)
                || cards.All(c => c.Suit == Suit.Hearts)
                || cards.All(c => c.Suit == Suit.Diamonds);
        }
    }
}