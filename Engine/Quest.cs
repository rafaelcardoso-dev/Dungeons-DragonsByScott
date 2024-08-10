using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EndDescription { get; set; }
        public int RewardExperience {get;set;}
        public int RewardGold { get; set; }
        public Item RewardItem { get; set; }
        public List<QuestCompletationItem> QuestCompletationItems { get; set; }
        public Quest(int id, string name, string description,string endDescription, int rewardExperience, int rewardGold)
        {
            ID = id;
            Name = name;    
            Description = description;
            EndDescription = endDescription;  
            RewardExperience = rewardExperience;
            RewardGold = rewardGold;
            QuestCompletationItems = new List<QuestCompletationItem>();
        }

    }
}
