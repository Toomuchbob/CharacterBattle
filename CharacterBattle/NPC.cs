using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterBattle
{
    class NPC : Character
    {
        public NPC(string name) : base(name)
        {
            Random r = new Random();

            Name = name;
            HP = r.Next(1, 10) + 100; // Health
            STR = r.Next(1, 10) + 20; // Strength
            T = r.Next(1, 10) * 2 + 20; // Toughness
            WS = r.Next(1, 10) * 2 + 30; // Weapon Skill
        }
    }
}
