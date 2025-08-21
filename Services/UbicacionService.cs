using CineManager.Models.Entities;
using CineManager.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using CineManager.Data; // Agregar este using
using Microsoft.EntityFrameworkCore; // Agregar este using
using Microsoft.Extensions.Logging;
namespace CineManager.Services;

public class UbicacionService : IUbicacionService
{
    private readonly AppDbContext _context;
    private readonly ILogger<UbicacionService> _logger;

    public UbicacionService(AppDbContext context, ILogger<UbicacionService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Departamento>> GetDepartamentosAsync()
    {
        try
        {
            return await _context.Departamentos
                .OrderBy(d => d.Nombre)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener departamentos");
            throw;
        }
    }

    public async Task<IEnumerable<Provincia>> GetProvinciasByDepartamentoAsync(int departamentoId)
    {
        try
        {
            return await _context.Provincias
                .Where(p => p.DepartamentoId == departamentoId)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener provincias para departamento {DepartamentoId}", departamentoId);
            throw;
        }
    }

    public async Task<IEnumerable<Distrito>> GetDistritosByProvinciaAsync(int provinciaId)
    {
        try
        {
            return await _context.Distritos
                .Where(d => d.ProvinciaId == provinciaId)
                .OrderBy(d => d.Nombre)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener distritos para provincia {ProvinciaId}", provinciaId);
            throw;
        }
    }
}