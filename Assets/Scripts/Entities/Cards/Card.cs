using ChampionQuest.Enumerations;
using System;

namespace ChampionQuest.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public int ResourceCost { get; set; }
        public string Description { get; set; }
        public CardState CardState { get; set; }
        public CardPassiveType CardPassive { get; set; }
        public CardTypeEnum CardType { get; set; }
        public CardClass CardClass { get; set; }
        public bool IsHidden { get; set; }
        public bool IsSelected { get; set; }
        public object HoverSound { get; set; }
        public object SelectSound { get; set; }
        public object ActionSound { get; set; }
        public object DestroySound { get; set; }

        public Card()
        {

        }

        public Card NewTestCard(int cardNumber)
        {
            return new Card
            {
                Id = cardNumber,
                Name = "Test",
                Strength = 1,
                Health = 1,
                ResourceCost = 1,
                Description = "This is a test card",
                CardState = CardState.InHand,
                CardPassive = CardPassiveType.None,
                CardType = CardTypeEnum.Melee,
                CardClass = CardClass.Neutral,
                IsHidden = false,
                IsSelected = false
            };
        }

        public Card[] NewTestCardDeck()
        {
            var cardDeck = new Card[30];
            for (int i = 0; i < 30; i++)
            {
                cardDeck[i] = NewTestCard(i);
                Console.WriteLine("Adding card to deck..." + i);
            }

            return cardDeck;
        }
    }
}
