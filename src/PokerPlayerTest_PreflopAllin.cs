using System.Collections.Generic;
using NUnit.Framework;

namespace Nancy.Simple
{
    public class PokerPlayerTest_PreflopAllin
    {
        private GameState PreflopAllin(string rank1, Suit suit1, string rank2, Suit suit2)
        {
            return new GameState
            {
                CommunityCards = new List<Card>(),
                Pot = 1000,
                SmallBlind = 10,
                InAction = 0,
                CurrentBuyIn = 1000,
                Players = new List<Player> { new Player { Id = 0, Stack = 1000,
                    WholeCards = new List<Card> { new Card { Rank = rank1, Suit = suit1 }, new Card { Rank = rank2, Suit = suit2 } } }, new Player() },
            };
        }

        [Test]
        public void PairOfAces()
        {
            var state = PreflopAllin("A", Suit.Diamonds, "A", Suit.Clubs);
            Assert.That(PokerPlayer.BetRequest(state), Is.EqualTo(1000));
        }

        [Test]
        public void WorstCardsEvah()
        {
            var state = PreflopAllin("2", Suit.Diamonds, "6", Suit.Clubs);
            Assert.That(PokerPlayer.BetRequest(state), Is.EqualTo(0));
        }
    }
}