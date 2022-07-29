using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Estudiante
    {   [Key]
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Ocupacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int Estado { get; set; }
        public int ParcialTeorico { get; set; }
        public int ParcialPractico { get; set; }

    }
}