using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Logica
{
    public class AdministradorServices
    {
        private readonly PulsacionesContext _context;
        
        public AdministradorServices(PulsacionesContext context)
        {   
            _context=context;
        }

        public GuardarAdministradorResponse Guardar(Administrador administrador)
        {
            try
            {
                _context.Administradors.Add(administrador);
                _context.SaveChanges();
                return new GuardarAdministradorResponse(administrador);
            }
            catch (Exception e)
            {
                return new GuardarAdministradorResponse($"Error: {e.Message}");
            }
        }

        public List<Administrador> Consultar()
        {
            List<Administrador> administradors = _context.Administradors.ToList();
            return administradors;
        }

        public string Eliminar(string cedula)
        {
            try
            {
                var administrador = _context.Administradors.Find(cedula);
                if (administrador != null)
                {
                    _context.Remove(administrador);
                    _context.SaveChanges();
                    return ($"El registro {administrador.Nombres} se ha eliminado satisfactoriamente.");
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

    public class GuardarAdministradorResponse 
    {
        public GuardarAdministradorResponse(Administrador administrador)
        {
            Error = false;
            Administrador = administrador;
        }

        public GuardarAdministradorResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Administrador Administrador { get; set; }
    }
}