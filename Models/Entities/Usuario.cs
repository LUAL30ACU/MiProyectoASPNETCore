using CineManager.Models.ValueObjects;
namespace CineManager.Models.Entities;
public class Usuario { public int Id { get; set; } public string TipoDocumento { get; set; } = string.Empty; public string NumeroDocumento { get; set; } = string.Empty; public string Nombre { get; set; } = string.Empty; public string Apellido { get; set; } = string.Empty; public string Correo { get; set; } = string.Empty; public Address Direccion { get; set; } = new Address(); }
