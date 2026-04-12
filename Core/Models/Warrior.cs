using System;
using System.Collections.Generic;
using HeroEngine_P7.Tools;

namespace HeroEngine_P7.Core.Models
{
    public class Warrior : Hero
    {
        public int Armor { get; set; }
        public string? WarCry { get; set; }

        public Warrior(string? name, int level, int maxhp, int armor, string? warcry) : base(name, level, maxhp)
        {
            Armor = armor;
            WarCry = warcry;
        }

        public Warrior(string? name, int level) : base(name, level)
        {
            MaxHP = 50 * Level;
            CurrentHP = MaxHP;
            Armor = 15 * Level;
            WarCry = "My code compiles on the first try!";
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] {Name} | Level: {Level}" +
            $"\nHP: {CurrentHP}/{MaxHP} | Armor: {Armor}" +
            $"\nBattle Cry: {WarCry}";
        }

        public override void Attack(Humanoid_Individual hum) 
        {
            const int Attack = 15;
            int dmg = 0;

            if (CurrentHP > 0) dmg = Utils.CalculateAttack(Attack, Name);
            hum.TakeDamage(dmg);
        }

        public override void TakeDamage(int dmg)
        {
            int recivedmg = dmg - Armor;
            if (recivedmg < 0) recivedmg = 0;
            CurrentHP -= recivedmg;

            if (CurrentHP < 0) Console.WriteLine($"{Name} is already defeated");
            else Console.WriteLine($"{Name} receives {dmg} damage -> absorbed {Armor} by armor -> net damage: {recivedmg}" +
                $"\nHP: {CurrentHP}/{MaxHP}");
        }

        public override void Initiative()
        {
            Random random = new Random();
            InitiativeVal = random.Next(1, 21) - 5;
        }
    }
}