using CineManager.Models.Entities;
using CineManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CineManager.Controllers;
public class UsuariosController : Controller
{
    //private readonly IUsuarioService _service;
    //public UsuariosController(IUsuarioService service) { _service = service; }
    private readonly IUsuarioService _service;

    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(
        IUsuarioService service, 
       
        ILogger<UsuariosController> logger)
    {
            _service = service;
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    }

    //public async Task<IActionResult> Index() => View(await _service.GetAllAsync());
    // public async Task<IActionResult> Index() => View(await _usuarioService.GetAllAsync());
   public async Task<IActionResult> Index()
{
    try
    {
        var usuarios = await _service.GetAllAsync();
        return View(usuarios);
    }
    catch (Exception ex)
    {
        // Registra el error con diferentes niveles de detalle
        _logger.LogError(ex, "Error al obtener la lista de usuarios");
        
        // Registra información adicional que puede ser útil para debugging
        _logger.LogDebug($"StackTrace: {ex.StackTrace}");
        _logger.LogDebug($"Source: {ex.Source}");
        _logger.LogDebug($"Inner Exception: {ex.InnerException?.Message}");

        // Agrega un mensaje de error temporal que se mostrará en la vista
        TempData["Error"] = "Ha ocurrido un error al cargar los usuarios. Por favor, inténtelo de nuevo.";
        
        // Puedes retornar una vista de error personalizada
       // return View(usuarios);
           return View(Index);
        // O retornar la vista Index con una lista vacía
        // return View(new List<Usuario>());
    }
}

 public IActionResult Create() => View();
    [HttpPost] public async Task<IActionResult> Create(Usuario model) { if(!ModelState.IsValid) return View(model); await _service.CreateAsync(model); return RedirectToAction(nameof(Index)); }
    //public IActionResult Create() => View();
    //[HttpPost] public async Task<IActionResult> Create(Usuario model) { if(!ModelState.IsValid) return View(model); await _service.CreateAsync(model); return RedirectToAction(nameof(Index)); }
  
    
   

    [HttpPost]
   
    public async Task<IActionResult> Edit(int id) { var e = await _service.GetByIdAsync(id); if (e == null) return NotFound(); return View(e); }
    [HttpPost] public async Task<IActionResult> Edit(int id, Usuario model) { if(id!=model.Id) return BadRequest(); if(!ModelState.IsValid) return View(model); await _service.UpdateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { await _service.DeleteAsync(id); return RedirectToAction(nameof(Index)); }
}
