using CineManager.Models.ValueObjects;
namespace CineManager.Models.Entities;


    public class Distrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; } = null!;
    }
