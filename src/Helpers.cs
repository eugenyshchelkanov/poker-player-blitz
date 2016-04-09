using System;

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
    }
}