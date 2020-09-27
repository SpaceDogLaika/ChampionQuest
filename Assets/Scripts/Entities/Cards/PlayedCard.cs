using ChampionQuest.Enumerations;

namespace ChampionQuest.Entities
{
    public class PlayedCard : Card
    {
        public int CurrentHealth { get; set; }
        public int CurrentStrength { get; set; }
        public bool IsDebuffed { get; set; }
        public DebuffType[] Debuffs { get; set; }
    }
}
