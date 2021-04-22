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

        public int Attack(Character character)
        {
            Random r = new Random();

            int roll = r.Next(1, 100);

            int sR = (this.WS - roll) / 10;

            if (roll <= this.WS)
            {
                Console.WriteLine($"{Name}'s attack succeeded! with a success rating of {sR}.");
                Console.WriteLine($"{Name} dealt {STR + sR} damage!");
                character.HP -= this.STR + sR;
                return sR;
            }
            Console.WriteLine($"{Name}'s Attack failed!");
            return sR;
        }
    }
}
