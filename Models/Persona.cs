using System.ComponentModel.DataAnnotations;

namespace ApiEfCore.Models;
public class Persona
{
    public int PersonaId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;
}