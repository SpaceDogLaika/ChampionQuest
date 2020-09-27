using System;

namespace ChampionQuest.Entities
{
    public class Match
    {
        public Guid Id { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public DateTime ElapsedTime { get; set; }
        public Field PlayingField { get; set; }
        public int CurrentTurn { get; set; }
        public bool IsPlayerVsPlayerMatch { get; set; }

        Player testPlayer = new Player();
        Field testField = new Field();

        public Match()
        {
        }

        //Initialise the match between player and opponent
        public Match NewMatch(
            Guid id,
            Player player1,
            Player player2,
            Field playingField,
            int currentTurn,
            bool isPvp)
        {
            return new Match
            {
                Id = id,
                Player1 = player1,
                Player2 = player2,
                PlayingField = playingField,
                CurrentTurn = currentTurn,
                IsPlayerVsPlayerMatch = isPvp
            };
        }

        public Match NewTestMatch()
        {
            Console.WriteLine("Setting up match...");
            return new Match
            {
                Id = Guid.NewGuid(),
                Player1 = testPlayer.NewTestPlayer(),
                Player2 = testPlayer.NewTestPlayer(),
                PlayingField = testField.NewTestField(),
                CurrentTurn = 1,
                IsPlayerVsPlayerMatch = false
            };
        }

        //Increment the turns for both players
        public void IncrementTurn()
        {
            CurrentTurn++;
        }
    }
}
