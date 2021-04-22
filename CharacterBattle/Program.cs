using System;
using System.Text.RegularExpressions;

namespace CharacterBattle
{
    class Program
    {
        static Character PlayerCharacter;
        static NPC NPC;
        static Regex option = new Regex("[1-3]");
        static Match m;
        static string playerChoiceString;

        static void Main(string[] args)
        {
            Menu();
        }

        private static void CreateNewCharacter()
        {
            Console.WriteLine("Please enter a name for your character: ");
            var name = Console.ReadLine();
            Console.WriteLine("");

            Character newCharacter = new Character(name);
            newCharacter.ReadStats();

            PlayerCharacter = newCharacter;
        }

        private static void Menu()
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to Fantasy Battle!");
                Console.WriteLine("");
                Console.WriteLine("1. Create a character");
                Console.WriteLine("2. Start new game");
                Console.WriteLine("3. Quit game");
                Console.WriteLine("");

                var playerChoice = Console.ReadKey(true);

                playerChoiceString = playerChoice.KeyChar.ToString();
                m = option.Match(playerChoiceString);

                if (!m.Success)
                {
                    Console.WriteLine("Please choose between option 1-3!");
                    Console.WriteLine("");
                }

            } while (!m.Success);

            switch (int.Parse(playerChoiceString))
            {
                case 1:
                    CreateNewCharacter();
                    break;
                case 2:
                    StartBattle();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose between options 1-3!");
                    break;
            }

            Menu();
        }

        private static void StartBattle()
        {
            if (PlayerCharacter == null) CreateNewCharacter();

            CreateNewNPC();

            do
            {
                PlayerCharacter.Attack(NPC);
                NPC.Attack(PlayerCharacter);
            } while (PlayerCharacter.HP > 0 && NPC.HP > 0);

            Console.WriteLine($"Battle over!");
            Console.WriteLine($"{PlayerCharacter.Name}'s HP: {PlayerCharacter.HP}");
            Console.WriteLine($"{NPC.Name}'s HP: {NPC.HP}");
            Console.WriteLine("");
        }

        private static void CreateNewNPC()
        {
            NPC npc = new NPC("Goblin");
            NPC = npc;
        }
    }
}