using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LivingCreature
    {
        /// <summary>
        /// Maximum health of the player
        /// </summary>
        public int MaximumHitPoints { get; set; }
        /// <summary>
        /// Amount of health at that current time
        /// </summary>
        public int CurrentHitPoints { get; set; }

        public LivingCreature(int currentHitPoints, int maximumHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }
    }
}
