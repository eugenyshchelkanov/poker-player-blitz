namespace Nancy.Simple.Logic
{
    public class Flop
    {
        public static LogicResult Result(GameState state)
        {
            var cards = state.GetMyCards();
            var card1 = cards[0];
            var card2 = cards[1];

            if (card1.Rank == "A" && card2.Rank == "A")
            {
                return new LogicResult() { BestBetInPots = 1, CanRespondToAllIn = true };
            }
            if (card1.Rank == "A" && card2.Rank == "K" && card1.Suit == card2.Suit)
            {
                return new LogicResult() { BestBetInPots = 1, CanRespondToAllIn = true };
            }
            if (card1.Rank == "K" && card2.Rank == "K")
            {
                return new LogicResult() { BestBetInPots = 1, CanRespondToAllIn = true };
            }
            if (card1.Rank == "Q" && card2.Rank == "Q")
            {
                return new LogicResult() { BestBetInPots = 1, CanRespondToAllIn = true };
            }
            if (card1.Rank == "J" && card2.Rank == "J")
            {
                return new LogicResult() { BestBetInPots = 1, CanRespondToAllIn = true };
            }

            if (card1.Rank.Equals(card2.Rank))
            {
                return new LogicResult() { BestBetInPots = 0.5, CanRespondToAllIn = false };
            }

            if (card1.Suit.Equals(card2.Suit))
            {
                return new LogicResult() { BestBetInPots = 0.25, CanRespondToAllIn = false };
            }

            if (card1.Rank == "A" || card1.Rank == "K" || card1.Rank == "Q" || card2.Rank == "A" || card2.Rank == "K" || card2.Rank == "Q")
            {
                return new LogicResult() { BestBetInPots = 0.25, CanRespondToAllIn = false };
            }

            if (card1.Suit.Equals(card2.Suit))
            {
                return new LogicResult() { BestBetInPots = 0.25, CanRespondToAllIn = false };
            }

            return new LogicResult() { BestBetInPots = 0, CanRespondToAllIn = false };
        }
    }
}