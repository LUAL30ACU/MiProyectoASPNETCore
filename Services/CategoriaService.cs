using CineManager.Models.Entities; using CineManager.Repositories; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public class CategoriaService : ICategoriaService {

    private readonly IGenericRepository<Categoria> _repo;
    public CategoriaService(IGenericRepository<Categoria> repo) { _repo = repo; }

    public async Task CreateAsync(Categoria e) { await _repo.AddAsync(e); await _repo.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var x = await _repo.GetByIdAsync(id); if(x==null) throw new KeyNotFoundException(); _repo.Remove(x); await _repo.SaveChangesAsync(); }
    public async Task<IEnumerable<Categoria>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Categoria?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task UpdateAsync(Categoria e) { _repo.Update(e); await _repo.SaveChangesAsync(); }
}
