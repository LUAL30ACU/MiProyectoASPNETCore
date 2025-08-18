using CineManager.Models.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CineManager.Models.Entities;



public class Sucursal
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Codigo { get; set; } = string.Empty;
    public Address Direccion { get; set; } = new Address();

    public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>();
    // Navegación 1..N
     public ICollection<Sala> Salas { get; set; } = new List<Sala>();
    }
