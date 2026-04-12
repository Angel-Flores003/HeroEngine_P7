using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Phoenix_Rebirth : IAbility
    {
        public string? NameHability => "Phoenix Rebirth";
        public TypeAbility typeHability => TypeAbility.Heal;
        public TypeRarity typeRarity => TypeRarity.LEGENDARY;
        public int Cost => 85;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            for (int i = 0; i < targets.Count - 1; i++)
            {
                if (targets[i].CurrentHP > 0) targets[i].CurrentHP += 50;
                if (targets[i].CurrentHP >= targets[i].MaxHP) targets[i].CurrentHP = targets[i].MaxHP;
            }
            Console.WriteLine($"{hum.Name} uses Phoenix Rebirth 🐦‍🔥");
        }
    }
}