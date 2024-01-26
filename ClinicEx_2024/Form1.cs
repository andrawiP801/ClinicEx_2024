using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicEx_2024.Clases;
using ClinicEx_2024.Properties;
using MySql.Data.MySqlClient;
using static ClinicEx_2024.Clases.CPacientes;

namespace ClinicEx_2024
{
    public partial class MainForm : Form
    {
        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public DateTime FechaConsulta { get; set; }
        private Label labelnombre,
            labelGral,
            labelDireccion;
        private TextBox textBoxnombrep;
        private TextBox textBoxapellidop,
            textBoxapellidom;
        private TextBox comboBoxSexo;
        private TextBox textBoxPeso;
        private TextBox textBoxTalla;
        private Label datoIMC;
        private TextBox textBoxPresionArterial,
            textBoxtemperatura,
            textBoxFrecuenciaCardiaca,
            textBoxFrecuenciaRespiratoria,
            textBoxCintura,
            textBoxsaturacion,
            textBoxglucemia,
            textBoxalergias;
        private TextBox textBoxPadecimientoActual;
        private TextBox textBoxAntecedentesImportancia;
        private TextBox textBoxHallazgos;
        private TextBox textBoxPruebasDiag;
        private TextBox textBoxDiagnostico,
            textBoxTratamiento,
            textBoxPronostico;
        private TextBox textBoxEdad;
        Button Agregar;
        Button photoUploadButton;
        public DateTimePicker dateTimePickerConsulta;
        private Panel panelScroll;

        Image logoImage = Resources.Logo;
        private int idConsulta;
        public MainForm()
        {
            InitializeFormComponents();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += MainForm_Load;
            panelScroll.BackColor = Color.LightBlue;
            CambiarFuenteLabels(this, "Century", 10);
            labelnombre.Font = new Font("Century", 15, FontStyle.Bold);
            labelGral.Font = new Font("Century", 15, FontStyle.Bold);
            this.Icon = Properties.Resources.Icono;

            AjustarAnchoTextBox(textBoxPadecimientoActual);
            AjustarAnchoTextBox(textBoxAntecedentesImportancia);
            AjustarAnchoTextBox(textBoxHallazgos);
            AjustarAnchoTextBox(textBoxPruebasDiag);
            AjustarAnchoTextBox(textBoxDiagnostico);
            AjustarAnchoTextBox(textBoxTratamiento);
            AjustarAnchoTextBox(textBoxPronostico);

            this.Resize += MainForm_Resize;
            this.Layout += new LayoutEventHandler(Form1_Layout);
        }

        private void InitializeFormComponents()
        {
            this.Size = new Size(1300, 700);
            this.Text = "Registro de Expediente Médico";

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(75, 75),
                Location = new Point(5, 5),
                Image = logoImage,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            labelnombre = new Label
            {
                Text = "Consultorio San Francisco",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };
            labelGral = new Label
            {
                Text = "\"Medicina General\"",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };
            labelDireccion = new Label
            {
                Text = "Av. hidalgo 67 Tequexquináhuac, Texcoco",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            Label labelnombrep = new Label
            {
                Text = "Nombre",
                Location = new Point(450, 105),
                AutoSize = true
            };
            textBoxnombrep = new TextBox
            {
                Text = Nombre,
                Location = new Point(450, 135),
                Size = new Size(100, 50),
                Enabled = false
            };

            Label labelapellidop = new Label
            {
                Text = "Apellido Paterno",
                Location = new Point(590, 105),
                AutoSize = true
            };
            textBoxapellidop = new TextBox
            {
                Text = ApellidoPaterno,
                Location = new Point(590, 135),
                Size = new Size(111, 50),
                Enabled = false
            };

            Label labelapellidom = new Label
            {
                Text = "Apellido Materno",
                Location = new Point(750, 105),
                AutoSize = true
            };
            textBoxapellidom = new TextBox
            {
                Text = ApellidoMaterno,
                Location = new Point(750, 135),
                Size = new Size(115, 50),
                Enabled = false
            };

            Label labelEdad = new Label
            {
                Text = "Edad",
                Location = new Point(930, 105),
                AutoSize = true
            };
            textBoxEdad = new TextBox
            {
                Location = new Point(930, 135),
                Size = new Size(42, 50),
                Enabled = false
            };

            Label labelsexo = new Label
            {
                Text = "Sexo",
                Location = new Point(1010, 105),
                AutoSize = true
            };
            comboBoxSexo = new TextBox
            {
                Location = new Point(1010, 135),
                Width = 100,
                Enabled = false,
            };

            Label labelFechaConsulta = new Label
            {
                Text = "Fecha de consulta",
                Location = new Point(10, 105),
                AutoSize = true
            };
            dateTimePickerConsulta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(10, 135),
                Width = 120
            };

            Label labelSignosVitales = new Label
            {
                Text = "Signos vitales",
                Location = new Point(10, 180),
                AutoSize = true
            };
            Label lineSV = new Label();
            lineSV.AutoSize = false;
            lineSV.Height = 2;
            lineSV.BorderStyle = BorderStyle.Fixed3D;
            lineSV.Width = this.Width;
            lineSV.Location = new Point(0, 190);
            lineSV.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label labelPresionArterial = new Label
            {
                Text = "Presión arterial",
                Location = new Point(20, 210),
                AutoSize = true
            };
            textBoxPresionArterial = new TextBox { Location = new Point(20, 240), Width = 105 };

            Label temperaturalabel = new Label
            {
                Text = "Temperatura",
                Location = new Point(180, 210),
                AutoSize = true
            };
            textBoxtemperatura = new TextBox { Location = new Point(180, 240), Width = 89 };

            Label labelFrecuenciaCardiaca = new Label
            {
                Text = "Frecuencia Cardiaca",
                Location = new Point(330, 210),
                AutoSize = true
            };
            textBoxFrecuenciaCardiaca = new TextBox { Location = new Point(330, 240), Width = 138 };

            Label labelFrecuenciaRespiratoria = new Label
            {
                Text = "Frecuencia Respiratoria",
                Location = new Point(540, 210),
                AutoSize = true
            };
            textBoxFrecuenciaRespiratoria = new TextBox
            {
                Location = new Point(540, 240),
                Width = 158
            };

            Label labelPeso = new Label
            {
                Text = "Peso (kg)",
                Location = new Point(760, 210),
                AutoSize = true
            };
            textBoxPeso = new TextBox { Location = new Point(760, 240), Width = 62 };

            Label labelTalla = new Label
            {
                Text = "Talla (cm)",
                Location = new Point(880, 210),
                AutoSize = true
            };
            textBoxTalla = new TextBox { Location = new Point(880, 240), Width = 67 };

            Label labelIMC = new Label
            {
                Text = "IMC",
                Location = new Point(1010, 210),
                AutoSize = true
            };
            datoIMC = new Label
            {
                Text = "--",
                Location = new Point(1010, 240),
                AutoSize = true
            };
            textBoxPeso.TextChanged += (sender, e) => CalcularIMC();
            textBoxTalla.TextChanged += (sender, e) => CalcularIMC();

            Label photoLabel = new Label
            {
                Text = "Estudios",
                Location = new Point(1100, 210),
                AutoSize = true
            };

            photoUploadButton = new Button
            {
                Text = "Selecciona foto",
                Location = new Point(1100, 240),
                Width = 150,
                Height = 50
            };
            photoUploadButton.Click += (sender, e) => UploadPhotoButton_Click();

            Label labelCintura = new Label
            {
                Text = "Circunferencia de cintura (cm)",
                Location = new Point(20, 310),
                AutoSize = true
            };
            textBoxCintura = new TextBox { Location = new Point(20, 340), Width = 200 };

            Label saturacionlabel = new Label
            {
                Text = "Saturación de oxígeno",
                Location = new Point(280, 310),
                AutoSize = true
            };
            textBoxsaturacion = new TextBox { Location = new Point(280, 340), Width = 147 };

            Label glucemialabel = new Label
            {
                Text = "Glucemia",
                Location = new Point(495, 310),
                AutoSize = true
            };
            textBoxglucemia = new TextBox { Location = new Point(495, 340), Width = 65 };

            Label alergiaslabel = new Label
            {
                Text = "Alergias",
                Location = new Point(640, 310),
                AutoSize = true
            };
            textBoxalergias = new TextBox { Location = new Point(640, 340), Width = 350 };

            Label labelNotaMedica = new Label
            {
                Text = "Nota médica",
                Location = new Point(10, 400),
                AutoSize = true
            };
            Label lineNM = new Label();
            lineNM.AutoSize = false;
            lineNM.Height = 2;
            lineNM.BorderStyle = BorderStyle.Fixed3D;
            lineNM.Width = this.Width;
            lineNM.Location = new Point(0, 410);
            lineNM.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label labelPadecimientoActual = new Label
            {
                Text = "Padecimiento actual",
                Location = new Point(10, 430),
                AutoSize = true
            };
            textBoxPadecimientoActual = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 460),
                Size = new Size(650, 100)
            };

            Label labelAntecedentesImportancia = new Label
            {
                Text = "Antecedentes de importancia",
                Location = new Point(10, 570),
                AutoSize = true
            };
            textBoxAntecedentesImportancia = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 600),
                Size = new Size(650, 100)
            };

            Label labelHallazgos = new Label
            {
                Text = "Hallazgos en exploración física",
                Location = new Point(10, 710),
                AutoSize = true
            };
            textBoxHallazgos = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 740),
                Size = new Size(760, 100)
            };

            Label labelPruebasDiag = new Label
            {
                Text = "Pruebas diagnósticas realizadas",
                Location = new Point(10, 850),
                AutoSize = true
            };
            textBoxPruebasDiag = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 880),
                Size = new Size(760, 100)
            };

            Label labelDiagnostico = new Label
            {
                Text = "Diagnóstico",
                Location = new Point(10, 990),
                AutoSize = true
            };
            textBoxDiagnostico = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 1020),
                Size = new Size(760, 100)
            };

            Label labelTratamiento = new Label
            {
                Text = "Tratamiento",
                Location = new Point(10, 1130),
                AutoSize = true
            };
            textBoxTratamiento = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 1160),
                Size = new Size(760, 100)
            };

            Label labelPronostico = new Label
            {
                Text = "Pronóstico",
                Location = new Point(10, 1270),
                AutoSize = true
            };
            textBoxPronostico = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 1300),
                Size = new Size(760, 100)
            };

            Label labelMedico = new Label
            {
                Text = "Médico",
                Location = new Point(10, 1430),
                AutoSize = true
            };
            Label lineMed = new Label();
            lineMed.AutoSize = false;
            lineMed.Height = 2;
            lineMed.BorderStyle = BorderStyle.Fixed3D;
            lineMed.Width = this.Width;
            lineMed.Location = new Point(0, 1440);
            lineMed.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label labelDatoNom = new Label
            {
                Text = "Nombre del Médico",
                Location = new Point(25, 1460),
                AutoSize = true
            };
            Label labelDatoCed = new Label
            {
                Text = "Cédula Profesional",
                Location = new Point(600, 1460),
                AutoSize = true
            };

            Label labelNombreMedico = new Label
            {
                Text = "FABIOLA ALEJANDRA MARQUEZ CADENA",
                Location = new Point(25, 1485),
                AutoSize = true
            };

            Label labelCedulaPro = new Label
            {
                Text = "4443217",
                Location = new Point(600, 1485),
                AutoSize = true
            };

            Agregar = new Button
            {
                Text = "Agregar",
                Location = new Point(1030, 1480),
                Size = new Size(100, 60),
                BackColor = Color.FromArgb(128, 0, 32),
                ForeColor = Color.White
            };
            Agregar.Click += new EventHandler(Agregar_Click);

            panelScroll = new Panel { AutoScroll = true, Dock = DockStyle.Fill };

            panelScroll.SuspendLayout();
            panelScroll.Controls.Add(labelnombre);
            panelScroll.Controls.Add(labelGral);
            panelScroll.Controls.Add(labelDireccion);
            panelScroll.Controls.Add(pictureBox);
            panelScroll.Controls.Add(labelnombrep);
            panelScroll.Controls.Add(textBoxnombrep);
            panelScroll.Controls.Add(labelapellidop);
            panelScroll.Controls.Add(textBoxapellidop);
            panelScroll.Controls.Add(labelapellidom);
            panelScroll.Controls.Add(textBoxapellidom);
            panelScroll.Controls.Add(labelEdad);
            panelScroll.Controls.Add(textBoxEdad);
            panelScroll.Controls.Add(labelsexo);
            panelScroll.Controls.Add(comboBoxSexo);
            panelScroll.Controls.Add(labelFechaConsulta);
            panelScroll.Controls.Add(dateTimePickerConsulta);
            panelScroll.Controls.Add(labelSignosVitales);
            panelScroll.Controls.Add(lineSV);
            panelScroll.Controls.Add(labelPeso);
            panelScroll.Controls.Add(textBoxPeso);
            panelScroll.Controls.Add(labelTalla);
            panelScroll.Controls.Add(textBoxTalla);
            panelScroll.Controls.Add(labelIMC);
            panelScroll.Controls.Add(datoIMC);
            panelScroll.Controls.Add(labelCintura);
            panelScroll.Controls.Add(textBoxCintura);
            panelScroll.Controls.Add(labelPresionArterial);
            panelScroll.Controls.Add(textBoxPresionArterial);
            panelScroll.Controls.Add(labelFrecuenciaCardiaca);
            panelScroll.Controls.Add(textBoxFrecuenciaCardiaca);
            panelScroll.Controls.Add(labelFrecuenciaRespiratoria);
            panelScroll.Controls.Add(textBoxFrecuenciaRespiratoria);
            panelScroll.Controls.Add(temperaturalabel);
            panelScroll.Controls.Add(textBoxtemperatura);
            panelScroll.Controls.Add(saturacionlabel);
            panelScroll.Controls.Add(textBoxsaturacion);
            panelScroll.Controls.Add(glucemialabel);
            panelScroll.Controls.Add(textBoxglucemia);
            panelScroll.Controls.Add(alergiaslabel);
            panelScroll.Controls.Add(textBoxalergias);
            panelScroll.Controls.Add(photoLabel);
            panelScroll.Controls.Add(photoUploadButton);
            panelScroll.Controls.Add(labelNotaMedica);
            panelScroll.Controls.Add(lineNM);
            panelScroll.Controls.Add(labelPadecimientoActual);
            panelScroll.Controls.Add(textBoxPadecimientoActual);
            panelScroll.Controls.Add(labelAntecedentesImportancia);
            panelScroll.Controls.Add(textBoxAntecedentesImportancia);
            panelScroll.Controls.Add(labelHallazgos);
            panelScroll.Controls.Add(textBoxHallazgos);
            panelScroll.Controls.Add(labelPruebasDiag);
            panelScroll.Controls.Add(textBoxPruebasDiag);
            panelScroll.Controls.Add(labelDiagnostico);
            panelScroll.Controls.Add(textBoxDiagnostico);
            panelScroll.Controls.Add(labelTratamiento);
            panelScroll.Controls.Add(textBoxTratamiento);
            panelScroll.Controls.Add(labelPronostico);
            panelScroll.Controls.Add(textBoxPronostico);
            panelScroll.Controls.Add(labelMedico);
            panelScroll.Controls.Add(lineMed);
            panelScroll.Controls.Add(labelDatoNom);
            panelScroll.Controls.Add(labelDatoCed);
            panelScroll.Controls.Add(labelNombreMedico);
            panelScroll.Controls.Add(labelCedulaPro);
            panelScroll.Controls.Add(Agregar);
            panelScroll.ResumeLayout(false);
            this.Controls.Add(panelScroll);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxnombrep.Text = this.Nombre;
            textBoxapellidop.Text = this.ApellidoPaterno;
            textBoxapellidom.Text = this.ApellidoMaterno;
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
            string query = "SELECT * FROM Consultas WHERE ID_Paciente = @ID_Paciente AND FechaConsulta = @FechaConsulta LIMIT 1";

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
                        textBoxtemperatura.Text = reader["Temperatura"].ToString();
                        textBoxFrecuenciaCardiaca.Text = reader["FrecuenciaCardiaca"].ToString();
                        textBoxFrecuenciaRespiratoria.Text = reader["FrecuenciaRespiratoria"].ToString();
                        textBoxPeso.Text = reader["Peso"].ToString();
                        textBoxTalla.Text = reader["Talla"].ToString();
                        // Assuming datoIMC is a Label or TextBox that can display the calculated IMC
                        datoIMC.Text = reader["IMC"].ToString();
                        textBoxCintura.Text = reader["CircunferenciaCintura"].ToString();
                        textBoxsaturacion.Text = reader["SaturacionOxigeno"].ToString();
                        textBoxglucemia.Text = reader["Glucemia"].ToString();
                        textBoxalergias.Text = reader["Alergias"].ToString();
                        textBoxPadecimientoActual.Text = reader["PadecimientoActual"].ToString();
                        textBoxAntecedentesImportancia.Text = reader["AntecedentesImportancia"].ToString();
                        textBoxHallazgos.Text = reader["HallazgosExploracionFisica"].ToString();
                        textBoxPruebasDiag.Text = reader["PruebasDiagnosticasRealizadas"].ToString();
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
                decimal temperatura = decimal.Parse(textBoxtemperatura.Text);
                int frecuenciaCardiaca = int.Parse(textBoxFrecuenciaCardiaca.Text);
                int frecuenciaRespiratoria = int.Parse(textBoxFrecuenciaRespiratoria.Text);
                decimal peso = decimal.Parse(textBoxPeso.Text);
                decimal talla = decimal.Parse(textBoxTalla.Text);
                decimal imc = decimal.Parse(datoIMC.Text); // Asegúrate de que esto es un decimal
                decimal circunferenciaCintura = decimal.Parse(textBoxCintura.Text);
                decimal saturacionOxigeno = decimal.Parse(textBoxsaturacion.Text);
                decimal glucemia = decimal.Parse(textBoxglucemia.Text);
                string alergias = textBoxalergias.Text;
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
            int margenDerecho = 150 + panelScroll.Padding.Right;
            textBox.Width = panelScroll.ClientSize.Width - textBox.Location.X - margenDerecho;
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
            labelnombre.Location = new Point((this.ClientSize.Width - labelnombre.Width) / 2, 10);
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
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
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

            string query = @"
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

    }
}
