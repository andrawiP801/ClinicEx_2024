using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ClinicEx_2024.Clases;
using ClinicEx_2024.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using static ClinicEx_2024.Clases.CPacientes;

namespace ClinicEx_2024
{
    public partial class MainForm : Form
    {
        // Propiedades
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public DateTime FechaConsulta { get; set; }

        // Declaraciones de controles
        private Label labelNombre,
            labelGral,
            labelDireccion,
            datoIMC;
        private TextBox textBoxPresionArterial,
            textBoxTemperatura,
            textBoxFrecuenciaCardiaca,
            textBoxFrecuenciaRespiratoria,
            textBoxCintura,
            textBoxSaturacion,
            textBoxGlucemia,
            textBoxAlergias,
            textBoxNombreP,
            textBoxApellidoP,
            textBoxApellidoM,
            comboBoxSexo,
            textBoxPeso,
            textBoxTalla,
            textBoxPadecimientoActual,
            textBoxAntecedentesImportancia,
            textBoxHallazgos,
            textBoxPruebasDiag,
            textBoxDiagnostico,
            textBoxTratamiento,
            textBoxPronostico,
            textBoxEdad;
        private Button agregarButton,
            imprimirButton,
            photoUploadButton;
        private DateTimePicker dateTimePickerConsulta;
        private Image logoImage = Resources.Logo;
        private int idConsulta;

        public MainForm()
        {
            InitializeComponent();
            CustomizeForm();
            SubscribeToEvents();
        }

        private void InitializeComponent()
        {
            this.Size = new Size(1300, 700);
            this.AutoScroll = true;
            this.SetAutoScrollMargin(0, 10);
            this.Text = "Registro de Expediente Médico";

            AddControls();
        }

        private void CustomizeForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightBlue;
            this.Icon = Properties.Resources.Icono;

            ChangeFontOfLabels(this, "Century", 10);
            labelNombre.Font = new Font("Century", 15, FontStyle.Bold);
            labelGral.Font = new Font("Century", 15, FontStyle.Bold);
        }

        private void SubscribeToEvents()
        {
            // Suscripción a eventos del formulario
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
            this.Layout += new LayoutEventHandler(Form1_Layout);

            // Suscripción a eventos de los botones
            agregarButton.Click += Agregar_Click;
            imprimirButton.Click += Imprimir_Click;
        }

        private void AddControls()
        {
            // Creación y configuración de Labels
            labelNombre = CreateLabel("Consultorio San Francisco", new Point(5, 5), true);
            labelGral = CreateLabel("\"Medicina General\"", new Point(5, 30), true);
            labelDireccion = CreateLabel(
                "Av. Hidalgo 67 Tequexquináhuac, Texcoco",
                new Point(5, 55),
                true
            );
            Label labelNombreP = CreateLabel("Nombre", new Point(450, 105), true);
            Label labelApellidoP = CreateLabel("Apellido Paterno", new Point(590, 105), true);
            Label labelApellidoM = CreateLabel("Apellido Materno", new Point(750, 105), true);
            Label labelEdad = CreateLabel("Edad", new Point(930, 105), true);
            Label labelSexo = CreateLabel("Sexo", new Point(1010, 105), true);
            Label labelFechaConsulta = CreateLabel("Fecha de consulta", new Point(10, 105), true);
            Label labelSignosVitales = CreateLabel("Signos vitales", new Point(10, 180), true);
            Label labelPresionArterial = CreateLabel("Presión arterial", new Point(20, 210), true);
            Label labelTemperatura = CreateLabel("Temperatura", new Point(180, 210), true);
            Label labelFrecuenciaCardiaca = CreateLabel(
                "Frecuencia Cardiaca",
                new Point(330, 210),
                true
            );
            Label labelFrecuenciaRespiratoria = CreateLabel(
                "Frecuencia Respiratoria",
                new Point(540, 210),
                true
            );
            Label labelPeso = CreateLabel("Peso (kg)", new Point(760, 210), true);
            Label labelTalla = CreateLabel("Talla (cm)", new Point(880, 210), true);
            Label labelIMC = CreateLabel("IMC", new Point(1010, 210), true);
            datoIMC = CreateLabel(Text = "--", new Point(1010, 240), true);
            Label labelCintura = CreateLabel(
                "Circunferencia de cintura (cm)",
                new Point(20, 310),
                true
            );
            Label labelSaturacion = CreateLabel("Saturación de oxígeno", new Point(280, 310), true);
            Label labelGlucemia = CreateLabel("Glucemia", new Point(495, 310), true);
            Label labelAlergias = CreateLabel("Alergias", new Point(640, 310), true);
            Label lineSV = CreateSeparator(new Point(0, 190), this.Width);
            Label photoLabel = CreateLabel("Estudios", new Point(1100, 210), true);
            Label labelNotaMedica = CreateLabel("Nota médica", new Point(10, 400), true);
            Label lineNM = CreateSeparator(new Point(0, 410), this.Width);
            Label labelPadecimientoActual = CreateLabel(
                "Padecimiento actual",
                new Point(10, 430),
                true
            );
            Label labelAntecedentesImportancia = CreateLabel(
                "Antecedentes de importancia",
                new Point(10, 570),
                true
            );
            Label labelHallazgos = CreateLabel(
                "Hallazgos en exploración física",
                new Point(10, 710),
                true
            );
            Label labelPruebasDiag = CreateLabel(
                "Pruebas diagnósticas realizadas",
                new Point(10, 850),
                true
            );
            Label labelDiagnostico = CreateLabel("Diagnóstico", new Point(10, 990), true);
            Label labelTratamiento = CreateLabel("Tratamiento", new Point(10, 1130), true);
            Label labelPronostico = CreateLabel("Pronóstico", new Point(10, 1270), true);
            Label labelMedico = CreateLabel("Médico", new Point(10, 1430), true);
            Label lineMed = CreateSeparator(new Point(0, 1440), this.Width);
            Label labelDatoNom = CreateLabel("Nombre del Médico", new Point(25, 1460), true);
            Label labelDatoCed = CreateLabel("Cédula Profesional", new Point(600, 1460), true);
            Label labelNombreMedico = CreateLabel(
                "FABIOLA ALEJANDRA MARQUEZ CADENA",
                new Point(25, 1485),
                true
            );
            Label labelCedulaPro = CreateLabel("4443217", new Point(600, 1485), true);

            // Creación de TextBoxes
            textBoxNombreP = CreateTextBox(new Point(450, 135), new Size(100, 50), false, Nombre);
            textBoxApellidoP = CreateTextBox(
                new Point(590, 135),
                new Size(111, 50),
                false,
                ApellidoPaterno
            );
            textBoxApellidoM = CreateTextBox(
                new Point(750, 135),
                new Size(115, 50),
                false,
                ApellidoMaterno
            );
            textBoxEdad = CreateTextBox(
                new Point(930, 135),
                new Size(42, 50),
                false,
                Edad.ToString()
            );
            comboBoxSexo = CreateTextBox(new Point(1010, 135), new Size(100, 20), false, Sexo);
            textBoxPresionArterial = CreateTextBox(new Point(20, 240), new Size(105, 20), true, "");
            textBoxTemperatura = CreateTextBox(new Point(180, 240), new Size(89, 20), true, "");
            textBoxFrecuenciaCardiaca = CreateTextBox(
                new Point(330, 240),
                new Size(138, 20),
                true,
                ""
            );
            textBoxFrecuenciaRespiratoria = CreateTextBox(
                new Point(540, 240),
                new Size(158, 20),
                true,
                ""
            );
            textBoxPeso = CreateTextBox(new Point(760, 240), new Size(62, 20), true, "");
            textBoxTalla = CreateTextBox(new Point(880, 240), new Size(67, 20), true, "");
            textBoxCintura = CreateTextBox(new Point(20, 340), new Size(200, 20), true, "");
            textBoxSaturacion = CreateTextBox(new Point(280, 340), new Size(147, 20), true, "");
            textBoxGlucemia = CreateTextBox(new Point(495, 340), new Size(65, 20), true, "");
            textBoxAlergias = CreateTextBox(new Point(640, 340), new Size(350, 20), true, "");

            textBoxPadecimientoActual = CreateMultilineTextBox(
                new Point(10, 460),
                new Size(650, 100)
            );
            textBoxAntecedentesImportancia = CreateMultilineTextBox(
                new Point(10, 600),
                new Size(650, 100)
            );
            textBoxHallazgos = CreateMultilineTextBox(new Point(10, 740), new Size(760, 100));
            textBoxPruebasDiag = CreateMultilineTextBox(new Point(10, 880), new Size(760, 100));
            textBoxDiagnostico = CreateMultilineTextBox(new Point(10, 1020), new Size(760, 100));
            textBoxTratamiento = CreateMultilineTextBox(new Point(10, 1160), new Size(760, 100));
            textBoxPronostico = CreateMultilineTextBox(new Point(10, 1300), new Size(760, 100));

            // Eventos para TextBoxes
            textBoxPeso.TextChanged += (sender, e) => CalcularIMC();
            textBoxTalla.TextChanged += (sender, e) => CalcularIMC();

            // Creación de otros controles
            agregarButton = CreateButton("Agregar", new Point(1000, 1470), new Size(100, 50));
            imprimirButton = CreateButton("Imprimir", new Point(1150, 1470), new Size(100, 50));
            dateTimePickerConsulta = CreateDateTimePicker(
                new Point(10, 135),
                new Size(120, 50),
                DateTimePickerFormat.Short
            );
            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(75, 75),
                Location = new Point(5, 5),
                Image = logoImage,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            photoUploadButton = CreateButton(
                "Selecciona foto",
                new Point(1100, 240),
                new Size(150, 50)
            );
            photoUploadButton.Click += (sender, e) => UploadPhotoButton_Click();            

            // Agregar controles al formulario
            this.Controls.AddRange(
                new Control[]
                {
                    labelNombre,
                    labelGral,
                    labelDireccion,
                    labelNombreP,
                    labelApellidoP,
                    labelApellidoM,
                    labelEdad,
                    labelSexo,
                    labelFechaConsulta,
                    dateTimePickerConsulta,
                    labelSignosVitales,
                    labelPresionArterial,
                    labelTemperatura,
                    labelFrecuenciaCardiaca,
                    labelFrecuenciaRespiratoria,
                    labelPeso,
                    labelTalla,
                    labelIMC,
                    datoIMC,
                    labelCintura,
                    labelSaturacion,
                    labelGlucemia,
                    labelAlergias,
                    textBoxNombreP,
                    textBoxApellidoP,
                    textBoxApellidoM,
                    textBoxEdad,
                    comboBoxSexo,
                    textBoxPresionArterial,
                    textBoxTemperatura,
                    textBoxFrecuenciaCardiaca,
                    textBoxFrecuenciaRespiratoria,
                    textBoxPeso,
                    textBoxTalla,
                    textBoxCintura,
                    textBoxSaturacion,
                    textBoxGlucemia,
                    textBoxAlergias,
                    pictureBox,
                    lineSV,
                    photoLabel,
                    labelNotaMedica,
                    lineNM,
                    labelPadecimientoActual,
                    labelAntecedentesImportancia,
                    labelHallazgos,
                    labelPruebasDiag,
                    labelDiagnostico,
                    labelTratamiento,
                    labelPronostico,
                    labelMedico,
                    lineMed,
                    labelDatoNom,
                    labelDatoCed,
                    labelNombreMedico,
                    labelCedulaPro,
                    photoUploadButton,
                    textBoxPadecimientoActual,
                    textBoxAntecedentesImportancia,
                    textBoxHallazgos,
                    textBoxPruebasDiag,
                    textBoxDiagnostico,
                    textBoxTratamiento,
                    textBoxPronostico,
                    agregarButton,
                    imprimirButton                    
                }
            );
        }

        private Label CreateLabel(string text, Point location, bool autoSize)
        {
            return new Label
            {
                Text = text,
                Location = location,
                AutoSize = autoSize
            };
        }

        private TextBox CreateTextBox(Point location, Size size, bool enabled, string text)
        {
            return new TextBox
            {
                Location = location,
                Size = size,
                Enabled = enabled,
                Text = text
            };
        }

        private Button CreateButton(string text, Point location, Size size)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = size
            };
        }

        private DateTimePicker CreateDateTimePicker(
            Point location,
            Size size,
            DateTimePickerFormat format
        )
        {
            return new DateTimePicker
            {
                Location = location,
                Size = size,
                Format = format
            };
        }

        private Label CreateSeparator(Point location, int width)
        {
            return new Label
            {
                AutoSize = false,
                Height = 2,
                BorderStyle = BorderStyle.Fixed3D,
                Width = width,
                Location = location,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
        }

        private TextBox CreateMultilineTextBox(Point location, Size size)
        {
            return new TextBox
            {
                Multiline = true,
                Location = location,
                Size = size
            };
        }

        private void ChangeFontOfLabels(Control parent, string fontName, float size)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label label)
                {
                    label.Font = new Font(fontName, size, label.Font.Style);
                }
                if (control.HasChildren)
                {
                    ChangeFontOfLabels(control, fontName, size);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxNombreP.Text = this.Nombre;
            textBoxApellidoP.Text = this.ApellidoPaterno;
            textBoxApellidoM.Text = this.ApellidoMaterno;
            comboBoxSexo.Text = this.Sexo;
            textBoxEdad.Text = this.Edad.ToString();

            if (this.FechaConsulta != DateTime.MinValue)
            {
                int PacienteID = this.PacienteID;
                dateTimePickerConsulta.Value = this.FechaConsulta;
                this.CargarDatosConsulta(PacienteID, FechaConsulta);
                photoUploadButton.Text = "Mostrar fotos";
            }
            else
            {
                dateTimePickerConsulta.Value = DateTime.Now;
            }
        }

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

        public void CargarDatosConsulta(int pacienteID, DateTime fechaConsulta)
        {
            string query =
                "SELECT * FROM Consultas WHERE ID_Paciente = @ID_Paciente AND FechaConsulta = @FechaConsulta LIMIT 1";

            var cmd = PrepararComando(query);
            cmd.Parameters.AddWithValue("@ID_Paciente", pacienteID);
            cmd.Parameters.AddWithValue("@FechaConsulta", fechaConsulta);

            try
            {
                conexion.establecerConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idConsulta = int.Parse(reader["ID_Consulta"].ToString());
                        textBoxPresionArterial.Text = reader["PresionArterial"].ToString();
                        textBoxTemperatura.Text = reader["Temperatura"].ToString();
                        textBoxFrecuenciaCardiaca.Text = reader["FrecuenciaCardiaca"].ToString();
                        textBoxFrecuenciaRespiratoria.Text = reader[
                            "FrecuenciaRespiratoria"
                        ].ToString();
                        textBoxPeso.Text = reader["Peso"].ToString();
                        textBoxTalla.Text = reader["Talla"].ToString();
                        datoIMC.Text = reader["IMC"].ToString();
                        textBoxCintura.Text = reader["CircunferenciaCintura"].ToString();
                        textBoxSaturacion.Text = reader["SaturacionOxigeno"].ToString();
                        textBoxGlucemia.Text = reader["Glucemia"].ToString();
                        textBoxAlergias.Text = reader["Alergias"].ToString();
                        textBoxPadecimientoActual.Text = reader["PadecimientoActual"].ToString();
                        textBoxAntecedentesImportancia.Text = reader[
                            "AntecedentesImportancia"
                        ].ToString();
                        textBoxHallazgos.Text = reader["HallazgosExploracionFisica"].ToString();
                        textBoxPruebasDiag.Text = reader[
                            "PruebasDiagnosticasRealizadas"
                        ].ToString();
                        textBoxDiagnostico.Text = reader["Diagnostico"].ToString();
                        textBoxTratamiento.Text = reader["Tratamiento"].ToString();
                        textBoxPronostico.Text = reader["Pronostico"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No data found for the given patient ID and date.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading consultation data: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        private void CalcularIMC()
        {
            if (
                double.TryParse(textBoxPeso.Text, out double peso)
                && double.TryParse(textBoxTalla.Text, out double talla)
            )
            {
                if (talla > 0)
                {
                    double tallaEnMetros = talla / 100;
                    double imc = peso / (Math.Pow(tallaEnMetros, 2));
                    datoIMC.Text = imc.ToString("0.00");
                }
            }
            else
            {
                datoIMC.Text = "--";
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaConsulta = DateTime.Now; // O usa un DateTimePicker si la fecha no es la actual
                string presionArterial = textBoxPresionArterial.Text;
                decimal temperatura = decimal.Parse(textBoxTemperatura.Text);
                int frecuenciaCardiaca = int.Parse(textBoxFrecuenciaCardiaca.Text);
                int frecuenciaRespiratoria = int.Parse(textBoxFrecuenciaRespiratoria.Text);
                decimal peso = decimal.Parse(textBoxPeso.Text);
                decimal talla = decimal.Parse(textBoxTalla.Text);
                decimal imc = decimal.Parse(datoIMC.Text); // Asegúrate de que esto es un decimal
                decimal circunferenciaCintura = string.IsNullOrEmpty(textBoxCintura.Text)
                    ? 0
                    : decimal.Parse(textBoxCintura.Text);
                decimal saturacionOxigeno = decimal.Parse(textBoxSaturacion.Text);
                decimal glucemia = string.IsNullOrEmpty(textBoxGlucemia.Text)
                    ? 0
                    : decimal.Parse(textBoxGlucemia.Text);
                string alergias = textBoxAlergias.Text;
                string padecimientoActual = textBoxPadecimientoActual.Text;
                string antecedentesImportancia = textBoxAntecedentesImportancia.Text;
                string hallazgosExploracionFisica = textBoxHallazgos.Text;
                string pruebasDiagnosticasRealizadas = textBoxPruebasDiag.Text;
                string diagnostico = textBoxDiagnostico.Text;
                string tratamiento = textBoxTratamiento.Text;
                string pronostico = textBoxPronostico.Text;

                CPacientes pacientes = new CPacientes();
                int idConsulta = pacientes.GuardarConsulta(
                    this.PacienteID,
                    fechaConsulta,
                    presionArterial,
                    temperatura,
                    frecuenciaCardiaca,
                    frecuenciaRespiratoria,
                    peso,
                    talla,
                    imc,
                    circunferenciaCintura,
                    saturacionOxigeno,
                    glucemia,
                    alergias,
                    padecimientoActual,
                    antecedentesImportancia,
                    hallazgosExploracionFisica,
                    pruebasDiagnosticasRealizadas,
                    diagnostico,
                    tratamiento,
                    pronostico
                );
                if (idConsulta > 0)
                {
                    pacientes.ActualizarExpediente(idConsulta);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la consulta: " + ex.Message);
            }
        }

        private void CambiarFuenteLabels(
            Control controlPadre,
            string nombreFuente,
            float nuevoTamano
        )
        {
            foreach (Control control in controlPadre.Controls)
            {
                if (control is Label label)
                {
                    label.Font = new Font(nombreFuente, nuevoTamano, label.Font.Style);
                }
                if (control.HasChildren)
                {
                    CambiarFuenteLabels(control, nombreFuente, nuevoTamano);
                }
            }
        }

        private void AjustarAnchoTextBox(TextBox textBox)
        {
            int margenDerecho = 150 + this.Padding.Right;
            textBox.Width = this.ClientSize.Width - textBox.Location.X - margenDerecho;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            AjustarAnchoTextBox(textBoxPadecimientoActual);
            AjustarAnchoTextBox(textBoxAntecedentesImportancia);
            AjustarAnchoTextBox(textBoxHallazgos);
            AjustarAnchoTextBox(textBoxPruebasDiag);
            AjustarAnchoTextBox(textBoxDiagnostico);
            AjustarAnchoTextBox(textBoxTratamiento);
            AjustarAnchoTextBox(textBoxPronostico);
        }

        private void Form1_Layout(object sender, LayoutEventArgs e)
        {
            labelNombre.Location = new Point((this.ClientSize.Width - labelNombre.Width) / 2, 10);
            labelGral.Location = new Point((this.ClientSize.Width - labelGral.Width) / 2, 35);
            labelDireccion.Location = new Point(
                (this.ClientSize.Width - labelDireccion.Width) / 2,
                60
            );
        }

        private void UploadPhotoButton_Click()
        {
            if (photoUploadButton.Text == "Selecciona foto")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter =
                        "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                    openFileDialog.Title = "Selecciona foto";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        ImageForm imageForm = new ImageForm(filePath);
                        imageForm.Show();
                    }
                }
            }
            else if (photoUploadButton.Text == "Mostrar fotos")
            {
                var images = GetImagesFromDatabase(idConsulta);
                DisplayImages(images);
            }
        }

        private List<byte[]> GetImagesFromDatabase(int idConsulta)
        {
            var images = new List<byte[]>();

            string query =
                @"
        SELECT Imagenes.Imagen FROM Imagenes
        INNER JOIN Expediente ON Imagenes.ID_Imagen = Expediente.ID_Imagen
        WHERE Expediente.ID_Consulta = @ID_Consulta";

            var cmd = PrepararComando(query);
            cmd.Parameters.AddWithValue("@ID_Consulta", idConsulta);

            try
            {
                conexion.establecerConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] imageBytes = reader["Imagen"] as byte[];
                        images.Add(imageBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving images: " + ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }

            return images;
        }

        private void DisplayImages(List<byte[]> images)
        {
            foreach (byte[] imageBytes in images)
            {
                Image image = ConvertByteArrayToImage(imageBytes);
                ImageDisplayForm displayForm = new ImageDisplayForm(image);
                displayForm.Show();
            }
        }

        public static Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private void Imprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                ImprimirConsulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imprimir la consulta: " + ex.Message);
            }
        }
        private void ImprimirConsulta()
        {
            string plantillaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Formatoexp.docx");
            MessageBox.Show(plantillaPath);

            // Verifica si el archivo de la plantilla existe
            if (!File.Exists(plantillaPath))
            {
                MessageBox.Show("No se ha encontrado el archivo de la plantilla. Asegúrate de que la ruta es correcta y el archivo existe.");
                return;
            }

            var wordApp = new Microsoft.Office.Interop.Word.Application
            {
                Visible = true // Hace visible la aplicación Word
            };

            Microsoft.Office.Interop.Word.Document document = null;

            try
            {
                document = wordApp.Documents.Open(plantillaPath);

                // Rellenar los datos en el documento

                ReemplazarTextoEnDocumento(document, "{consulta}", idConsulta.ToString());
                ReemplazarTextoEnDocumento(document, "{Nombre}", textBoxNombreP.Text);
                ReemplazarTextoEnDocumento(document, "{ApellidoPaterno}", textBoxApellidoP.Text);
                ReemplazarTextoEnDocumento(document, "{ApellidoMaterno}", textBoxApellidoM.Text);
                ReemplazarTextoEnDocumento(document, "{Edad}", textBoxEdad.Text);
                ReemplazarTextoEnDocumento(document, "{Sexo}", comboBoxSexo.Text);
                ReemplazarTextoEnDocumento(document, "{PA}", textBoxPresionArterial.Text);
                ReemplazarTextoEnDocumento(document, "{TEMP}", textBoxTemperatura.Text);
                ReemplazarTextoEnDocumento(document, "{FC}", textBoxFrecuenciaCardiaca.Text);
                ReemplazarTextoEnDocumento(document, "{FR}", textBoxFrecuenciaRespiratoria.Text);
                ReemplazarTextoEnDocumento(document, "{Peso}", textBoxPeso.Text);
                ReemplazarTextoEnDocumento(document, "{Talla}", textBoxTalla.Text);
                ReemplazarTextoEnDocumento(document, "{Cintura}", textBoxCintura.Text);
                ReemplazarTextoEnDocumento(document, "{SAT}", textBoxSaturacion.Text);
                ReemplazarTextoEnDocumento(document, "{Glucosa}", textBoxGlucemia.Text);
                ReemplazarTextoEnDocumento(document, "{Al}", textBoxAlergias.Text);
                ReemplazarTextoEnDocumento(document, "{PadecimientoActual}", textBoxPadecimientoActual.Text);
                ReemplazarTextoEnDocumento(document, "{AntecedentesImportancia}", textBoxAntecedentesImportancia.Text);
                ReemplazarTextoEnDocumento(document, "{Hallazgos}", textBoxHallazgos.Text);
                ReemplazarTextoEnDocumento(document, "{PruebasDiag}", textBoxPruebasDiag.Text);
                ReemplazarTextoEnDocumento(document, "{Diagnostico}", textBoxDiagnostico.Text);
                ReemplazarTextoEnDocumento(document, "{Tratamiento}", textBoxTratamiento.Text);
                ReemplazarTextoEnDocumento(document, "{Pronostico}", textBoxPronostico.Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imprimir el documento: " + ex.Message);
            }
            
        }


        private void ReemplazarTextoEnDocumento(Microsoft.Office.Interop.Word.Document doc, string placeholder, string text)
        {
            foreach (Microsoft.Office.Interop.Word.Range storyRange in doc.StoryRanges)
            {
                Microsoft.Office.Interop.Word.Find find = storyRange.Find;
                find.Text = placeholder; 
                find.Replacement.Text = text; 

                find.Execute(Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
            }
        }
    }
}
