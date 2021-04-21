using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterBattle
{
    class NPC
    {
        private string Name;
        public int HP;
        private int STR;
        private int T;
        private int WS;
        private int Behavior;

        public NPC(string name)
        {
            Random r = new Random();

            Name = name;
            HP = r.Next(1, 10) + 100; // Health
            STR = r.Next(1, 10) + 20; // Strength
            T = r.Next(1, 10) * 2 + 20; // Toughness
            WS = r.Next(1, 10) * 2 + 30; // Weapon Skill
            Behavior = r.Next(1, 10) * 2 + 60; // How often the NPC will block
        }

        private int Attack(int wS)
        {
            Random r = new Random();

            int roll = r.Next(1, 100);

            int sR = (wS - roll) / 10;

            if (roll <= wS)
            {
                Console.WriteLine($"{Name}'s attack succeeded! with a success rating of {sR}");
                return sR;
            }
            Console.WriteLine($"{Name}'s Attack failed!");
            return sR;
        }
    }
}
