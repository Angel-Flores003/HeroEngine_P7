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

        public override void Attack()
        {
            int attack = 10;
            Random random = new Random();
            int furtive = random.Next(1, 4);

            if (furtive == 1) attack = Furtive(attack);
            if (CurrentHP > 0) Utils.CalculateAttack(attack, Name);
        }

        public override int Initiative()
        {
            Random random = new Random();
            return random.Next(1, 21) + 10;
        }
    }
}