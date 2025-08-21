using CineManager.Models.Entities;
using CineManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace CineManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UbicacionController : ControllerBase
{
    private readonly IUbicacionService _service;
    private readonly ILogger<UbicacionController> _logger;

    public UbicacionController(IUbicacionService service, ILogger<UbicacionController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet("departamentos")]
    public async Task<IActionResult> GetDepartamentos()
    {
        try
        {
            var departamentos = await _service.GetDepartamentosAsync();
            return Ok(departamentos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener departamentos");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("provincias/{departamentoId}")]
    public async Task<IActionResult> GetProvincias(int departamentoId)
    {
        try
        {
            var provincias = await _service.GetProvinciasByDepartamentoAsync(departamentoId);
            return Ok(provincias);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener provincias");
            return StatusCode(500, "Error interno del servidor");
        }
    }

    [HttpGet("distritos/{provinciaId}")]
    public async Task<IActionResult> GetDistritos(int provinciaId)
    {
        if (provinciaId <= 0)
        {
            return BadRequest("El ID de la provincia no es válido");
        }

        try
        {
            var distritos = await _service.GetDistritosByProvinciaAsync(provinciaId);
            if (!distritos.Any())
            {
                _logger.LogWarning("No se encontraron distritos para la provincia {ProvinciaId}", provinciaId);
                return NotFound($"No se encontraron distritos para la provincia {provinciaId}");
            }
            return Ok(distritos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener distritos para la provincia {ProvinciaId}", provinciaId);
            return StatusCode(500, new { message = "Error interno del servidor", details = ex.Message });
        }
    }
}