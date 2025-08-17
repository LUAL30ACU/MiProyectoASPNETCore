using CineManager.Models.ValueObjects;
using System.Collections.Generic;
namespace CineManager.Models.Entities;
public class Sucursal {
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Codigo { get; set; } = string.Empty;
    public Address Direccion { get; set; } = new Address();
    public ICollection<Sala> Salas { get; set; } = new List<Sala>();
    public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
}
