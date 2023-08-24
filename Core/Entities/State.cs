using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class State : BaseEntity
    {
        public string? NameState { get; set; }
        public int IdCountryFK { get; set; }
        public Country? Country { get; set; }
        public ICollection<Region>? Regions { get; set; }
    }
}