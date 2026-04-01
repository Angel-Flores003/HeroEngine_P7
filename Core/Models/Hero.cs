using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace HeroEngine_P7.Core.Models
{
    public abstract class Hero
    {
        protected string? Name { get; set; }
        protected int Level { get; set; }
        protected int MaxHP { get; set; }
        protected int CurrentHP { get; set; }

        public Hero(string? name, int level, int maxhp)
        {
            Name = name;
            Level = level;
            MaxHP = maxhp;
            CurrentHP = MaxHP;
        }

        public virtual void ShowUp() => Console.WriteLine($"[{GetType().Name}] {Name} | Level: {Level}" +
            $"\nHP: {CurrentHP}/{MaxHP}");

        public abstract void Attack();

        public virtual void TakeDamage(int dmg)
        {
            CurrentHP -= dmg;
            Console.WriteLine($"{Name} receives {dmg} damage -> HP: {CurrentHP}/{MaxHP}");
        }
    }
}