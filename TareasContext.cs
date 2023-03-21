using Microsoft.EntityFrameworkCore;
using myproject.Models;

namespace myproject;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        List<Categoria> categoriaList = new List<Categoria>();
        categoriaList.Add(new Categoria(){
            CategoriaId = Guid.Parse("43ebe791-deae-43e5-815d-e74ba2f91a11"),
            Nombre = "Actividades pendientes",
            Descripcion = "Esta es la decripcion de + Actividades pendientes",
            Peso = 20
        });
        categoriaList.Add(new Categoria(){
            CategoriaId = Guid.Parse("43ebe791-deae-43e5-815d-e74ba2f91a02"),
            Nombre = "Actividades personales",
            Descripcion = "Esta es la decripcion de + Actividades personales",
            Peso = 50
        });


        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriaList);
        });

        List<Tarea> tareaList = new List<Tarea>();
        tareaList.Add(new Tarea(){
            TareaId = Guid.Parse("43ebe791-deae-43e5-815d-e74ba2f91587"),
            CategoriaId = Guid.Parse("43ebe791-deae-43e5-815d-e74ba2f91a11"),
            Titulo = "Aprender Graphql",
            Descripcion = "Necesito aprender acerca de Graphql",
            PrioridadTarea = Prioridad.Media,
            FechaCreacion = DateTime.Now,
            Resumen = "Necesito aprender acerca de Graphql"

        });
        tareaList.Add(new Tarea(){
            TareaId = Guid.Parse("43ebe791-deae-43e5-815d-e74ba2f91965"),
            CategoriaId = Guid.Parse("43ebe791-deae-43e5-815d-e74ba2f91a02"),
            Titulo = "Aprender React",
            Descripcion = "Necesito aprender acerca de React",
            PrioridadTarea = Prioridad.Baja,
            FechaCreacion = DateTime.Now,
            Resumen = "Necesito aprender acerca de React"

        });

        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion);
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);
            tarea.HasData(tareaList);
        });
    }

}