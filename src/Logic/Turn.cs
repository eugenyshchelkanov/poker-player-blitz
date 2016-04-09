namespace Nancy.Simple.Logic
{
    public class Turn
    {
        public static double betInPots(GameState state)
        {
            var cards = state.GetMyCards();
            var card1 = cards[0];
            var card2 = cards[1];

            if (card1.Rank == "A" && card2.Rank == "A")
            {
                return 10;
            }
            if (card1.Rank == "K" && card2.Rank == "K")
            {
                return 8;
            }
            if (card1.Rank == "Q" && card2.Rank == "Q")
            {
                return 6;
            }

            if (card1.Rank.Equals(card2.Rank))
            {
                return 5;
            }

            return 0;
        }
    }
}