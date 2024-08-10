using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Engine    
{   /// <summary>
    /// Playable character
    /// </summary>
    public class Player : LivingCreature
    {

        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public int Damage { get; set; }
        public bool OpemChestYet { get; set; }
        public Location CurrentLocation { get; set; }
        
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quest { get; set; }

        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level,int damage, bool opemChestYet) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;
            Damage = damage;
            OpemChestYet = opemChestYet;

            Inventory = new List<InventoryItem>();
            Quest = new List<PlayerQuest>();
        }

        public bool PlayerAlreadyHasQuest(Quest quest)
        {
            foreach (PlayerQuest pq in Quest)
            {   
                if (pq.Details.ID == quest.ID) 
                    return true;                
            }
            return false;
        }

        public bool PlayerHasItemQuest (Quest quest)
        {
            foreach (InventoryItem ii in Inventory)
            {   
                foreach (QuestCompletationItem qci in quest.QuestCompletationItems)
                if (ii.Details.ID == qci.Details.ID) 
                    return true;
            }
            return false;
        }

    }
 
}
