using Microsoft.EntityFrameworkCore;
using CineManager.Models.Entities;
namespace CineManager.Data;
public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
   

    public DbSet<Sucursal> Sucursales { get; set; } = null!;
    public DbSet<Sala> Salas { get; set; } = null!;
    public DbSet<Pelicula> Peliculas { get; set; } = null!;
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Funcion> Funciones { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Fluent API para la relación 1..N y la FK
        //  modelBuilder.Entity<Sala>()
        //      .HasOne(s => s.Sucursal)
        //     .WithMany(su => su.Salas)
        //     .HasForeignKey(s => s.SucursalId)
        //     .OnDelete(DeleteBehavior.Restrict); // o Cascade, según tu negocio
        modelBuilder.Entity<Sucursal>().OwnsOne(s => s.Direccion);
      //  modelBuilder.Entity<Usuario>().OwnsOne(u => u.Direccion);
        modelBuilder.Entity<Sucursal>().HasIndex(s => s.Codigo).IsUnique();
        modelBuilder.Entity<Sala>().HasOne(s => s.Sucursal).WithMany(su => su.Salas).HasForeignKey(s => s.SucursalId);
        modelBuilder.Entity<Funcion>().HasOne(f => f.Sucursal).WithMany(su => su.Funciones).HasForeignKey(f => f.SucursalId);
        modelBuilder.Entity<Funcion>().HasOne(f => f.Sala).WithMany(sa => sa.Funciones).HasForeignKey(f => f.SalaId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Funcion>().HasOne(f => f.Pelicula).WithMany(p => p.Funciones).HasForeignKey(f => f.PeliculaId);
    

    }
}
