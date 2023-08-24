using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductPerson : BaseEntity
    {
        public int IdProductFK { get; set; }
        public Product? Product { get; set; }
        public int IdPersonFK { get; set; }
        public Person? Person { get; set; }
    }
}