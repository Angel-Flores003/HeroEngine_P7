using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Models;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Interfaces
{
    public interface IAbility
    {
        string? NameHability { get; }
        public TypeAbility typeHability { get; }
        TypeRarity typeRarity { get; }
        int Cost { get; }

        void Use(Humanoid_Individual hum, List<Humanoid_Individual> targets);
    }
}