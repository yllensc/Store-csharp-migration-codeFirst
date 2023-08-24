using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string ? NameCountry { get; set; }

        public ICollection<State> ? States { get; set; }
    }
}