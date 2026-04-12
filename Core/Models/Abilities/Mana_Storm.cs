using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Mana_Storm : IAbility
    {
        public string? NameHability => "Mana Storm";
        public TypeAbility typeHability => TypeAbility.Attack;
        public TypeRarity typeRarity => TypeRarity.EPIC;
        public int Cost => 60;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            for (int i = 0; i < targets.Count - 1; i++)
                targets[i].CurrentHP -= 28;
            Console.WriteLine($"{hum.Name} uses Mana Storm 🌩️");
        }
    }
}