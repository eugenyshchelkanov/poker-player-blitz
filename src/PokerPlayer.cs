using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
	{
		public static readonly string VERSION = "Blitz speed withod bounds!";

		public static int BetRequest(GameState gameState)
		{
		    var bestBet = isBet(gameState) * gameState.Pot;

		    if (gameState.Me().Stack < bestBet)
		        return int.MaxValue;

		    if (gameState.CurrentBuyIn > bestBet)
		        return 0;

		    Console.WriteLine("State: " + JsonConvert.SerializeObject(gameState) + "; Bet: " + bestBet);
		    return (int)bestBet;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}

        public static double isBet(GameState state)
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

