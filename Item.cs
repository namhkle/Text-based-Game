using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{
    public class Item
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Volume { get; set; }

        public Item() : this("UnNamed")
        {

        }

        public Item(String itemName) : this(itemName, 1)
        {

        }
        public Item(String itemName, float itemWeight) : this(itemName, itemWeight, 1)
        {

        }

        public Item(string itemName, float itemWeight, float itemVolume)
        {
            this.Name = itemName;
            this.Weight = itemWeight;
            this.Volume = itemVolume;
        }
    }
}
