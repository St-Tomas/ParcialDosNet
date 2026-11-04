using System.ComponentModel.DataAnnotations;

namespace ApiEfCore.Models;

public class Categoria
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "A Category needs a name)?")]
    [MaxLength(30, ErrorMessage = "El nombre de la categoria no puede superar los 30 caracteres.")]
    public string Nombre { get; set; } = string.Empty;
}