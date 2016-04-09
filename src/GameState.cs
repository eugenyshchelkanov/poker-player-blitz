using System.Collections.Generic;

namespace Nancy.Simple
{
    public class GameState
    {
        public string TournamentId { get; set; }
        public string GameId { get; set; }
        public int Round { get; set; }
        public int BetIndex { get; set; }
        public int SmallBlind { get; set; }
        public int CurrentBuyIn { get; set; }
        public int Pot { get; set; }
        public int MinimumRaise { get; set; }
        public int Dealer { get; set; }
        public int Orbits { get; set; }
        public int InAction { get; set; }
        public List<Player> Players { get; set; }
        public List<CommunityCard> CommunityCards { get; set; } 
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
        public int Stack { get; set; }
        public int Bet { get; set; }
    }

    public class CommunityCard
    {
        public string Rank { get; set; }
        public Suit Suit { get; set; }
    }

    public enum Suit { Spades, Clubs, Hearts, Diamonds}
}
