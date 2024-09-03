namespace ProConsulta.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string CRM { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; } = null!;
        // Lazyload
        public ICollection<Docket> Dockets { get; set; } = new List<Docket>();
    }
}
