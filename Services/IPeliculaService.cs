using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface IPeliculaService { Task<IEnumerable<Pelicula>> GetAllAsync(); Task<Pelicula?> GetByIdAsync(int id); Task CreateAsync(Pelicula e); Task UpdateAsync(Pelicula e); Task DeleteAsync(int id); }
