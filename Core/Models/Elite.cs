using System;
using System.Collections.Generic;

namespace HeroEngine_P7.Core.Models
{
    public class Elite : Enemics
    {
        public Elite(string? name, int level, int maxhp) : base(name, level, maxhp) { }

        public Elite(string? name, int level) : base(name, level) { }
    }
}