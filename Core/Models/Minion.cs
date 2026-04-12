using HeroEngine_P7.Tools;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models
{
    public class Minion : Enemics
    {
        public Minion(string? name, int level, int maxhp) : base(name, level, maxhp) { }

        public Minion(string? name, int level) : base(name, level) { }

        public override void Attack()
        {
            const int Atack = 5;
            if (CurrentHP > 0) Utils.CalculateAttack(Atack, Name);
        }
    }
}