using System.Collections.Generic;
namespace CineManager.Models.Entities;
public class Pelicula { public int Id { get; set; } public string Nombre { get; set; } = string.Empty; public int CategoriaId { get; set; } public Categoria? Categoria { get; set; } public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>(); }
