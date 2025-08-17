//os modelos representan los datos y la lógica de negocio:
//l DbContext es el puente entre los modelos y la base de datos
//servicios Contienen la lógica de negocio:
//controladoresManejan las peticiones HTTP y conectan modelos con vistas:
//vistas Muestran la interfaz de usuario: el front end
using System.Collections.Generic;
namespace CineManager.Models.Entities;
public class Categoria { public int Id { get; set; } public string Nombre { get; set; } = string.Empty; public ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>(); }
