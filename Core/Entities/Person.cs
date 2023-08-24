namespace Core.Entities
{
    public class Person : BaseEntity
    {
        public string? IdPerson { get; set; }
        public string? NamePerson { get; set; }
        public DateTime BirthDay { get; set; }
        public int IdProdPerson { get; set; }
        public int IdPersonTypeFk { get; set; }
        public PersonType? PersonsType { get; set; }
        public int IdRegionFk { get; set; }
        public Region? Region { get; set; }
        public ICollection<ProductPerson>? ProductPersons { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}