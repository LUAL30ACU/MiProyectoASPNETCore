using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface ICategoriaService { Task<IEnumerable<Categoria>> GetAllAsync(); Task<Categoria?> GetByIdAsync(int id); Task CreateAsync(Categoria e); Task UpdateAsync(Categoria e); Task DeleteAsync(int id); }
