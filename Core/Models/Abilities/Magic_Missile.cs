using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Magic_Missile : IAbility
    {
        public string? NameHability => "Magic Missile";
        public TypeAbility typeHability => TypeAbility.Attack;
        public TypeRarity typeRarity => TypeRarity.COMMON;
        public int Cost => 12;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            for (int i = 0; i < targets.Count - 1; i++)
                targets[i].CurrentHP -= 5;
            Console.WriteLine($"{hum.Name} uses Magic Missile 🚀");
        }
    }
}