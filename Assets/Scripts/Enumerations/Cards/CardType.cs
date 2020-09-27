using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionQuest.Enumerations
{
    public enum CardTypeEnum
    {
        // Unit card types
        Melee,
        Ranged,

        // Item card types
        Weapon,
        Armour,
        Consumable,

        // Magic card types
        Field,
        SingleUse,
        Equip
    }
}
