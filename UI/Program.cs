using System;
using HeroEngine_P7.Core.Models;
using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Tools;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Create your team for battle");
        Thread.Sleep(1000);
        Console.Clear();

        List<Hero> heroes = new List<Hero>();
        heroes.Add(new Warrior("Bakugo", 1, 130, 15, "Shineee"));
        heroes.Add(new Mage("Megumin", 3, 90, [], 1000, 5));
        heroes.Add(new Rogue("Putput", 5, 43, 4));
        heroes.Add(new Warrior("Noun", 2));
        heroes.Add(new Mage("Sasha", 3));
        heroes.Add(new Rogue("Nezuko", 5));

        /*for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Hero number {i + 1}");
            heroes.Add(Utils.AddHero());

            Console.Clear();
            
            Console.WriteLine(heroes[i].ToString());
            Utils.Continue();
        }*/

        foreach (var hero in heroes)
        {
            if (hero is Mage mage)
            {
                Utils.AddSkill(mage);
                mage.Abilities.Sort((a, b) => b.typeRarity.CompareTo(a.typeRarity));
                mage.ShowAbilities();
                Utils.Continue();
            }
        }

        List<Enemics> enemics = new List<Enemics>();
        enemics = Utils.LoadEnemics(enemics);

        foreach (var hero in heroes)
        {
            if (hero is Mage mage)
            {
                mage.UseAbility(mage.Abilities[1], enemics.Cast<Humanoid_Individual>().ToList());
            }
        }







        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.ToString());
            hero.Attack();
            hero.TakeDamage(50);
            Console.WriteLine();
        }

        /*foreach (var hero in heroes)
        {
            if (hero is Mage mage)
            {
                mage.AddAbility(new Ability("Charged", TypeAbility.Attack, TypeRarity.COMMON, 5));
                mage.AddAbility(new Ability("Explosion", TypeAbility.Attack, TypeRarity.LEGENDARY, 100));
                mage.AddAbility(new Ability("Shield of Faith", TypeAbility.Defense, TypeRarity.EPIC, 30));
                mage.AddAbility(new Ability("Scream of Fiury", TypeAbility.Suport, TypeRarity.RARE, 20));
                //mage.Abilities.Sort((a, b) => b.CompareTo(a));//LEG -> EPIC
                mage.ShowAbilities();
            }
        }*/
    }
}