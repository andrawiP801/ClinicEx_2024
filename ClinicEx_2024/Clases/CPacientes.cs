using System;
using System.Data;
using MySql.Data.MySqlClient;
using static ClinicEx_2024.Clases.CPacientes;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                cmd.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
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

        public int GuardarConsulta(
            int pacienteID,
            DateTime fechaConsulta,
            string presionArterial,
            decimal temperatura,
            int frecuenciaCardiaca,
            int frecuenciaRespiratoria,
            decimal peso,
            decimal talla,
            decimal imc,
            decimal? circunferenciaCintura,
            decimal saturacionOxigeno,
            decimal? glucemia,
            string alergias,
            string estadoN,
            string padecimientoActual,
            string antecedentesImportancia,
            string hallazgosExploracionFisica,
            string pruebasDiagnosticasRealizadas,
            string diagnostico,
            string tratamiento,
            string pronostico
        )
        {
            int idConsulta = 0;
            try
            {
                string query =
                    "INSERT INTO Consultas (ID_Paciente, FechaConsulta, PresionArterial, Temperatura, FrecuenciaCardiaca, FrecuenciaRespiratoria, Peso, Talla, IMC, CircunferenciaCintura, SaturacionOxigeno, Glucemia, Alergias, EstadoNutricional, PadecimientoActual, AntecedentesImportancia, HallazgosExploracionFisica, PruebasDiagnosticasRealizadas, Diagnostico, Tratamiento, Pronostico) "
                    + "VALUES (@ID_Paciente, @FechaConsulta, @PresionArterial, @Temperatura, @FrecuenciaCardiaca, @FrecuenciaRespiratoria, @Peso, @Talla, @IMC, @CircunferenciaCintura, @SaturacionOxigeno, @Glucemia, @Alergias, @EstadoN, @PadecimientoActual, @AntecedentesImportancia, @HallazgosExploracionFisica, @PruebasDiagnosticasRealizadas, @Diagnostico, @Tratamiento, @Pronostico);";

                var cmd = PrepararComando(
                    query,
                    ("@ID_Paciente", pacienteID),
                    ("@FechaConsulta", fechaConsulta),
                    (
                        "@PresionArterial",
                        string.IsNullOrEmpty(presionArterial)
                            ? DBNull.Value
                            : (object)presionArterial
                    ),
                    ("@Temperatura", temperatura),
                    ("@FrecuenciaCardiaca", frecuenciaCardiaca),
                    ("@FrecuenciaRespiratoria", frecuenciaRespiratoria),
                    ("@Peso", peso),
                    ("@Talla", talla),
                    ("@IMC", imc),
                    (
                        "@CircunferenciaCintura",
                        circunferenciaCintura.HasValue ? (object)circunferenciaCintura.Value : 0m
                    ),
                    ("@SaturacionOxigeno", saturacionOxigeno),
                    ("@Glucemia", glucemia.HasValue ? (object)glucemia.Value : 0m),
                    ("@Alergias", alergias),
                    ("@EstadoN", estadoN),
                    ("@PadecimientoActual", padecimientoActual),
                    ("@AntecedentesImportancia", antecedentesImportancia),
                    ("@HallazgosExploracionFisica", hallazgosExploracionFisica),
                    (
                        "@PruebasDiagnosticasRealizadas",
                        string.IsNullOrEmpty(pruebasDiagnosticasRealizadas)
                            ? DBNull.Value
                            : (object)pruebasDiagnosticasRealizadas
                    ),
                    ("@Diagnostico", diagnostico),
                    ("@Tratamiento", tratamiento),
                    (
                        "@Pronostico",
                        string.IsNullOrEmpty(pronostico) ? DBNull.Value : (object)pronostico
                    )
                );
                cmd.ExecuteNonQuery();
                MessageBox.Show("Consulta agregada con éxito.");
                string queryGetId = "SELECT LAST_INSERT_ID();";
                var cmdGetId = PrepararComando(queryGetId);
                idConsulta = Convert.ToInt32(cmdGetId.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la Consulta: {ex.Message}");
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return idConsulta;
        }

        public int BuscarPaciente(
            string nombre,
            string apellidoP,            
            DateTime fechaNacimiento
        )
        {
            try
            {
                string query =
                    "SELECT ID_Paciente FROM Pacientes WHERE Nombre = @Nombre AND ApellidoP = @ApellidoP AND FechaN = @FechaN";
                var cmd = PrepararComando(
                    query,
                    ("@Nombre", nombre),
                    ("@ApellidoP", apellidoP),                    
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

        public DataTable GetConsultasPorPaciente(int idPaciente)
        {
            DataTable consultas = new DataTable();

            try
            {
                string query =
                    @"
            SELECT p.Nombre, c.FechaConsulta 
            FROM Consultas AS c
            JOIN Pacientes AS p ON c.ID_Paciente = p.ID_Paciente
            WHERE c.ID_Paciente = @idPaciente";

                var cmd = PrepararComando(query, ("@idPaciente", idPaciente));

                using (var reader = cmd.ExecuteReader())
                {
                    consultas.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar las consultas del paciente: {ex.Message}");
            }
            finally
            {
                conexion.cerrarConexion();
            }

            return consultas;
        }

        public int GuardarImagen(byte[] imageBytes)
        {
            try
            {
                string query =
                    "INSERT INTO Imagenes (Imagen) VALUES (@Imagen); SELECT LAST_INSERT_ID();";
                var cmd = PrepararComando(query, ("@Imagen", imageBytes));
                int newImageId = Convert.ToInt32(cmd.ExecuteScalar());
                return newImageId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la imagen: {ex.Message}");
                return 0;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        // Excepción personalizada
        public class SinImagenesException : Exception
        {
            public SinImagenesException(string message) : base(message) { }
        }

        public List<int> ObtenerIDsImagenesNoRegistradas()
        {
            List<int> idsImagenes = new List<int>();
            try
            {
                string query = "SELECT ID_Imagen FROM Imagenes WHERE ID_Imagen NOT IN (SELECT ID_Imagen FROM Expediente)";
                var cmd = PrepararComando(query);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idsImagenes.Add(reader.GetInt32(0));
                    }
                }

                if (idsImagenes.Count == 0)
                {
                    throw new SinImagenesException("No se encontraron imágenes registradas");
                }
            }
            catch (Exception ex)
            {
                throw; 
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return idsImagenes;
        }

        public void ActualizarExpediente(int idConsulta)
        {
            try
            {
                List<int> idsImagenes = ObtenerIDsImagenesNoRegistradas();

                if (idConsulta > 0)
                {
                    foreach (int idImagen in idsImagenes)
                    {
                        string query = "INSERT INTO Expediente (ID_Consulta, ID_Imagen) VALUES (@ID_Consulta, @ID_Imagen);";
                        var cmd = PrepararComando(query, ("@ID_Consulta", idConsulta), ("@ID_Imagen", idImagen));
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("El ID de la consulta no es válido.");
                }
            }
            catch (SinImagenesException sinImgEx)
            {
                MessageBox.Show(sinImgEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el expediente con las imágenes: {ex.Message}");
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

    }
}
