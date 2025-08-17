using System;
namespace CineManager.Models.Entities;
public class Funcion { public int Id { get; set; } public int SucursalId { get; set; } public Sucursal? Sucursal { get; set; } public int SalaId { get; set; } public Sala? Sala { get; set; } public int PeliculaId { get; set; } public Pelicula? Pelicula { get; set; } public DateTime Horario { get; set; } }
