using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon: Item
    {
        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }

        public Weapon(int id, string name,string pluralName, int minimumDamage, int maximumDamage) :base(id,name,pluralName)
        {
            MaximumDamage = minimumDamage;
            MinimumDamage = maximumDamage;
            
        }
    }
}
