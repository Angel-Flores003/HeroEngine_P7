using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Charged : IAbility
    {
        public string? NameHability => "Charged";
        public TypeAbility typeHability => TypeAbility.Attack;
        public TypeRarity typeRarity => TypeRarity.COMMON;
        public int Cost => 5;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            var target = targets[0];
            target.CurrentHP -= 10;
            Console.WriteLine($"{hum.Name} uses Charged");
        }
    }
}