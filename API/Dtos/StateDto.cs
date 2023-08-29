using Core.Entities;

namespace API.Dtos
{
    public class StateDto
    {
        public int Id { get; set; }
        public string? StateName { get; set; }
        public int IdCountry { get; set; }
    }
}