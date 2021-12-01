using System.Collections;
using System.Collections.Generic;
using System;

namespace CombineGame
{
    public class GameWorld
    {
        public string itemNames;
        static private GameWorld _instance;
        private List<Location> locations;
        public Dictionary<NPC, Location> NPC;

        public Dictionary<List<Item>, Location> Items;
        static public GameWorld Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameWorld();
                return _instance;
            }
        }
        private Location _entrance;
        public Location Entrance { get { return _entrance; } }
        private Location trigger;
        //private Location connectionLocation;
        public GameWorld()
        {
            _entrance = createWorld();
            // GameWorld subscribes to the notification PlayerEnteredRoom
            NotificationCenter.Instance.addObserver("PlayerEnteredRoom", playerEnteredPortal);
            //NotificationCenter.Instance.addObserver("PlayerSpeak", playerSpeakWord);
        }

        private Location createWorld()
        {
            Location village = new Location("in the village now");
            Location market = new Location("in the market now");
            Location warehouse = new Location("in the warehouse now");
            Location jungle = new Location("in the jungle now");
            Location town = new Location("in the town now");
            Location portal = new Location("in the portal now");
            Location arena = new Location("in the green in from of Schuster Center now");

            locations = new List<Location>();

            locations.Add(village);
            locations.Add(market);
            locations.Add(warehouse);
            locations.Add(jungle);
            locations.Add(town);
            locations.Add(portal);
            locations.Add(arena);

            village.setExit("market", market);

            market.setExit("village", village);
            market.setExit("portal", portal);
            market.setExit("arena", arena);
            market.setExit("jungle", jungle);

            warehouse.setExit("portal", portal);
            warehouse.setExit("market", market);

            portal.setExit("warehouse", warehouse);

            jungle.setExit("portal", portal);
            village.setExit("arena", arena);

            arena.setExit("market", market);

            jungle.setExit("market", market);
            jungle.setExit("town", town);

            town.setExit("north", jungle);

            Items = new Dictionary<List<Item>, Location>();

            List<Item> itemVillage = new List<Item>();
            Item shoes = new Item("shoes", 4, 5);
            Item gloves = new Item("gloves", 2, 3);
            itemVillage.Add(shoes);
            itemVillage.Add(gloves);
            placeItem(itemVillage, village);

            List<Item> itemShop = new List<Item>();
            Item apple = new Item("apple", 1, 1);
            Item jewel = new Item("jewel", 1, 1);
            itemShop.Add(apple);
            itemShop.Add(jewel);
            placeItem(itemShop, market);

            NPC = new Dictionary<NPC, Location > ();
            NPC npcGoblin = new NPC("Goblin");

            placeNPC(npcGoblin, village);


            trigger = portal;

            //connectionLocation = arena;


            return village;
        }

        public void placeItem(List<Item> itemList, Location location)
        {

            Items[itemList] = location;
        }

        public void placeNPC(NPC npcName, Location location)
        {
            NPC[npcName] = location;
        }

        /*
        public Location getItem(List<Item> itemList)
        {
            Location location = null;
            Items.TryGetValue(itemList, out location);
            return location;
        }*/

        public void playerEnteredPortal(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentLocation == trigger)
            {
                Console.WriteLine("===== A Portal! \nYou have been transported to a random location.");

                //Converts the curent location to a random location.
                Random rnd = new Random();
                player.currentLocation = locations[rnd.Next(locations.Count)];
            }
        }

        // callback method for PlayerEnteredRoom
        /*public void playerSpeakWord(Notification notification)
        {
            Player player = (Player)notification.Object;
            if (player.currentLocation == trigger)
            {
                Dictionary<String, Object> userInfo = notification.userInfo;
                String word = (String)userInfo["word"];

                Console.WriteLine("Player entered the trigger room");

                Location davidson = new Location("in the Davidson Center");
                connectionLocation.setExit("west", davidson);
                //davidson.setExit("east", connectionLocation);
            }
        }*/
    }
}
