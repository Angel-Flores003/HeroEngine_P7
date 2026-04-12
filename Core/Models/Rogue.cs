using System;
using System.Collections.Generic;
using HeroEngine_P7.Tools;

namespace HeroEngine_P7.Core.Models
{
    public class Rogue : Hero
    {
        public const int MULTIPLIER = 3;
        public int HiddenDaggers { get; set; }

        public Rogue(string? name, int level, int hp, int hiddendaggers): base(name, level, hp)
        {
            HiddenDaggers = hiddendaggers;
        }

        public Rogue(string? name, int level) : base(name, level)
        {
            HiddenDaggers = 5;
        }

        public int Furtive(int dmg)
        {
            return dmg * MULTIPLIER;
        }

        public override void Attack(Humanoid_Individual hum)
        {
            int attack = 10;
            Random random = new Random();
            int furtive = random.Next(1, 4);
            int dmg = 0;

            if (furtive == 1) attack = Furtive(attack);
            if (CurrentHP > 0) dmg = Utils.CalculateAttack(attack, Name);
            hum.TakeDamage(dmg);
        }

        public override void Initiative()
        {
            Random random = new Random();
            InitiativeVal = random.Next(1, 21) + 10;
        }
    }
}