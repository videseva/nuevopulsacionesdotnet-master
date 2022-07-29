using System;
using System.ComponentModel.DataAnnotations;
namespace Entidad
{
    public class Administrador
    {   [Key]
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }

    }
}