using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicEx_2024.Clases
{
    internal class CPacientes
    {
        public int guardarPacientes(TextBox textBoxnombrep, TextBox textBoxapellidop, TextBox textBoxedadp)
        {
            int pacienteID = 0;
            int edad = int.Parse(textBoxedadp.Text);
            try
            {
                CConexion obj = new CConexion();
                String query = "INSERT INTO Pacientes (Nombre,Apellido,Edad) VALUES (@Nombre, @Apellido, @Edad); SELECT LAST_INSERT_ID();";
                MySqlCommand myCommand = new MySqlCommand(query, obj.establecerConexion());

                // Usar parámetros para prevenir la inyección de SQL
                myCommand.Parameters.AddWithValue("@Nombre", textBoxnombrep.Text);
                myCommand.Parameters.AddWithValue("@Apellido", textBoxapellidop.Text);
                myCommand.Parameters.AddWithValue("@Edad", edad);

                // Ejecutar la consulta y obtener el último ID insertado
                pacienteID = Convert.ToInt32(myCommand.ExecuteScalar());
                MessageBox.Show("Paciente agregado. ID: " + pacienteID);
                obj.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.ToString());
            }
            return pacienteID;
        }

        public void guardarVisita(int pacienteID, DateTime fechaConsulta, string padecimientoActual, string antecedentesImportancia, string hallazgosExploracionFisica, string pruebasDiagnosticasRealizadas)
        {
            try
            {
                CConexion obj = new CConexion();
                String query = "INSERT INTO Visitas (PacienteID, FechaConsulta, PadecimientoActual, AntecedentesImportancia, HallazgosExploracionFisica, PruebasDiagnosticasRealizadas) " +
                    "VALUES (@PacienteID, @FechaConsulta, @PadecimientoActual, @AntecedentesImportancia, @HallazgosExploracionFisica, @PruebasDiagnosticasRealizadas);";

                MySqlCommand myCommand = new MySqlCommand(query, obj.establecerConexion());

                
                myCommand.Parameters.AddWithValue("@PacienteID", pacienteID);
                myCommand.Parameters.AddWithValue("@FechaConsulta", fechaConsulta);
                myCommand.Parameters.AddWithValue("@PadecimientoActual", padecimientoActual);
                myCommand.Parameters.AddWithValue("@AntecedentesImportancia", antecedentesImportancia);
                myCommand.Parameters.AddWithValue("@HallazgosExploracionFisica", hallazgosExploracionFisica);
                myCommand.Parameters.AddWithValue("@PruebasDiagnosticasRealizadas", pruebasDiagnosticasRealizadas);

                myCommand.ExecuteNonQuery();
                MessageBox.Show("Visita agregada con éxito.");
                obj.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la visita: " + ex.Message);
            }
        }
    }
}
