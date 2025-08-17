using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Repositories;
public interface IGenericRepository<T> where T: class { Task<T?> GetByIdAsync(int id); Task<IEnumerable<T>> GetAllAsync(); Task AddAsync(T entity); void Update(T entity); void Remove(T entity); Task SaveChangesAsync(); }
