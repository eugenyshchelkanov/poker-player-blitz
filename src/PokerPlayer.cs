using System;
using System.Text;
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
		    try
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

                if (gameState.IsAllin())
                {
                    if (result.CanRespondToAllIn)
                        return int.MaxValue;
                    else
                        return 0;
                }

                if (result.RaiseOdds > 0)
                {
                    var raiseBase = Math.Max(gameState.Pot - gameState.Me().Bet, gameState.MinimumRaise);
                    return gameState.Me().Bet + (int)Math.Round(raiseBase * result.RaiseOdds);
                }
                if (result.CallOdds > 0)
                {
                    var toCall = gameState.CurrentBuyIn - gameState.Me().Bet;
                    var odds = toCall / (gameState.Pot + 1);
                    if (result.CallOdds > odds)
                        return toCall;
                }
                return 0;
		    }
		    catch (Exception e)
		    {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                var betBytes = Encoding.UTF8.GetBytes("0");
                var response = new Response
                {
                    ContentType = "text/plain",
                    Contents = s => s.Write(betBytes, 0, betBytes.Length),
                    StatusCode = HttpStatusCode.OK
                };

		        return 0;
		    }
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

