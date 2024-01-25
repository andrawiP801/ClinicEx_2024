using System;
using MySql.Data.MySqlClient;

namespace ClinicEx_2024.Clases
{
    internal class CPacientes
    {
        private CConexion conexion = new CConexion();

        private MySqlCommand PrepararComando(string query, params (string, object)[] parametros)
        {
            var cmd = new MySqlCommand(query, conexion.establecerConexion());
            foreach (var (nombre, valor) in parametros)
            {
                cmd.Parameters.AddWithValue(nombre, valor);
            }
            return cmd;
        }

        public int GuardarPaciente(
            string nombre,
            string apellidoP,
            string apellidoM,
            DateTime fechaNacimiento,
            string sexo
        )
        {
            try
            {
                string query =
                    "INSERT INTO Pacientes (Nombre, ApellidoP, ApellidoM, FechaN, Sexo) VALUES (@Nombre, @ApellidoP, @ApellidoM, @FechaN, @Sexo); SELECT LAST_INSERT_ID();";
                var cmd = PrepararComando(
                    query,
                    ("@Nombre", nombre),
                    ("@ApellidoP", apellidoP),
                    ("@ApellidoM", apellidoM),
                    ("@FechaN", fechaNacimiento),
                    ("@Sexo", sexo)
                );

                int pacienteID = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show($"Paciente agregado. ID: {pacienteID}");
                return pacienteID;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return 0;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void GuardarConsulta(
            int pacienteID,
            DateTime fechaConsulta,
            string presionArterial,
            decimal temperatura,
            int frecuenciaCardiaca,
            int frecuenciaRespiratoria,
            decimal peso,
            decimal talla,
            decimal imc,
            decimal circunferenciaCintura,
            decimal saturacionOxigeno,
            decimal glucemia,
            string alergias,
            string padecimientoActual,
            string antecedentesImportancia,
            string hallazgosExploracionFisica,
            string pruebasDiagnosticasRealizadas,
            string diagnostico,
            string tratamiento,
            string pronostico
        )
        {
            try
            {
                string query =
                    "INSERT INTO Consultas (ID_Paciente, FechaConsulta, PresionArterial, Temperatura, FrecuenciaCardiaca, FrecuenciaRespiratoria, Peso, Talla, IMC, CircunferenciaCintura, SaturacionOxigeno, Glucemia, Alergias, PadecimientoActual, AntecedentesImportancia, HallazgosExploracionFisica, PruebasDiagnosticasRealizadas, Diagnostico, Tratamiento, Pronostico) "
                    + "VALUES (@PacienteID, @FechaConsulta, @PresionArterial, @Temperatura, @FrecuenciaCardiaca, @FrecuenciaRespiratoria, @Peso, @Talla, @IMC, @CircunferenciaCintura, @SaturacionOxigeno, @Glucemia, @Alergias, @PadecimientoActual, @AntecedentesImportancia, @HallazgosExploracionFisica, @PruebasDiagnosticasRealizadas, @Diagnostico, @Tratamiento, @Pronostico);";

                var cmd = PrepararComando(
                    query,
                    ("@PacienteID", pacienteID),
                    ("@FechaConsulta", fechaConsulta),
                    ("@PresionArterial", presionArterial),
                    ("@Temperatura", temperatura),
                    ("@FrecuenciaCardiaca", frecuenciaCardiaca),
                    ("@FrecuenciaRespiratoria", frecuenciaRespiratoria),
                    ("@Peso", peso),
                    ("@Talla", talla),
                    ("@IMC", imc),
                    ("@CircunferenciaCintura", circunferenciaCintura),
                    ("@SaturacionOxigeno", saturacionOxigeno),
                    ("@Glucemia", glucemia),
                    ("@Alergias", alergias),
                    ("@PadecimientoActual", padecimientoActual),
                    ("@AntecedentesImportancia", antecedentesImportancia),
                    ("@HallazgosExploracionFisica", hallazgosExploracionFisica),
                    ("@PruebasDiagnosticasRealizadas", pruebasDiagnosticasRealizadas),
                    ("@Diagnostico", diagnostico),
                    ("@Tratamiento", tratamiento),
                    ("@Pronostico", pronostico)
                );

                cmd.ExecuteNonQuery();
                MessageBox.Show("Consulta agregada con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la Consulta: {ex.Message}");
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public int BuscarPaciente(
            string nombre,
            string apellidoP,
            string apellidoM,
            DateTime fechaNacimiento
        )
        {
            try
            {
                string query =
                    "SELECT ID_Paciente FROM Pacientes WHERE Nombre = @Nombre AND ApellidoP = @ApellidoP AND ApellidoM = @ApellidoM AND FechaN = @FechaN";
                var cmd = PrepararComando(
                    query,
                    ("@Nombre", nombre),
                    ("@ApellidoP", apellidoP),
                    ("@ApellidoM", apellidoM),
                    ("@FechaN", fechaNacimiento.Date)
                );

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el paciente: {ex}");
                return 0;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public Paciente ObtenerDatosPaciente(int id)
        {
            try
            {
                string query = "SELECT ApellidoM, Sexo FROM Pacientes WHERE ID_Paciente = @id";
                var cmd = PrepararComando(query, ("@id", id));

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Paciente
                        {
                            ApellidoM = reader.GetString(0),
                            Sexo = reader.GetString(1)
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos del paciente: {ex}");
                return null;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public class Paciente
        {
            public string ApellidoM { get; set; }
            public string Sexo { get; set; }
        }
    }
}
