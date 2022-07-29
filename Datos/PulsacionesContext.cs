using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class PulsacionesContext : DbContext{
        public PulsacionesContext(DbContextOptions options) : base(options)
        {
            }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Administrador> Administradors { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        }


}