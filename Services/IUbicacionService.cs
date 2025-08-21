using CineManager.Models.Entities; using System.Collections.Generic; using System.Threading.Tasks;
namespace CineManager.Services;
public interface IUbicacionService
{
    Task<IEnumerable<Departamento>> GetDepartamentosAsync();
    Task<IEnumerable<Provincia>> GetProvinciasByDepartamentoAsync(int departamentoId);
    Task<IEnumerable<Distrito>> GetDistritosByProvinciaAsync(int provinciaId);
}
