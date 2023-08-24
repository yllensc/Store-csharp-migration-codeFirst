using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ? InternalCode { get; set; }
        public string ? NameProduct { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int Stock { get; set; }
        public double TotalPrice { get; set; }
        public ICollection<ProductPerson> ? ProductPersons { get; set;}
        public ICollection<Person> Persons { get; set;} = new HashSet<Person>();

    }
}