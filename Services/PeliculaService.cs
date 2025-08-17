using CineManager.Models.Entities; using CineManager.Repositories; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public class PeliculaService : IPeliculaService {
    private readonly IGenericRepository<Pelicula> _repo; public PeliculaService(IGenericRepository<Pelicula> repo) { _repo = repo; }
    public async Task CreateAsync(Pelicula e) { await _repo.AddAsync(e); await _repo.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var x = await _repo.GetByIdAsync(id); if(x==null) throw new KeyNotFoundException(); _repo.Remove(x); await _repo.SaveChangesAsync(); }
    public async Task<IEnumerable<Pelicula>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Pelicula?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task UpdateAsync(Pelicula e) { _repo.Update(e); await _repo.SaveChangesAsync(); }
}
