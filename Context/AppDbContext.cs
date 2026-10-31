using Microsoft.EntityFrameworkCore;
using ApiEfCore.Models;
namespace ApiEfCore.Context;

public class AppDbContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Nota> Notas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}