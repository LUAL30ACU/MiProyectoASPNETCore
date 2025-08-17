using CineManager.Data; using Microsoft.EntityFrameworkCore; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T: class {
    protected readonly AppDbContext _context; protected readonly DbSet<T> _dbSet;
    public GenericRepository(AppDbContext context) { _context = context; _dbSet = context.Set<T>(); }
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public void Update(T entity) => _dbSet.Update(entity);
    public void Remove(T entity) => _dbSet.Remove(entity);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
