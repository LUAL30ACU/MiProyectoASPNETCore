
//Buenas prácticas aplicadas (CLEAN CODE, SOLID, patrones)
//SRP: cada clase hace una cosa (Controller -> UI, Service -> lógica, Repository -> datos).

//OCP: servicios e interfaces permiten extender sin modificar; p.ej. añadir ISalaService sin tocar controlador genérico.

//LSP: no forzar herencias si el comportamiento diverge (usa interfaces).

//ISP: interfaces finas (ej. ISucursalService sólo expone lo necesario).

//DIP: controladores dependen de abstracciones (interfaces) y no de implementaciones.

//Patrones: Repository + UnitOfWork (acoplamiento), (Por qué: desacoplar acceso a datos (DIP), facilitar pruebas unitarias y aplicar SRP.)
//Repository abstrae el acceso a datos, proporcionando una interfaz uniforme para interactuar con la base de datos (como consultas, inserciones, actualizaciones y eliminaciones). Esto separa la lógica de negocio de las operaciones de datos y facilita la prueba unitaria al permitir mockear el repositorio.
//es intermediario entre la aplicacion y el entityframework o api,evita instanciarv clase por cadatabla
//facilita testing y aislamiento
//Unit of Work gestiona transacciones y coordina las operaciones de múltiples repositorios, asegurando que todas las modificaciones se confirmen o reviertan como una unidad atómica,EF Core ya proporciona un DbContext que actúa como Unit of Work, pero podemos encapsularlo para mayor control.agrupando ,se asegura que todas las operaciones se manejen en una sola transaccion REPOSITORY SIN SON 20 TABLAS O REPOSITORY EVITA CONEXION DESCONECTAR 
//atomicidad y coordinacion de los repositorios
//DTOs / ViewModels + AutoMapper (separación UI <-> dominio).

//Clean code: nombres claros, métodos cortos, validaciones explícitas, comentarios mínimos y útiles.


using CineManager.Models.Entities;
using CineManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CineManager.Controllers;
public class CategoriasController : Controller
{
    private readonly ICategoriaService _service;
    public CategoriasController(ICategoriaService service) { _service = service; }
    public async Task<IActionResult> Index() => View(await _service.GetAllAsync());
    public IActionResult Create() => View();
    [HttpPost] public async Task<IActionResult> Create(Categoria model) { if(!ModelState.IsValid) return View(model); await _service.CreateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost] public async Task<IActionResult> Edit(int id, Categoria model) { if(id!=model.Id) return BadRequest(); if(!ModelState.IsValid) return View(model); await _service.UpdateAsync(model); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Delete(int id) { var e = await _service.GetByIdAsync(id); if(e==null) return NotFound(); return View(e); }
    [HttpPost, ActionName("Delete")] public async Task<IActionResult> DeleteConfirmed(int id) { await _service.DeleteAsync(id); return RedirectToAction(nameof(Index)); }
}
