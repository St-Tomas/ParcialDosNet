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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nota>()
            .HasOne(n => n.Persona)
            .WithMany(p => p.Notas)
            .HasForeignKey(n => n.PersonaId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Nota>()
            .HasOne(n => n.Categoria)
            .WithMany(c => c.Notas)
            .HasForeignKey(n => n.CategoriaId)
            .OnDelete(DeleteBehavior.SetNull);

        base.OnModelCreating(modelBuilder);
    }
}