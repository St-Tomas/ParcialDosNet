using System.ComponentModel.DataAnnotations;

namespace ApiEfCore.Models;

public class Categoria
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Nombre { get; set; } = "Sin categoría";
    public List<Nota> Notas { get; set; } = new();
}