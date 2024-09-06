namespace ProConsulta.Models;

public class Docket
{
    public int Id { get; set; }
    public string? Observation { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public TimeSpan? TimeConsult { get; set; }
    public DateTime DateConsult { get; set; }
}