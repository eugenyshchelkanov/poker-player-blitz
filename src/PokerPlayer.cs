using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
	{
		public static readonly string VERSION = "Blitz speed withod bounds!";

		public static int BetRequest(JObject gameState)
		{
		    GameState state = gameState.ToObject<GameState>();

            return int.MaxValue;
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

