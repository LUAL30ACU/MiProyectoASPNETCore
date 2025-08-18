namespace CineManager.Models.Entities;
public class Sala { public int Id { get; set; } 
public int NumeroSala { get; set; } 
public int Capacidad { get; set; }
    public string Clase { get; set; } = string.Empty;
 // 👇 Clave foránea (FK) y navegación hacia Sucursal
    public int SucursalId { get; set; } //FK
public Sucursal? Sucursal { get; set; } 
public ICollection<Funcion> Funciones { get; set; } = new List<Funcion>(); }


   