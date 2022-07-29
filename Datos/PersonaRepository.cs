using System;
using Entidad;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class PersonaRepository
    {
        //private readonly SqlConnection _connection;
        private readonly MySqlConnection _connection;
        private readonly List<Persona> _personas = new List<Persona>();
        public PersonaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Persona persona)
        {
            persona.CalcularPulsaciones();
             string sql = @"Insert Into Persona (Identificacion,Nombre,Edad, Sexo, Pulsacion) 
                                        values (@Identificacion,@Nombre,@Edad,@Sexo,@Pulsacion)";
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
            cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
            cmd.Parameters.AddWithValue("@Sexo", persona.Sexo);
            cmd.Parameters.AddWithValue("@Edad", persona.Edad);
            cmd.Parameters.AddWithValue("@Pulsacion", persona.Pulsacion);
            cmd.ExecuteNonQuery();

           /* using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona (Identificacion,Nombre,Edad, Sexo, Pulsacion) 
                                        values (@Identificacion,@Nombre,@Edad,@Sexo,@Pulsacion)";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Sexo", persona.Sexo);
                command.Parameters.AddWithValue("@Edad", persona.Edad);
                command.Parameters.AddWithValue("@Pulsacion", persona.Pulsacion);
                var filas = command.ExecuteNonQuery();
            }*/
        }
        public void Eliminar(Persona persona)
        {   
             string sql = "Delete from persona where Identificacion=@Identificacion";
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
            cmd.ExecuteNonQuery();

            /*using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }*/
        }
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = new List<Persona>();
            string sql = "Select * from persona";
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Persona persona = DataReaderMapToPerson(rdr);
                personas.Add(persona);
            }

            /*
            SqlDataReader dataReader;
            List<Persona> personas = new List<Persona>();
           /* using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from persona ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }*/
            return personas;
        }
        public Persona BuscarPorIdentificacion(string identificacion)
        {
            string sql = "select * from persona where Identificacion=@Identificacion";
            MySqlCommand cmd = new MySqlCommand(sql, _connection);
            cmd.Parameters.AddWithValue("@Identificacion", identificacion);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return DataReaderMapToPerson(rdr);
            
           /** SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }*/
        }
        private Persona DataReaderMapToPerson(MySqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Persona persona = new Persona();
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.Sexo = (string)dataReader["Sexo"];
            persona.Edad = (int)dataReader["Edad"];
            return persona;
        }
        public int Totalizar()
        {
            return _personas.Count();
        }
        public int TotalizarMujeres()
        {
            ConsultarTodos();
            return _personas.Where(p => p.Sexo.Equals("F")).Count();
        }
        public int TotalizarHombres()
        {
            ConsultarTodos();
            return _personas.Where(p => p.Sexo.Equals("M")).Count();
        }
    }
}
