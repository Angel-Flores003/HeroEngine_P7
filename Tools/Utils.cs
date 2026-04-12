using HeroEngine_P7.Core.Enums;
using HeroEngine_P7.Core.Interfaces;
using HeroEngine_P7.Core.Models;
using HeroEngine_P7.Core.Models.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroEngine_P7.Tools
{
    public static class Utils
    {
        public static Dictionary<int, Func<string, int, int, Hero>> heroFactories =
            new Dictionary<int, Func<string, int, int, Hero>>()
            {
                { 1, (name, lvl, hp) => AddWarrior(name, lvl, hp) },
                { 2, (name, lvl, hp) => AddMage(name, lvl, hp) },
                { 3, (name, lvl, hp) => AddRogue(name, lvl, hp) }
            };
        public static Hero AddHero()
        {
            Console.WriteLine("Select a type of hero:\n" +
                "1. Warrior\n" +
                "2. Mage\n" +
                "3. Rogue");
            int op = ValidateOption(1, 3);

            Console.Clear();

            Console.Write("Enter the name: ");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Enter level: ");
            int lvl = ValidateInt();

            Console.Write("Enter hp: ");
            int hp = ValidateInt();

            return heroFactories[op](name, lvl, hp);
        }

        public static int ValidateInt()
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num) && num > 0)
            {
                Console.WriteLine("Invalid input, Please enter a natural number");
            }
            return num;
        }

        public static int ValidateOption(int min, int max)
        {
            int option;

            while (!int.TryParse(Console.ReadLine(), out option) || (option < min || option > max))
            {
                Console.Write("Invalid option. Enter a valid number: ");
            }

            return option;
        }

        public static Warrior AddWarrior(string name, int lvl, int hp)
        {
            Console.Write("Enter armor: ");
            int armor = ValidateInt();

            Console.Write("War cry: ");
            string? warcry = Console.ReadLine();

            return new Warrior(name, lvl, hp, armor, warcry);
        }

        public static Mage AddMage(string name, int lvl, int hp)
        {
            Console.Write("Enter mana: ");
            int mana = ValidateInt();

            Console.Write("Arcane level: ");
            int arcLvl = ValidateInt();

            return new Mage(name, lvl, hp, [], mana, arcLvl);
        }

        public static Rogue AddRogue(string name, int lvl, int hp)
        {
            Console.Write("Hidden daggers: ");
            int daggers = ValidateInt();

            return new Rogue(name, lvl, hp, daggers);
        }

        public static int CalculateAttack(int dmg, string? name)
        {
            Random random = new Random();
            int crit = random.Next(1, 21);

            if (crit == 1)
            {
                dmg = dmg / 2;
                Console.WriteLine($"{name} deals {dmg} damage. (Blunder hit!)");
            }
            if (crit == 20)
            {
                dmg = dmg * 2;
                Console.WriteLine($"{name} deals {dmg} damage. (Critical hit!)");
            }
            else Console.WriteLine($"{name} deals {dmg} damage.");
            return dmg;
        }

        public static void AddSkill(Mage mage)
        {
            List<IAbility> skills = new List<IAbility>();
            skills.Add(new Explosion());//76 - 100
            skills.Add(new Black_Hole());
            skills.Add(new Phoenix_Rebirth());
            skills.Add(new Shield_of_Faith());//51 - 75
            skills.Add(new Mana_Storm());
            skills.Add(new Temporal_Shift());
            skills.Add(new Scream_of_Fiury());//26 - 50
            skills.Add(new Pulse_cure());
            skills.Add(new Arcane_Burst());
            skills.Add(new Charged());//1 -25
            skills.Add(new Magic_Missile());
            skills.Add(new Minor_Barrier());

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Select 4 skills four {mage.Name}\n");

                for (int j = 0; j < skills.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. [{skills[j].typeRarity}] {skills[j].NameHability} | Type: {skills[j].typeHability} | Cost: {skills[j].Cost}");
                }
                Console.WriteLine();


                int skill = ValidateOption(1, skills.Capacity);
                IAbility selected = skills[skill - 1];

                mage.AddAbility(selected);
                skills.Remove(selected);
                Console.Clear();
            }
        }

        public static void Continue()
        {
            Console.WriteLine("\n(Press any key to continue)");
            Console.ReadKey();
            Console.Clear();
        }

        public static List<Enemics> LoadEnemics(List<Enemics> enemics)
        {
            for (int i = 0; i < 4; i++)
            {
                enemics.Add(new Minion($"Minion{i + 1}", 1, 10));
            }

            for (int i = 0; i < 2; i++)
            {
                enemics.Add(new Elite($"Elite{i}", 5, 50));
            }

            enemics.Add(new Boss_Bug_Primordial($"OutOfRangeException", 10, 100));

            return enemics;
        }

        public static void Combat(List<Hero> heroes, List<Enemics> enemies)
        {
            Random random = new Random();

            List<Humanoid_Individual> turnOrder = new List<Humanoid_Individual>();

            foreach (var h in heroes)
                if (h.IsAlive) h.Initiative();

            foreach (var e in enemies)
                if (e.IsAlive) e.Initiative();

            turnOrder.AddRange(heroes.Where(h => h.IsAlive));
            turnOrder.AddRange(enemies.Where(e => e.IsAlive));

            turnOrder = turnOrder
              .OrderByDescending(c => c.InitiativeVal)
              .ToList();

            while (heroes.Any(h => h.IsAlive) && enemies.Any(e => e.IsAlive))
            {
                foreach (var character in turnOrder)
                {
                    
                    if (character is Hero hero && character.IsAlive)
                    {
                        var aliveEnemies = enemies.Where(e => e.IsAlive).ToList();

                        if (aliveEnemies.Count == 0)
                            break;

                        if (hero is Mage mage)
                        {
                            Console.WriteLine($"What {mage.Name} want to do?\n" +
                                $"1. Attack\n" +
                                $"2. Use skill\n");

                            int use = ValidateOption(1, 2);

                            switch (use)
                            {
                                case 2:
                                    mage.ShowAbilities();

                                    int skill = ValidateOption(1, mage.Abilities.Count);
                                    
                                    if (mage.Abilities[skill - 1].typeHability == TypeAbility.Attack)
                                    {
                                        ShowEnemies(aliveEnemies, hero);
                                        int enemyIndex = ValidateOption(1, aliveEnemies.Count);

                                        mage.UseAbility(mage.Abilities[skill - 1],
                                        new List<Humanoid_Individual>(aliveEnemies));
                                    }
                                    else
                                    {
                                        var aliveHeroes = heroes.Where(h => h.IsAlive).ToList();
                                        for (int i = 0; i < aliveHeroes.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1} - {aliveHeroes[i].Name}");
                                        }

                                        mage.UseAbility(mage.Abilities[skill - 1],
                                            new List<Humanoid_Individual>(aliveHeroes));
                                    }
                                    break;
                                default:
                                    Attack(aliveEnemies, hero);
                                    break;
                            }
                        }
                        else Attack(aliveEnemies, hero);
                    }
                    if (character is Enemics enemy && character.IsAlive)
                    {
                        var aliveHeroes = heroes.Where(h => h.IsAlive).ToList();

                        if (aliveHeroes.Count == 0)
                            break;

                        int select = random.Next(1, aliveHeroes.Count);

                        enemy.Attack(heroes[select]);
                    }
                }
            }
            Console.WriteLine(heroes.Any(h => h.IsAlive)? "Heroes win!" : "Enemies win!");
        }

        private static void Attack(List<Enemics> enemies, Hero hero)
        {
            ShowEnemies(enemies, hero);
            int op = ValidateOption(1, enemies.Count);
            hero.Attack(enemies[op - 1]);
        }

        private static void ShowEnemies(List<Enemics> enemies, Hero hero)
        {
            Console.WriteLine($"Which enemy does {hero.Name} want to attack?\n");
            for (int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {enemies[i].Name}");
            }
        }
    }
}