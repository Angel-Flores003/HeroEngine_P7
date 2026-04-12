using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Minor_Barrier : IAbility
    {
        public string? NameHability => "Minor Barrier";
        public TypeAbility typeHability => TypeAbility.Defense;
        public TypeRarity typeRarity => TypeRarity.COMMON;
        public int Cost => 18;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            var target = targets[0];
            target.CurrentHP += 10;
            Console.WriteLine($"{hum.Name} uses Minor Barrier 🛡️");
        }
    }
}