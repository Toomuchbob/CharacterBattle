using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterBattle
{
    public interface ICharacter
    {
        public string Name { get; set; } // name of character
        public int HP { get; set; } // health points
        public int STR { get; set; } // strength
        public int T { get; set; } // toughness
        public int WS { get; set; } // weapon skill


        public int Attack(ICharacter character);

        public void ReadStats();
    }
}