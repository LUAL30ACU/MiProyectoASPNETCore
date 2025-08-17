using CineManager.Models.Entities; using CineManager.Repositories; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public class SalaService : ISalaService {
    private readonly IGenericRepository<Sala> _repo; public SalaService(IGenericRepository<Sala> repo) { _repo = repo; }
    public async Task CreateAsync(Sala e) { await _repo.AddAsync(e); await _repo.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var x = await _repo.GetByIdAsync(id); if(x==null) throw new KeyNotFoundException(); _repo.Remove(x); await _repo.SaveChangesAsync(); }
    public async Task<IEnumerable<Sala>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Sala?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task UpdateAsync(Sala e) { _repo.Update(e); await _repo.SaveChangesAsync(); }
}
