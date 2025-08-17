using CineManager.Models.Entities; using CineManager.Repositories; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public class FuncionService : IFuncionService {
    private readonly IGenericRepository<Funcion> _repo; public FuncionService(IGenericRepository<Funcion> repo) { _repo = repo; }
    public async Task CreateAsync(Funcion e) { await _repo.AddAsync(e); await _repo.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var x = await _repo.GetByIdAsync(id); if(x==null) throw new KeyNotFoundException(); _repo.Remove(x); await _repo.SaveChangesAsync(); }
    public async Task<IEnumerable<Funcion>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Funcion?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task UpdateAsync(Funcion e) { _repo.Update(e); await _repo.SaveChangesAsync(); }
}
