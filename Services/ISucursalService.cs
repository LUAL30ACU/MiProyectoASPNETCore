using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface ISucursalService { Task<IEnumerable<Sucursal>> GetAllAsync(); Task<Sucursal?> GetByIdAsync(int id); Task CreateAsync(Sucursal e); Task UpdateAsync(Sucursal e); Task DeleteAsync(int id); }
