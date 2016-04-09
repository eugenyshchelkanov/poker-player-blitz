namespace Nancy.Simple.Logic
{
    public class River
    {
        public static LogicResult Result(GameState state)
        {
            var cards = state.GetMyCards();
            var card1 = cards[0];
            var card2 = cards[1];

            if (card1.Rank == "A" && card2.Rank == "A")
            {
                return new LogicResult() { BestBetInPots = 10, CanRespondToAllIn = true };
            }
            if (card1.Rank == "K" && card2.Rank == "K")
            {
                return new LogicResult() { BestBetInPots = 8, CanRespondToAllIn = true };
            }
            if (card1.Rank == "Q" && card2.Rank == "Q")
            {
                return new LogicResult() { BestBetInPots = 6, CanRespondToAllIn = true };
            }

            if (card1.Rank.Equals(card2.Rank))
            {
                return new LogicResult() { BestBetInPots = 5, CanRespondToAllIn = false };
            }

            if (card1.Suit.Equals(card2.Suit))
            {
                return new LogicResult() { BestBetInPots = 5, CanRespondToAllIn = false };
            }

            if (card1.Rank == "A" || card1.Rank == "K" || card1.Rank == "Q" || card2.Rank == "A" || card2.Rank == "K" || card2.Rank == "Q")
            {
                return new LogicResult() { BestBetInPots = 5, CanRespondToAllIn = false };
            }

            if (card1.Suit.Equals(card2.Suit))
            {
                return new LogicResult() { BestBetInPots = 5, CanRespondToAllIn = false };
            }

            return new LogicResult() { BestBetInPots = 0, CanRespondToAllIn = false };
        }
    }
}