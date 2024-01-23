using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClinicEx_2024.Clases
{
    internal class CPacientes
    {
        public int guardarPacientes(
            string nombre,
            string apellidoP,
            string apellidoM,
            DateTime fechaNacimiento,
            string sexo
        )
        {
            int pacienteID = 0;

            try
            {
                CConexion obj = new CConexion();
                string query =
                    "INSERT INTO Pacientes (Nombre, ApellidoP, ApellidoM, FechaN, Sexo) VALUES (@Nombre, @ApellidoP, @ApellidoM, @FechaN, @Sexo); SELECT LAST_INSERT_ID();";
                MySqlCommand myCommand = new MySqlCommand(query, obj.establecerConexion());

                // Usar parámetros para prevenir la inyección de SQL
                myCommand.Parameters.AddWithValue("@Nombre", nombre);
                myCommand.Parameters.AddWithValue("@ApellidoP", apellidoP);
                myCommand.Parameters.AddWithValue("@ApellidoM", apellidoM);
                myCommand.Parameters.AddWithValue("@FechaN", fechaNacimiento); // Pasar la fecha de nacimiento completa
                myCommand.Parameters.AddWithValue("@Sexo", sexo);

                // Ejecutar la consulta y obtener el último ID insertado
                pacienteID = Convert.ToInt32(myCommand.ExecuteScalar());
                MessageBox.Show("Paciente agregado. ID: " + pacienteID);
                obj.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            return pacienteID;
        }

        public void guardarVisita(
            int pacienteID,
            DateTime fechaConsulta,
            string padecimientoActual,
            string antecedentesImportancia,
            string hallazgosExploracionFisica,
            string pruebasDiagnosticasRealizadas
        )
        {
            try
            {
                CConexion obj = new CConexion();
                String query =
                    "INSERT INTO Visitas (PacienteID, FechaConsulta, PadecimientoActual, AntecedentesImportancia, HallazgosExploracionFisica, PruebasDiagnosticasRealizadas) "
                    + "VALUES (@PacienteID, @FechaConsulta, @PadecimientoActual, @AntecedentesImportancia, @HallazgosExploracionFisica, @PruebasDiagnosticasRealizadas);";

                MySqlCommand myCommand = new MySqlCommand(query, obj.establecerConexion());

                myCommand.Parameters.AddWithValue("@PacienteID", pacienteID);
                myCommand.Parameters.AddWithValue("@FechaConsulta", fechaConsulta);
                myCommand.Parameters.AddWithValue("@PadecimientoActual", padecimientoActual);
                myCommand.Parameters.AddWithValue(
                    "@AntecedentesImportancia",
                    antecedentesImportancia
                );
                myCommand.Parameters.AddWithValue(
                    "@HallazgosExploracionFisica",
                    hallazgosExploracionFisica
                );
                myCommand.Parameters.AddWithValue(
                    "@PruebasDiagnosticasRealizadas",
                    pruebasDiagnosticasRealizadas
                );

                myCommand.ExecuteNonQuery();
                MessageBox.Show("Visita agregada con éxito.");
                obj.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la visita: " + ex.Message);
            }
        }

        public int buscarPaciente(
            string nombre,
            string apellidoP,
            string apellidoM,
            DateTime fechaNacimiento,
            string sexo
        )
        {
            int pacienteID = 0;
            DateTime fechaN = fechaNacimiento.Date;

            try
            {
                CConexion obj = new CConexion();
                string query =
                    "SELECT PacienteID FROM Pacientes "
                    + "WHERE Nombre = @Nombre "
                    + "AND ApellidoP = @ApellidoP "
                    + "AND ApellidoM = @ApellidoM "
                    + "AND FechaN = @FechaN "
                    + "AND Sexo = @Sexo";
                MySqlCommand myCommand = new MySqlCommand(query, obj.establecerConexion());

                myCommand.Parameters.AddWithValue("@Nombre", nombre);
                myCommand.Parameters.AddWithValue("@ApellidoP", apellidoP);
                myCommand.Parameters.AddWithValue("@ApellidoM", apellidoM);
                myCommand.Parameters.AddWithValue("@FechaN", fechaN);
                myCommand.Parameters.AddWithValue("@Sexo", sexo);

                // Ejecutar la consulta y obtener el ID del paciente
                object result = myCommand.ExecuteScalar();
                if (result != null)
                {
                    pacienteID = Convert.ToInt32(result);
                }                
                obj.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el paciente: " + ex.ToString());
            }

            return pacienteID;
        }
    }
}
