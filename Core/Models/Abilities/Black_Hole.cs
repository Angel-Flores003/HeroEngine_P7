using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Black_Hole : IAbility
    {
        public string? NameHability => "Black Hole";
        public TypeAbility typeHability => TypeAbility.Attack;
        public TypeRarity typeRarity => TypeRarity.LEGENDARY;
        public int Cost => 95;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            for (int i = 0; i < targets.Count - 1; i++)
            {
                targets[i].CurrentHP -= 85;
            }
            Console.WriteLine($"{hum.Name} uses Black Hole ⚫");
        }
    }
}
