using System;

namespace ChampionQuest.Entities
{
    public class Deck
    {
        public Card[] Cards { get; set; }
        public Card[] ShuffledCards { get; set; }
        public Card NextCardToDraw { get; set; }
        public int DeckSize { get; set; }

        Card testCard = new Card();

        public Deck(){}

        public Deck NewTestDeck()
        {
            Console.WriteLine("Setting up deck...");
            var testDeck = testCard.NewTestCardDeck();

            return new Deck
            {
                Cards = testDeck,
                ShuffledCards = testDeck,
                NextCardToDraw = testDeck[0],
                DeckSize = testDeck.Length
            };
        }
    }
}
