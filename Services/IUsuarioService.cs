using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface IUsuarioService { Task<IEnumerable<Usuario>> GetAllAsync(); Task<Usuario?> GetByIdAsync(int id); Task CreateAsync(Usuario e); Task UpdateAsync(Usuario e); Task DeleteAsync(int id); }
