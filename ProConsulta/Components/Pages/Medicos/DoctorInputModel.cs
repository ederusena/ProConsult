using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Medicos;

public class DoctorInputModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser fornecido")]
    [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Documento deve ser fornecido")]
    public string Document { get; set; } = null!;

    [Required(ErrorMessage = "CRM deve ser fornecido")]
    [MaxLength(50, ErrorMessage = "{0} deve ter no maximo {1} caracteres")]
    public string CRM { get; set; } = null!;

    [Required(ErrorMessage = "Telefone deve ser fornecido")]
    public string PhoneNumber { get; set; } = null!;

    public DateTime CreateDate { get; set; } = DateTime.Now;
    
    [Required(ErrorMessage = "Especialidade deve ser fornecido")]
    [RegularExpression("([1-9][0-9]*)",ErrorMessage = "Valor inválido" )]
    public int SpecialityId { get; set; }
}