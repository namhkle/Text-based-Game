using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{
    public class NPC
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Volume { get; set; }

        public NPC() : this("UnNamed")
        {

        }
        public NPC(string charName)
        {
            this.Name = charName;
        }
    }
}
