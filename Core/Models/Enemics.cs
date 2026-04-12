using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models
{
    public abstract class Enemics : Humanoid_Individual
    {
        public Enemics(string? name, int level, int maxhp) : base(name, level, maxhp) { }

        public Enemics(string? name, int level) : base(name, level) { }

        public override string ToString()
        {
            return $"[{GetType().Name}] {Name} | Level: {Level}" +
            $"\nHP: {CurrentHP}/{MaxHP}";
        }
    }
}