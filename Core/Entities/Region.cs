using System.ComponentModel.DataAnnotations;
namespace Core.Entities
{
    public class Region : BaseEntity
    {
        public string? RegionName { get; set; }
        public int IdStateFK { get; set; }
        public State? State { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}