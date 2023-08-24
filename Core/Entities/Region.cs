using System.ComponentModel.DataAnnotations;
namespace Core.Entities
{
    public class Region
    {
        [Key]
        public int IdRegion { get; set; }
        public string ? RegionName { get; set;}
        public int IdStateFK { get; set; }
        public State ? State { get; set; }
        public ICollection<Person> ? Persons { get; set; }

    }
}