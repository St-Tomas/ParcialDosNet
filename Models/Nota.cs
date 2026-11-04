using System.ComponentModel.DataAnnotations;

namespace ApiEfCore.Models;

public class Nota
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion {get; set;} = string.Empty;
    public bool Completa {get; set;}
    public int? CategoriaId { get; set; }
    public int PersonaId { get; set; }
    public Persona? Persona { get; set; }
    public Categoria? Categoria { get; set; }
}