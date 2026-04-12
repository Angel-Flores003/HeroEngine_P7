using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Arcane_Burst : IAbility
    {
        public string? NameHability => "Arcane Burst";
        public TypeAbility typeHability => TypeAbility.Attack;
        public TypeRarity typeRarity => TypeRarity.RARE;
        public int Cost => 40;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            var target = targets[0];
            target.CurrentHP -= 30;
            Console.WriteLine($"{hum.Name} uses Arcane Burst 👊");
        }
    }
}