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

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine($"Hero number {i + 1}");
            heroes.Add(Utils.AddHero());

            Console.Clear();
            
            Console.WriteLine(heroes[i].ToString());
            Utils.Continue();
        }

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

        Utils.Combat(heroes, enemics);
    }
}