using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CharacterBattle
{
    class Program
    {
        static NPC NPC;
        static Regex option = new Regex("[1-3]");
        static Match m;

        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();

            Menu(characters);

        }

        private static Character CreateNewCharacter()
        {
            Console.WriteLine("Please enter a name for your character: ");
            var name = Console.ReadLine();
            Console.WriteLine("");

            Character newCharacter = new Character(name);
            newCharacter.ReadStats();

            return newCharacter;
        }

        private static void Menu(List<Character> characters)
        {

            string playerChoiceString;

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
                    characters.Add(CreateNewCharacter());
                    break;
                case 2:
                    StartBattle(characters);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please choose between options 1-3!");
                    break;
            }

            Menu(characters);

        }

        private static void StartBattle(List<Character> characters)
        {
            if (characters.Count <= 0) characters.Add(CreateNewCharacter());

            var playerCharacter = characters[0];

            CreateNewNPC();

            do
            {
                playerCharacter.Attack(NPC);
                NPC.Attack(playerCharacter);
            } while (playerCharacter.HP > 0 && NPC.HP > 0);

            Console.WriteLine($"Battle over!");
            Console.WriteLine($"{playerCharacter.Name}'s HP: {playerCharacter.HP}");
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