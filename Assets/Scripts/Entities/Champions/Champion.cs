using ChampionQuest.Enumerations;
using System;

namespace ChampionQuest.Entities
{
    public class Champion
    {
        public ChampionClass ChampionClass { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceValue { get; set; }
        public int MeleeSlots { get; set; }
        public int RangedSlots { get; set; }
        public int SpellSlots { get; set; }
        public int ItemSlots { get; set; }
        public ChampionPortrait Portrait { get; set; }

        public Champion()
        {

        }

        public Champion NewTestChampion()
        {
            Console.WriteLine("Setting up champion...");

            return new Champion
            {
                ChampionClass = ChampionClass.Knight,
                ResourceType =  ResourceType.Honour,
                ResourceValue = 1,
                MeleeSlots = 4,
                RangedSlots = 4,
                SpellSlots = 3,
                ItemSlots = 3,
                Portrait = ChampionPortrait.One
            };
        }
    }
}
