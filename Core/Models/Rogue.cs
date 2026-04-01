using System;
using System.Collections.Generic;
using HeroEngine_P7.Tools;

namespace HeroEngine_P7.Core.Models
{
    public class Rogue : Hero
    {
        public const int MULTIPLIER = 2;
        public int HiddenDaggers { get; set; }
        

        public Rogue(string? name, int level, int hp, int hiddendaggers): base(name, level, hp)
        {
            HiddenDaggers = hiddendaggers;
        }
        public int Furtive(int dmg)
        {
            return dmg * MULTIPLIER;
        }

        public override void Attack()
        {
            int Attack = 10;
            Random random = new Random();
            int furtive = random.Next(1, 6);

            if (furtive == 1 || furtive == 2) Attack = Furtive(Attack);
            Utils.CalculateAttack(Attack, Name);
        }
    }
}