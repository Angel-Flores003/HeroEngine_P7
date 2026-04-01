using System;
using HeroEngine_P7.Core.Models;


public class Program
{
    public static void Main()
    {
        List<Hero> heroes = new List<Hero>();
        heroes.Add(new Warrior("Bakugo", 1, 130, 15, "Shineee"));
        heroes.Add(new Wizard("Megumin", 3, 90, 40, 5));
        heroes.Add(new Rogue("Putput", 5, 43, 4));

        foreach (var hero in heroes)
        {
            hero.ShowUp();
            hero.Attack();
            hero.TakeDamage(22);
            Console.WriteLine();
        }
    }
}