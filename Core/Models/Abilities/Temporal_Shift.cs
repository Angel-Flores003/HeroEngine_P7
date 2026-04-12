using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Temporal_Shift : IAbility
    {
        public string? NameHability => "Temporal Shift";
        public TypeAbility typeHability => TypeAbility.Suport;
        public TypeRarity typeRarity => TypeRarity.EPIC;
        public int Cost => 70;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            var target = targets[0];
            target.CurrentHP -= 30;
            Console.WriteLine($"{hum.Name} uses Mana Storm 🌩️");
        }
    }
}