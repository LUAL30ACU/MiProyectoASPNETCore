using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface IFuncionService { Task<IEnumerable<Funcion>> GetAllAsync(); Task<Funcion?> GetByIdAsync(int id); Task CreateAsync(Funcion e); Task UpdateAsync(Funcion e); Task DeleteAsync(int id); }
