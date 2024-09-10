using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Pacientes;

public class PatientInputModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Nome deve ser fornecido")]
    [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
    public string Name { get; set; }
   
    [Required(ErrorMessage = "Documento deve ser fornecido")]
    public string Document { get; set; }
    
    [Required(ErrorMessage = "Telefone deve ser fornecido")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [MaxLength(50, ErrorMessage = "{0} deve ter no maximo {1} caracteres")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Telefone deve ser fornecido")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Data de nascimento deve ser fornecido")]
    public DateTime BirthDate { get; set; }
}