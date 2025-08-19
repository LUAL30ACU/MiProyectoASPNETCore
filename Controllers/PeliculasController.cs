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

    [HttpPost] public async Task<IActionResult> Create(Pelicula model) { if (!ModelState.IsValid) return View(model); await _service.CreateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var pelicula = await _service.GetByIdAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            // Cargar las categorías para el select
            var categorias = await _categoriaService.GetAllAsync();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre", pelicula.CategoriaId);

            return View(pelicula);
        }
        catch (Exception ex)
        {
            // Agregar logging aquí
            return Content($"Error: {ex.Message} - StackTrace: {ex.StackTrace}");
        }
    }


    [HttpPost]
    public async Task<IActionResult> Edit(int id, Pelicula pelicula)
    {
        if (id != pelicula.Id)
        {
            return NotFound();
        }

        try
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(pelicula);
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error al actualizar la película");
        }

        // Recargar categorías si hay error
        var categorias = await _categoriaService.GetAllAsync();
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre", pelicula.CategoriaId);
        return View(pelicula);
    }

    public async Task<IActionResult> Delete(int id) { var e = await _service.GetByIdAsync(id); if (e == null) return NotFound(); return View(e); }
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { await _service.DeleteAsync(id); return RedirectToAction(nameof(Index)); }
}