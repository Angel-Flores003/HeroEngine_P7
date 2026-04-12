using System;
using System.Collections.Generic;
using HeroEngine_P7.Core.Interfaces;

namespace HeroEngine_P7.Core.Models
{
    public class Mage : Hero
    {
        public int Manna { get; set; }
        public int ArcaLvl { get; set; }
        public List<IAbility> Abilities { get; set; } = new List<IAbility>();

        public Mage(string? name, int level, int hp, List<IAbility> abilities, int manna, int arcalvl) :base (name, level, hp)
        {
            Manna = manna;
            ArcaLvl = arcalvl;
            Abilities = abilities;
        }

        public Mage(string? name, int level) : base(name, level)
        {
            Manna = 20 * Level;
            ArcaLvl = 1 + Level;
            Abilities = new List<IAbility>();
        }

        public override string ToString()
        {
            return $"[{GetType().Name}] {Name} | Level: {Level}" +
            $"\nHP: {CurrentHP}/{MaxHP} | Manna: {Manna} | Arca level: {ArcaLvl}";
        }

        public void ShowAbilities()
        {
            Console.WriteLine($"==================================================\n   {Name}'s Ability Loadout\n==================================================");
            for (int i = 0; i < Abilities.Count; i++)
            {
                Console.WriteLine($"[{Abilities[i].typeRarity}] {Abilities[i].NameHability} | Type: {Abilities[i].typeHability} | Cost: {Abilities[i].Cost}");
            }
            Console.WriteLine();
        }

        public void AddAbility(IAbility ability)
        {
            bool existe = Abilities.Any(a =>
                a.NameHability.Equals(ability.NameHability, StringComparison.OrdinalIgnoreCase));

            if (!existe)
            {
                Abilities.Add(ability);
            }

            /*if (!Abilities.Any(a => a.NameHability == ability.NameHability))
            {
                Abilities.Add(ability);
            }*/
        }

        public bool CanUse(IAbility ability)
        {
            return Manna >= ability.Cost;
        }

        public void UseAbility(IAbility ability, List<Humanoid_Individual> target)
        {
            if (!CanUse(ability))
            {
                Console.WriteLine("Not enough mana!");
                return;
            }

            Manna -= ability.Cost;
            ability.Use(this, target);
        }
    }
}