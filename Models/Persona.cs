using System.ComponentModel.DataAnnotations;

namespace ApiEfCore.Models;
public class Persona
{
    public int PersonaId { get; set; }
    
    [Required(ErrorMessage = "A man needs a name")] //GoT reference de las gods
    [MaxLength(50, ErrorMessage = "El nombre no puede ser mayor a 50 caracteres")]
    public string Nombre { get; set; } = string.Empty;
    public List<Nota> Notas { get; set; } = new();
}