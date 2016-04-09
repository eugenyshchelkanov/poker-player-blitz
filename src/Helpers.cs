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
            return cards.Select(c => Helpers.GetPoinsByRank(c.Rank)).Max();
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