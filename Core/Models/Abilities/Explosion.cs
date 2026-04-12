using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace HeroEngine_P7.Core.Models.Abilities
{
    public class Explosion : IAbility
    {
        public string? NameHability => "Explosion";
        public TypeAbility typeHability => TypeAbility.Attack;
        public TypeRarity typeRarity => TypeRarity.LEGENDARY;
        public int Cost => 100;

        public void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets)
        {
            for (int i = 0; i < targets.Count - 1; i++)
            {
                targets[i].CurrentHP -= 100;
            }
            Console.WriteLine($"{hum.Name} uses Explosion 💥");
        }
    }
}