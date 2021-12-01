using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{

    public class Location
    {
        private Dictionary<string, Location> exits;
        private GameWorld world;
        private string _tag;
        public string tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }

        public Location() : this("No Tag")
        {

        }

        public Location(string tag)
        {
            exits = new Dictionary<string, Location>();
            this.tag = tag;
        }

        public void setExit(string exitName, Location location)
        {
            exits[exitName] = location;
        }

        public Location getExit(string exitName)
        {
            Location Location = null;
            exits.TryGetValue(exitName, out Location);
            return Location;
        }

        public string getExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Location>.KeyCollection keys = exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return exitNames;
        }

        public string displayItems()
        {
            world = new GameWorld();
            string itemNames = "Items in shop: ";
            Dictionary<List<Item>, Location>.KeyCollection keys = world.Items.Keys;
            foreach (List<Item> itemList in keys)
            {
                foreach (Item item in itemList)
                {
                    itemNames += " " + item.Name;
                }
            }
            return itemNames;
        }

        public string displayNPC()
        {
            world = new GameWorld();
            string npcName = "NPC found: ";
            Dictionary<NPC, Location>.KeyCollection keys = world.NPC.Keys;
            foreach (NPC npc in keys)
            {
                npcName += " " + npc.Name;
            }
            return npcName;
        }

        public string description()
        {
            return "You are " + this.tag + "\n *** " + displayItems() + "\n Enter V to display your bag"
            + "\n *** " + displayNPC() + "\n *** " + this.getExits();
        }


    }
}
