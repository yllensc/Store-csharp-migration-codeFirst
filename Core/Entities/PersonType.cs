using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class PersonType : BaseEntity
    {
        public string? Description { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}