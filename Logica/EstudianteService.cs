using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Logica
{
    public class EstudianteService
    {
        private readonly PulsacionesContext _context;
        
        public EstudianteService(PulsacionesContext context)
        {   
            _context=context;
        }

        public GuardarEstudianteResponse Guardar(Estudiante estudiante)
        {
            try
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                return new GuardarEstudianteResponse(estudiante);
            }
            catch (Exception e)
            {
                return new GuardarEstudianteResponse($"Error: {e.Message}");
            }
        }

        public List<Estudiante> Consultar()
        {
            List<Estudiante> estudiantes = _context.Estudiantes.ToList();
            return estudiantes;
        }

        public string Eliminar(string cedula)
        {
            try
            {
                var estudiante = _context.Estudiantes.Find(cedula);
                if (estudiante != null)
                {
                    _context.Remove(estudiante);
                    _context.SaveChanges();
                    return ($"El registro {estudiante.Nombres} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {cedula} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
        }

    }

    public class GuardarEstudianteResponse 
    {
        public GuardarEstudianteResponse(Estudiante estudiante)
        {
            Error = false;
            Estudiante = estudiante;
        }

        public GuardarEstudianteResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}