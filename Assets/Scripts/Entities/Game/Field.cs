using ChampionQuest.Enumerations;

namespace ChampionQuest.Entities
{
    public class Field
    {
        public FieldType FieldType { get; set; }

        public PlayedCard[] Player1MeleeCards { get; set; }
        public PlayedCard[] Player1RangedCards { get; set; }
        public PlayedCard[] Player1ItemCards { get; set; }
        public PlayedCard[] Player1MagicCards { get; set; }

        public PlayedCard[] Player2MeleeCards { get; set; }
        public PlayedCard[] Player2RangedCards { get; set; }
        public PlayedCard[] Player2ItemCards { get; set; }
        public PlayedCard[] Player2MagicCards { get; set; }

        public Card ActiveFieldCard { get; set; }

        public NetherPile OutOfPlayCards { get; set; }

        public Field()
        {

        }

        public Field NewTestField()
        {
            return new Field
            {
                FieldType = FieldType.None
            };
        }
    }
}
