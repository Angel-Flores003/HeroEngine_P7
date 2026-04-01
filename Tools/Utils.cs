using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HeroEngine_P7.Tools
{
    public static class Utils
    {
        public static void CalculateAttack(int dmg, string? name)
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
        }
    }
}