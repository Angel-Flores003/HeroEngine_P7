using HeroEngine_P7.Tools;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models
{
    public class Minion : Enemics
    {
        public Minion(string? name, int level, int maxhp) : base(name, level, maxhp) { }

        public Minion(string? name, int level) : base(name, level) { }

        public override void Attack(Humanoid_Individual hum)
        {
            const int Atack = 5;
            int dmg = 0;

            if (CurrentHP > 0) dmg = Utils.CalculateAttack(Atack, Name);
            hum.TakeDamage(dmg);
        }
    }
}