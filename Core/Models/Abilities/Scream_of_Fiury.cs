using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Scream_of_Fiury : IAbility
    {
        public string? NameHability => "Scream of Fiury";
        public TypeAbility typeHability => TypeAbility.Suport;
        public TypeRarity typeRarity => TypeRarity.RARE;
        public int Cost => 26;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            var target = targets[0];
            Console.WriteLine($"{hum.Name} uses Scream of Fiury 😱");
            Console.WriteLine($"{target.Name} now have more precision");
        }
    }
}