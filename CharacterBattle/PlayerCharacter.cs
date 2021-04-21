using System;

namespace CharacterBattle
{
    class PlayerCharacter
    {
        private string Name;
        private int HP;
        private int STR;
        private int T;
        private int WS;

        public PlayerCharacter(string name)
        {
            Random r = new Random();

            Name = name;
            HP = r.Next(1, 10) + 20;
            STR = r.Next(1, 10) + 30;
            T = r.Next(1, 10) * 2 + 30;
            WS = r.Next(1, 10) * 2 + 40;
        }

        private int Attack(int wS)
        {
            Random r = new Random();

            int roll = r.Next(1, 100);

            int sR = (wS - roll) / 10;

            if (roll <= wS)
            {
                Console.WriteLine($"Attack success! with a success rating of {sR}");
                return sR;
            }
            Console.WriteLine("Attack failed!");
            return sR;
        }

        public void ReadStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"STR: {STR}");
            Console.WriteLine($"T: {T}");
            Console.WriteLine($"WS: {WS}");
        }

    }
}
