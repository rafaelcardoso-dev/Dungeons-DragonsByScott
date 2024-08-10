using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class IventoryItem
    {
        public Item Details { get; set; }

        public IventoryItem(Item details)
        {
            Details = details;
        }

    }
}
