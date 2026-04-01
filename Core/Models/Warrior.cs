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

        public override void ShowUp() => Console.WriteLine($"[{GetType().Name}] {Name} | Level: {Level}" +
            $"\nHP: {CurrentHP}/{MaxHP} | Armor: {Armor}" +
            $"\nBattle Cry: {WarCry}");
        
        public override void Attack() 
        {
            int Attack = 20;
            Utils.CalculateAttack(Attack, Name);
        }

        public override void TakeDamage(int dmg)
        {
            int recivedmg = dmg - Armor;
            CurrentHP -= recivedmg;

            Console.WriteLine($"{Name} receives {dmg} damage -> absorbed {Armor} by armor -> net damage: {recivedmg}" +
                $"\nHP: {CurrentHP}/{MaxHP}");
        }
    }
}