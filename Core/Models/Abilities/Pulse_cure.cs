using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Pulse_cure : IAbility
    {
        public string? NameHability => "Pulse Cure";
        public TypeAbility typeHability => TypeAbility.Heal;
        public TypeRarity typeRarity => TypeRarity.RARE;
        public int Cost => 30;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            var target = targets[0];
            target.CurrentHP += 30;
            if (target.CurrentHP >= target.MaxHP) target.CurrentHP = target.MaxHP;
            Console.WriteLine($"{hum.Name} uses Pulse Cure ➕");
        }
    }
}