using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface ISalaService { Task<IEnumerable<Sala>> GetAllAsync(); Task<Sala?> GetByIdAsync(int id); Task CreateAsync(Sala e); Task UpdateAsync(Sala e); Task DeleteAsync(int id); }
