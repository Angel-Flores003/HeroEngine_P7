using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public  class Shield_of_Faith : IAbility
    {
        public string? NameHability => "Shield of Faith";
        public TypeAbility typeHability => TypeAbility.Defense;
        public TypeRarity typeRarity => TypeRarity.EPIC;
        public int Cost => 57;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            for (int i = 0; i < targets.Count - 1; i++) 
                if (targets[i].CurrentHP > 0) targets[i].CurrentHP += 30;
            Console.WriteLine($"{hum.Name} uses Shield of Faith 🛡️");
        }
    }
}