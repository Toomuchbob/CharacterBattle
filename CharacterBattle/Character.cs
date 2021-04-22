using System;

namespace CharacterBattle
{
    class Character : ICharacter
    {

        public Character(string name)
        {
            Random r = new Random();

            Name = name;
            HP = r.Next(1, 10) + 100;
            STR = r.Next(1, 10) + 30;
            T = r.Next(1, 10) * 2 + 30;
            WS = r.Next(1, 10) * 2 + 40;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int STR { get; set; }
        public int T { get; set; }
        public int WS { get; set; }

        public int Attack(ICharacter character)
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

        public void ReadStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"HP: {HP}");
            Console.WriteLine($"STR: {STR}");
            Console.WriteLine($"T: {T}");
            Console.WriteLine($"WS: {WS}");
            Console.WriteLine("");
        }
    }
}
