using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using HeroEngine_P7.Core.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace HeroEngine_P7.Core.Models
{
    public class Ability : IComparable<Ability>
    {
        public string? NameHability { get; init; }
        public TypeAbility typeHability { get; init; }
        public TypeRarity typeRarity { get; init; }
        public int Cost { get; init; }

        public Ability(string? namehability, TypeAbility typehability, TypeRarity typerarity, int cost)
        {
            NameHability = namehability;
            typeHability = typehability;
            typeRarity = typerarity;
            Cost = cost;
        }

        public Ability(string? namehability, TypeAbility typehability, TypeRarity typerarity)
        {
            NameHability = namehability;
            typeHability = typehability;
            typeRarity = typerarity;
            switch (typeRarity)
            {
                case TypeRarity.COMMON:
                    Cost = 15;
                    break;
                case TypeRarity.RARE:
                    Cost = 30;
                    break;
                case TypeRarity.EPIC:
                    Cost = 65;
                    break;
                case TypeRarity.LEGENDARY:
                    Cost = 100;
                    break;
            }
        }

        public int CompareTo(Ability? other)
        {
            if (other == null) return 1;

            return typeRarity.CompareTo(other.typeRarity);
        }
    }
}