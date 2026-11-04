using ApiEfCore.Models;
namespace ApiEfCore.Services;

public interface INotaService
{
    Task<List<Nota>> GetAllAsync();
    Task<Nota?> GetByIdAsync(int id);
    Task<Nota> CreateAsync(Nota nota);
    Task<bool> UpdateAsync(int id, Nota nota);
    Task<bool> DeleteAsync(int id);
}