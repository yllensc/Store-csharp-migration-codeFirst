using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Region
    {
        public int IdRegion { get; set; }
        public string ? RegionName { get; set;}
        public int IdStateFK { get; set; }
    }
}