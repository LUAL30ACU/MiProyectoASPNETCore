using CineManager.Models.ValueObjects;
namespace CineManager.Models.Entities;



    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; } = null!;
        public List<Distrito> Distritos { get; set; } = new List<Distrito>();
    }
