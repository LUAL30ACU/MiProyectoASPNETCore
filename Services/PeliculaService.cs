using CineManager.Models.Entities;
using CineManager.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CineManager.Data; 
namespace CineManager.Services;
public class PeliculaService : IPeliculaService {
    private readonly IGenericRepository<Pelicula> _repo;
     private readonly AppDbContext _context;


        public PeliculaService(IGenericRepository<Pelicula> repo, AppDbContext context)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    public async Task CreateAsync(Pelicula e) { await _repo.AddAsync(e); await _repo.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) { var x = await _repo.GetByIdAsync(id); if(x==null)
    throw new KeyNotFoundException(); _repo.Remove(x); await _repo.SaveChangesAsync(); }
    // public async Task<IEnumerable<Pelicula>> GetAllAsync() => await _repo.GetAllAsync();
  
   public async Task<IEnumerable<Pelicula>> GetAllAsync()
    {
        return await _context.Peliculas
            .Include(p => p.Categoria)  // Incluir la categoría
            .ToListAsync();
    }
     public async Task<Pelicula?> GetByIdAsync(int id)
    {
        return await _context.Peliculas
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task UpdateAsync(Pelicula e) { _repo.Update(e); await _repo.SaveChangesAsync(); }
}
