using CineManager.Models.Entities;
using CineManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CineManager.Controllers;
public class PeliculasController : Controller
{
    private readonly IPeliculaService _service;
    private readonly ICategoriaService _categoriaService; // Agregar servicio de categorías
   public PeliculasController(IPeliculaService service, ICategoriaService categoriaService)
    {
        _service = service;
        _categoriaService = categoriaService;
    }
    public async Task<IActionResult> Index() => View(await _service.GetAllAsync());
    public async Task<IActionResult> Create()
  {
        // Obtener las categorías, crear el SelectList
        var categorias = await _categoriaService.GetAllAsync();
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre");
        return View();
    }

    [HttpPost] public async Task<IActionResult> Create(Pelicula model) { if(!ModelState.IsValid) return View(model); await _service.CreateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost] public async Task<IActionResult> Edit(int id, Pelicula model) { if(id!=model.Id) return BadRequest(); if(!ModelState.IsValid) return View(model); await _service.UpdateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { await _service.DeleteAsync(id); return RedirectToAction(nameof(Index)); }
}
