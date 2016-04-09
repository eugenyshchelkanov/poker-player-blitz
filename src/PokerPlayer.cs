using System;
using Nancy.Simple.Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
	{
		public static readonly string VERSION = "Blitz speed withod bounds!";

		public static int BetRequest(GameState gameState)
		{
		    double bestBet = 0;
		    if (gameState.CommunityCards.Count == 0)
		        bestBet = Preflop.Result(gameState).BestBetInPots * gameState.Pot;
            if (gameState.CommunityCards.Count == 3)
                bestBet = Flop.Result(gameState).BestBetInPots * gameState.Pot;
            if (gameState.CommunityCards.Count == 4)
                bestBet = Turn.Result(gameState).BestBetInPots * gameState.Pot;
            if (gameState.CommunityCards.Count == 5)
                bestBet = River.Result(gameState).BestBetInPots * gameState.Pot;

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
	}
}

