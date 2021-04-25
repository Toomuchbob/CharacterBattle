using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CharacterBattle
{
    class Program
    {
        static NPC NPC;
        static List<string> Options = new List<string> { "Create a character", "Start new game", "Quit game" };

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
            Console.WriteLine("Welcome to Fantasy Battle!");
            Console.WriteLine("");

            var choice = SelectOption(Options);

            switch (choice)
            {
                case 0:
                    characters.Add(CreateNewCharacter());
                    break;
                case 1:
                    StartBattle(characters);
                    break;
                case 2:
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

            var playerCharacter = CharacterSelect(characters);

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

            // return selected option(int) from Select Option
            var choice = SelectOption(characters);

            return characters[choice];
        }

        private static void CreateNewNPC()
        {
            NPC npc = new NPC("Goblin");
            NPC = npc;
        }

        private static int SelectOption<T>(List<T> items)
        {
            //use Regex to verify what choice they made
            Regex option = new Regex($"[1-{items.Count}]");
            Match m;
            string playerChoiceString;

            do
            {

                // use pattern matching to identify List of Characters, else...
                foreach (var item in items)
                {
                    if (item is Character c)
                    {
                        Console.WriteLine($"{items.IndexOf(item) + 1}. {c.Name}");
                    }
                    else
                    {
                    Console.WriteLine($"{items.IndexOf(item) + 1}. {item}");
                    }
                    
                }

                Console.WriteLine("");

                var playerChoice = Console.ReadKey(true);

                playerChoiceString = playerChoice.KeyChar.ToString();
                m = option.Match(playerChoiceString);

                if (!m.Success)
                {
                    Console.WriteLine($"Please choose an option from 1-{items.Count}!");
                    Console.WriteLine("");
                };

            } while (!m.Success);

            // return option, less one, as collections are indexed starting at 0
            return int.Parse(playerChoiceString) - 1;
        }
    }
}
