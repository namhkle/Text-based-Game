using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{
    public class Player
    {
        private Location _currentLocation = null;
        List<Location> trackedLocations;
        private List<Item> inventory;

        public Location currentLocation
        {
            get
            {
                return _currentLocation;
            }
            set
            {
                _currentLocation = value;
            }
        }

        private Location _savedLocation = null;
        public Location previousLocation
        {
            get
            {
                return previousLocation;
            }
            set
            {
                previousLocation = value;
            }
        }

        public Player(Location location)//, GameOutput output)
        {
            _currentLocation = location;
            inventory = new List<Item>();

            trackedLocations = new List<Location>();
            trackedLocations.Add(_currentLocation);
        }

        public void goTo(string direction)
        {
            Location location = this._currentLocation.getExit(direction);
            if (location != null)
            {
                this._savedLocation = this._currentLocation;
                this._currentLocation = location;
                // Player posts a notification PlayerEnteredRoom
                NotificationCenter.Instance.postNotification(new Notification("PlayerEnteredRoom", this));
                this.outputMessage("\n" + this._currentLocation.description());

                // save location for location backing
                trackedLocations.Add(_currentLocation);
            }
            else
            {
                this.outputMessage("\nThere is no door on " + direction);
            }
        }

        private int num = 0;
        public void backTo()
        {
            if (trackedLocations.IndexOf(_currentLocation) - num > 0 && previousLocation != null)
            {
                Location previousLocation = trackedLocations[trackedLocations.IndexOf(_currentLocation) - num];
                num++;

                // Player posts a notification PlayerEnteredRoom
                NotificationCenter.Instance.postNotification(new Notification("PlayerEnteredRoom", this));
                this.outputMessage("\n" + previousLocation.description());
                trackedLocations.RemoveAt(num);
            }

            else
            {
                this.outputMessage("\nYou hasn't gone anywhere, you can't go back");
            }
        }

        public void teleportHome()
        {
            NotificationCenter.Instance.postNotification(new Notification("PlayerEnteredRoom", this));
            this.outputMessage("\n" + this.trackedLocations[0].description());
        }
        /*
        public void pickUp(string itemName)
        {
            Item item = this._currentLocation.pickUp(itemName);
            this.outputMessage("\n" + itemName + " has been obtained" + this._currentLocation.description2());
            if (item != null)
            {
                give(item);
            }
            else
            {
                outputMessage("The Item" + itemName + "does not exist in this location");
            }
        }

        public void drop(string itemName)
        {
            Item item = this._currentLocation.take(itemName);
            if (item != null)
            {   
                give(item);
            }
            else
            {
                outputMessage("The Item" + itemName + "does not exist in this location");
            }

            public Item take(string itemName)
        {
            Item item = null;
            inventory.TryGetValue(itemName, out item);
            inventory.Remove(itemName);
            return item;
        }
        }*/

        float bagMaxWeight = 20;
        float bagMaxVolume = 50;
        float totalWeight = 0;
        float totalVolume = 0;
        public void obtain(String itemName)
        {
            GameWorld world = new GameWorld();
            
            Dictionary<List<Item>, Location>.KeyCollection keys = world.Items.Keys;
            foreach (List<Item> itemList in keys)
            {
                foreach (Item item in itemList)
                {
                    if (item.Name.Equals(itemName))
                    {
                        inventory.Add(item);
                        //itemList.Remove(item);

                        // increases weight and volume of in the bag.
                        totalWeight += item.Weight;
                        totalVolume += item.Volume;

                        outputMessage("You have obtained " + itemName + ". \n *** Weight Capacity -" + item.Weight + "\n *** Volume Capacity -" + item.Volume +
                            "\n *** Bag Capacity: " + totalWeight + '/' + bagMaxWeight + "(wgt)" + "\n                   " + totalVolume + '/' + bagMaxVolume + 
                            "(vol)" + "\n Enter V to display your bag.");
                        
                        if(totalWeight > bagMaxWeight)
                        {
                            outputMessage("Your bag has reached maximum weight capacity.");
                        }
                        if (totalVolume > bagMaxVolume)
                            outputMessage("Your bag has reach maximum volume capacity.");
                    }
                    /*else
                    {
                        outputMessage("This item does not exist here.");
                    }*/
                }
            }
        }

        public void equip(string itemName)
        {

        }

        public void give(Item item)
        {

        }

        public void discard(string itemName)
        {

        }

        public void displayBag()
        {
            string bag = "Your bag: ";

            if (inventory != null)
            {
                foreach (Item item in inventory)
                {
                    bag += " " + item.Name;
                }

            }
            outputMessage(bag);
        }

        public void displaySpells()
        {

        }

        public void speak(String word)
        {
            outputMessage(word);
        }
        public void outputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
