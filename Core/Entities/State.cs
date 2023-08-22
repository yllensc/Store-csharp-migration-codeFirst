using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string ? NameState { get; set; }
        public int IdCountryFK { get; set; }
    }
}