using System.Linq;
using Nancy.Simple.Comb;

namespace Nancy.Simple.Logic
{
    public class Flop
    {
        public static LogicResult Result(GameState state)
        {
            var best = Combinator.GetBest(state.CommunityCards.Concat(state.GetMyCards()).ToArray());
            if (best.Combination == Combinations.One)
                return new LogicResult {CanRespondToAllIn = false, RaiseOdds = 0, CallOdds = 0};

            if(best.Combination == Combinations.FullHouse || best.Combination == Combinations.Flash || best.Combination == Combinations.Quad)
                return new LogicResult { CanRespondToAllIn = true, RaiseOdds = 1, CallOdds = 1 };

            if (best.Combination == Combinations.Straight || best.Combination == Combinations.Trio || best.Combination == Combinations.TwoPairs)
                return new LogicResult { CanRespondToAllIn = false, RaiseOdds = 0, CallOdds = 1 };

            return new LogicResult { CanRespondToAllIn = false, RaiseOdds = 0, CallOdds = 0.25 };
        }
    }
}