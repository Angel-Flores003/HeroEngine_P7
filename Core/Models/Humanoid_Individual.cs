using HeroEngine_P7.Tools;
using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models
{
    public abstract class Humanoid_Individual
    {
        public string? Name { get; set; }
        public int Level { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public bool IsAlive => CurrentHP > 0;
        public int InitiativeVal { get; set; }

        public Humanoid_Individual(string? name, int level, int maxhp)
        {
            Name = name;
            Level = level;
            MaxHP = maxhp;
            CurrentHP = MaxHP;
        }

        public Humanoid_Individual(string? name, int level)
        {
            Name = name;
            Level = level;
            MaxHP = 30 * Level;
            CurrentHP = MaxHP;
        }

        public virtual void Attack(Humanoid_Individual hum)
        {
            const int Attack = 10;
            int dmg = 0;

            if (CurrentHP > 0) dmg = Utils.CalculateAttack(Attack, Name);
            hum.TakeDamage(dmg);
        }

        public virtual void TakeDamage(int dmg)
        {
            CurrentHP -= dmg;

            if (CurrentHP <= 0) Console.WriteLine($"{Name} receives {dmg} damage and is already defeated");
            else Console.WriteLine($"{Name} receives {dmg} damage -> HP: {CurrentHP}/{MaxHP}");
        }

        public virtual void Initiative()
        {
            Random random = new Random();
            InitiativeVal = random.Next(1, 21);
        }
    }
}