using HeroEngine_P7.Tools;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models
{
    public class Boss_Bug_Primordial : Enemics
    {
        public Boss_Bug_Primordial(string? name, int level, int maxhp) : base(name, level, maxhp) { }

        public Boss_Bug_Primordial(string? name, int level) : base(name, level) { }

        public override void Attack()
        {
            const int attack  = 20;
            if (CurrentHP > 0) Utils.CalculateAttack(attack, Name);
        }
    }
}