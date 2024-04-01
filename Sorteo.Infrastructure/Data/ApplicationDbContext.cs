using Microsoft.EntityFrameworkCore;
using Sorteo.Domain.Models;

namespace Sorteo.Infrastructure.Data
{
    /// <summary>
    /// Representa el contexto de la base de datos para la aplicación, proporcionando acceso a las tablas de la base de datos a través de entidades DbSet.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options">Las opciones de configuración para el contexto de la base de datos.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Obtiene o establece el conjunto de entidades para la tabla de productos en la base de datos.
        /// </summary>
        public DbSet<Producto> Productos { get; set; }

        /// <summary>
        /// Obtiene o establece el conjunto de entidades para la tabla de asignaciones en la base de datos.
        /// </summary>
        public DbSet<Asignacion> Asignaciones { get; set; }

        /// <summary>
        /// Obtiene o establece el conjunto de entidades para la tabla de clientes en la base de datos.
        /// </summary>
        public DbSet<Cliente> Cliente { get; set; }

        /// <summary>
        /// Obtiene o establece el conjunto de entidades para la tabla de usuarios en la base de datos.
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Configura el modelo de base de datos y establece las convenciones de nomenclatura de tablas.
        /// </summary>
        /// <param name="modelBuilder">El constructor de modelos utilizado para configurar el modelo de base de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura las tablas en la base de datos y establece las convenciones de nomenclatura de tablas
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Asignacion>().ToTable("Asignacion");
            modelBuilder.Entity<Cliente>().ToTable("Cliente").HasNoKey();
            modelBuilder.Entity<Usuario>().ToTable("Usuario").HasNoKey();
        }
    }
}
