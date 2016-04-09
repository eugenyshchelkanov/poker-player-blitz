using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
	{
		public static readonly string VERSION = "Blitz speed withod bounds!";

		public static int BetRequest(GameState gameState)
		{
            return int.MaxValue;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}

        public static int isBet(GameState state)
        {
            var cards = state.GetMyCards();
            var card1 = cards[0];
            var card2 = cards[1];

            if (card1.Type == CardType.Ace && card2.Type == CardType.Ace)
            {
                return 10;
            }
            if (card1.Type == CardType.King && card2.Type == CardType.King)
            {
                return 8;
            }
            if (card1.Type == CardType.Queen && card2.Type == CardType.Queen)
            {
                return 6;
            }

            return 0;

        }
	}
}

