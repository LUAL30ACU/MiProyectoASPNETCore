using CineManager.Models.Entities;
using CineManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CineManager.Controllers;
public class FuncionesController : Controller
{
    private readonly IFuncionService _service;
    private readonly ISucursalService _sucursalService;
     public FuncionesController(IFuncionService service, ISucursalService sucursalService)
    {
        _service = service;
        _sucursalService = sucursalService;
    }
    public async Task<IActionResult> Index() => View(await _service.GetAllAsync());
 public async Task<IActionResult> Create()
    {
        // Obtener las sucursales para el select
        var sucursales = await _sucursalService.GetAllAsync();
        ViewBag.Sucursales = new SelectList(sucursales, "Id", "Nombre");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Funcion model)
    {
        if (!ModelState.IsValid)
        {
            // Recargar las sucursales si hay error de validación
            var sucursales = await _sucursalService.GetAllAsync();
            ViewBag.Sucursales = new SelectList(sucursales, "Id", "Nombre");
            return View(model);
        }
           
        await _service.CreateAsync(model);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Edit(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost] public async Task<IActionResult> Edit(int id, Funcion model) { if(id!=model.Id) return BadRequest(); if(!ModelState.IsValid) return View(model); await _service.UpdateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { await _service.DeleteAsync(id); return RedirectToAction(nameof(Index)); }
}
