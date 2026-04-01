using System;
using System.Collections.Generic;
using HeroEngine_P7.Tools;

namespace HeroEngine_P7.Core.Models
{
    public class Wizard : Hero
    {
        public int Manna { get; set; }
        public int ArcaLvl { get; set; }

        public Wizard(string? name, int level, int hp, int manna, int arcalvl) :base (name, level, hp)
        {
            Manna = manna;
            ArcaLvl = arcalvl;
        }

        public override void ShowUp() => Console.WriteLine($"[{GetType().Name}] {Name} | Level: {Level}" +
            $"\nHP: {CurrentHP}/{MaxHP} | Manna: {Manna} | Arca level: {ArcaLvl}");

        public override void Attack()
        {
            int Attack = 10;
            Utils.CalculateAttack(Attack, Name);
        }
    }
}