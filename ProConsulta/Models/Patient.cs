namespace ProConsulta.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        
        // Lazyload
        public ICollection<Docket> Dockets { get; set; } = new List<Docket>();

    }
}
