using System;

namespace ChampionQuest.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public Deck Deck { get; set; }
        public Hand Hand { get; set; }
        public int TurnTimer { get; set; }
        public Champion CurrentChampion { get; set; }
        public bool IsCurrentTurn { get; set; }
        public bool HasFirstTurn { get; set; }

        Deck testDeck = new Deck();
        Champion testChampion = new Champion();

        public Player(){}

        public Player NewPlayer(
            Guid id,
            string name,
            int health,
            Deck deck,
            Hand hand,
            int turnTimer,
            Champion currentChampion,
            bool isCurrentTurn,
            bool hasFirstTurn)
        {
            return new Player
            {
                Id = id,
                Name = name,
                Health = health,
                Deck = deck,
                Hand = hand,
                TurnTimer = turnTimer,
                CurrentChampion = currentChampion,
                IsCurrentTurn = isCurrentTurn,
                HasFirstTurn = hasFirstTurn
            };
        }

        public Player NewTestPlayer()
        {
            Console.WriteLine("Setting up player...");
            var playerId = Guid.NewGuid();

            return new Player
            {
                Id = playerId,
                Name = "Test_Player_" + playerId,
                Health = 100,
                Deck = testDeck.NewTestDeck(),
                Hand = null,
                TurnTimer = 90,
                CurrentChampion = testChampion.NewTestChampion(),
                IsCurrentTurn = false,
                HasFirstTurn = false
            };
        }

        public int ModifyHealth(int healthModifier)
        {
            return Health += healthModifier;
        }
    }
}
