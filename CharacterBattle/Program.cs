using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CharacterBattle
{
    class Program
    {
        static NPC NPC;

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
                Console.WriteLine("");
                Console.WriteLine("Welcome to Fantasy Battle!");
                Console.WriteLine("");
                Console.WriteLine("1. Create a character");
                Console.WriteLine("2. Start new game");
                Console.WriteLine("3. Quit game");
                Console.WriteLine("");

            var choice = SelectOption();

            switch (choice)
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

            CharacterSelect(characters);

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

        private static Character CharacterSelect(List<Character> characters)
        {
            Console.WriteLine("Please select a character:");
            Console.WriteLine("");

            foreach (var character in characters)
            {
                Console.WriteLine($"{characters.IndexOf(character) + 1}. {character.Name}");
            }
            Console.WriteLine("");

            var choice = SelectOption();

            return characters[choice];
        }

        private static void CreateNewNPC()
        {
            NPC npc = new NPC("Goblin");
            NPC = npc;
        }

        private static int SelectOption()
        {
            Regex option = new Regex("[0-3]");
            Match m;

            var playerChoice = Console.ReadKey(true);

            string playerChoiceString = playerChoice.KeyChar.ToString();
            m = option.Match(playerChoiceString);

            do
            {
                Console.WriteLine("Please choose an available option!");
                Console.WriteLine("");

            } while (!m.Success);

            return int.Parse(playerChoiceString) - 1;
        }
    }
}