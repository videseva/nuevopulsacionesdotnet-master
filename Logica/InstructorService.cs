using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Logica
{
    public class InstructorService
    {
        private readonly PulsacionesContext _context;
        
        public InstructorService(PulsacionesContext context)
        {   
            _context=context;
        }

        public GuardarInstructorResponse Guardar(Instructor instructor)
        {
            try
            {
                _context.Instructors.Add(instructor);
                _context.SaveChanges();
                return new GuardarInstructorResponse(instructor);
            }
            catch (Exception e)
            {
                return new GuardarInstructorResponse($"Error: {e.Message}");
            }
        }

      

        public List<Instructor> Consultar()
        {
            List<Instructor> instructors = _context.Instructors.ToList();
            return instructors;
        }

        public string Eliminar(string cedula)
        {
            try
            {
                var instructor = _context.Instructors.Find(cedula);
                if (instructor != null)
                {
                    _context.Remove(instructor);
                    _context.SaveChanges();
                    return ($"El registro {instructor.Nombres} se ha eliminado satisfactoriamente.");
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

    public class GuardarInstructorResponse 
    {
        public GuardarInstructorResponse(Instructor instructor)
        {
            Error = false;
            Instructor = instructor;
        }

        public GuardarInstructorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Instructor Instructor { get; set; }
    }
}