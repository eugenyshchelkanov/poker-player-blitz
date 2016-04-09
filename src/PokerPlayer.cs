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
		    LogicResult result = null;
		    if (gameState.CommunityCards.Count == 0)
                result = Preflop.Result(gameState);
            if (gameState.CommunityCards.Count == 3)
                result = Flop.Result(gameState);
            if (gameState.CommunityCards.Count == 4)
                result = Turn.Result(gameState);
            if (gameState.CommunityCards.Count == 5)
                result = River.Result(gameState);

		    if (result == null)
		    {
		        Console.WriteLine("RESULT IS NULL");
		        return 0;
		    }

            Console.WriteLine("State: " + JsonConvert.SerializeObject(gameState) + "; Bet: " + result.BestBetInPots * gameState.Pot);

            if (gameState.IsAllin() && result.CanRespondToAllIn)
                return int.MaxValue;

            if (gameState.Me().Stack < result.BestBetInPots * gameState.Pot)
		        return int.MaxValue;

		    if (gameState.CurrentBuyIn > result.BestBetInPots * gameState.Pot)
		        return 0;

		    var stavka = (int) (Math.Round(result.BestBetInPots)*gameState.Pot);

		    if (stavka < gameState.SmallBlind)
		        return gameState.SmallBlind;

            return stavka;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

