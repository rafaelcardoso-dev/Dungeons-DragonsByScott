using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {

        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int MONSTER_ID_ORC = 1;
        public const int MONSTER_ID_CYCOPLE = 2;
        public const int MONSTER_ID_SKELETON = 3;

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_AXE = 2;
        public const int ITEM_ID_DUNGEON_STAFF = 3;
        public const int ITEM_ID_SHIELD = 4;
        public const int ITEM_ID_RING = 5;
        public const int ITEM_ID_STONE_OF_LIGHT = 6;


        public const int QUEST_ID_THE_STONE_OF_LIGTH = 1;
        public const int QUEST_ID_STAFFS_DUNGEON = 2;
        public const int QUEST_ID_KILL_SKELETON = 3;


        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_ELDORIA = 2;
        public const int LOCATION_ID_DUNGEON = 3;
        public const int LOCATION_ID_ROOM_1_DUNGEON = 4;
        public const int LOCATION_ID_CATACOMBS = 5;
        public const int LOCATION_ID_FIRST_ROOM_CATACOMBS = 6;
        



























        static World()
        {
            PopulateMonster();
            PolulateItem();
            PopulateQuest();
            PopulateLocation();
        }
        private static void PopulateMonster()
        {
            Monster orc = new Monster(MONSTER_ID_ORC, "Orc", 20, 20, 8, 10, 4);
            orc.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUSTY_SWORD), 75, false));
            Monsters.Add(orc);

            Monster cyclope = (new Monster(MONSTER_ID_CYCOPLE, "Cyclope", 50, 30, 30, 30, 10));
            cyclope.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUSTY_SWORD), 90, true));
            Monsters.Add(cyclope);

            Monster skeleton = (new Monster(MONSTER_ID_SKELETON, "Skeleton", 30, 20, 20, 20, 10));
            skeleton.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHIELD), 75, true));
            Monsters.Add(skeleton);
















            












        }
        private static void PolulateItem()
        {

            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty Sword", 2, 10));
            Items.Add(new Weapon(ITEM_ID_AXE, "Axe", "Axes", 1, 6));
            Items.Add(new Item(ITEM_ID_SHIELD, "Shield", "Shields"));
            Items.Add(new Item(ITEM_ID_RING, "Ring", "Rings"));
            Items.Add(new Item(ITEM_ID_STONE_OF_LIGHT, "Stone of light", "Stone of light"));



























        }
        public static void PopulateQuest()
        {
            Quest theStoneOfLight = new Quest(
                QUEST_ID_THE_STONE_OF_LIGTH,
                "The Stone of Light\n",
                "In Eldoria, darkness threatens the village. The elders speak of a powerful relic, the Stone of Light, which can banish the shadows and bring hope.\n Objective:\r\nRetrieve the Stone of Light, hidden in a cave.\n", "The relic is activated by the elders, emitting a bright light that drives away the darkness", 20, 20);
            theStoneOfLight.RewardItem = ItemByID(ITEM_ID_RUSTY_SWORD);
            theStoneOfLight.QuestCompletationItems.Add(new QuestCompletationItem(ItemByID(ITEM_ID_STONE_OF_LIGHT), 1));
            Quests.Add(theStoneOfLight);

            Quest staffDungeon = (new Quest(
                QUEST_ID_STAFFS_DUNGEON,
                "Staff's Dungeon",
                "Bring back the staff from the dungeon","", 10, 10));
            staffDungeon.RewardItem = ItemByID(ITEM_ID_AXE);
            staffDungeon.QuestCompletationItems.Add(new QuestCompletationItem(ItemByID(ITEM_ID_DUNGEON_STAFF), 1));

            Quest killSkeleton = new Quest(
               QUEST_ID_KILL_SKELETON,
               "Kill skeleton", "Kill the skeleton at catacombs","", 30, 10);
            Quests.Add(killSkeleton);
































        }
        public static void PopulateLocation()
        {

            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");
            
            Location eldoria = new Location(LOCATION_ID_ELDORIA, "Eldoria", "As the you arrives in Eldoria, they are welcomed by a picturesque landscape. Nestled in a lush valley, the village is framed by majestic mountains glimmering in the sunset. Verdant fields, dotted with vibrant flowers, sway in the gentle breeze. A clear river winds through the village, sparkling as it flows over smooth stones.");
            eldoria.QuestAvailableHere = QuestByID(QUEST_ID_THE_STONE_OF_LIGTH);            

            Location dungeon = (new Location(LOCATION_ID_DUNGEON, "Dungeon", "You see a dungeon"));
            dungeon.QuestAvailableHere = QuestByID(QUEST_ID_STAFFS_DUNGEON);
            dungeon.MonsterLivingHere = MonsterByID(MONSTER_ID_CYCOPLE);

            Location catacombs = new Location(LOCATION_ID_CATACOMBS, "Catacombs", "Dark Catacombs");
            catacombs.QuestAvailableHere = QuestByID(QUEST_ID_KILL_SKELETON);
            catacombs.ItemRequiredToEnter = ItemByID(ITEM_ID_RING);

            Location firstRoomDungeon = new Location(LOCATION_ID_ROOM_1_DUNGEON, "First room", "You see a dark room and chest");
            firstRoomDungeon.ChestAvailableHere = ItemByID(ITEM_ID_STONE_OF_LIGHT);

            Location firstRoommCatacombs = new Location(LOCATION_ID_FIRST_ROOM_CATACOMBS, "First room catacombs", "Very dark room");
            firstRoommCatacombs.MonsterLivingHere = MonsterByID(MONSTER_ID_SKELETON);



            Locations.Add(home);
            Locations.Add(eldoria);

            Locations.Add(dungeon);
            Locations.Add(firstRoomDungeon);

            Locations.Add(catacombs);
            Locations.Add(firstRoommCatacombs);
            



            home.LocationToNorth = eldoria;

            eldoria.LocationToSouth = home;
            eldoria.LocationToNorth = dungeon;
            eldoria.LocationToEast = catacombs;


            dungeon.LocationToNorth = firstRoomDungeon;
            dungeon.LocationToSouth = eldoria;

            firstRoomDungeon.LocationToSouth = dungeon;

            catacombs.LocationToNorth = firstRoommCatacombs;










          


            
















        }
        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
                
            }
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            { 
                if (quest.ID == id)
                {  
                    return quest;                
                }
                
            }
            return null;
        }
        public static Monster MonsterByID(int id)
        {
            foreach(Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }           
    }

}
