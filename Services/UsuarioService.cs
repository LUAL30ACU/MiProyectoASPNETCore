using CineManager.Models.Entities; using CineManager.Repositories; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public class UsuarioService : IUsuarioService {
    private readonly IGenericRepository<Usuario> _repo; public UsuarioService(IGenericRepository<Usuario> repo) { _repo = repo; }
    public async Task CreateAsync(Usuario e) { await _repo.AddAsync(e); await _repo.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var x = await _repo.GetByIdAsync(id); if(x==null) throw new KeyNotFoundException(); _repo.Remove(x); await _repo.SaveChangesAsync(); }
    public async Task<IEnumerable<Usuario>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<Usuario?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);
    public async Task UpdateAsync(Usuario e) { _repo.Update(e); await _repo.SaveChangesAsync(); }
}
