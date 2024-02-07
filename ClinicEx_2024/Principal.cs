using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClinicEx_2024.Clases;
using MySql.Data.MySqlClient;

namespace ClinicEx_2024
{
    public partial class Principal : Form
    {
        private Button buscar,
            miBoton,
            botonRefresh;
        private Label miLabel,
            labelGral,
            labelDireccion,
            labelNombre,
            labelApellidoPaterno,
            labelApellidoMaterno,
            labelFechaNacimiento,
            labelSexo,
            labelConsultasAnteriores;
        public TextBox textBoxNombre,
            textBoxApellidoPaterno,
            textBoxApellidoMaterno;
        private DateTimePicker dateTimePickerFechaNacimiento;
        public ComboBox comboBoxSexo;
        private DataGridView dataGridViewConsultas;
        int idConsulta;
        string textBoxPresionArterial;
        string textBoxTemperatura;
        string textBoxFrecuenciaCardiaca;
        string textBoxFrecuenciaRespiratoria;
        string textBoxPeso;
        string textBoxTalla;
        string datoIMC;
        string textBoxCintura;
        string textBoxSaturacion;
        string textBoxGlucemia;
        string textBoxAlergias;
        string textBoxEstadoN;
        string textBoxPadecimientoActual;
        string textBoxAntecedentesImportancia;
        string textBoxHallazgos;
        string textBoxPruebasDiag;
        string textBoxDiagnostico;
        string textBoxTratamiento;
        string textBoxPronostico;

        public Principal()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarControles();
        }

        private void ConfigurarFormulario()
        {
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = ColorTranslator.FromHtml("#2984FF");
            Size = new Size(1200, 700);
            Icon = Properties.Resources.Icono;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Layout += Principal_Layout;
        }

        private void ConfigurarControles()
        {
            Controls.Add(
                new PictureBox
                {
                    Location = new Point(5, 5),
                    Size = new Size(75, 75),
                    Image = Properties.Resources.Logo,
                    SizeMode = PictureBoxSizeMode.Zoom
                }
            );

            miLabel = CrearLabel(
                "Consultorio San Francisco",
                new Font("Eras Demi ITC", 15, FontStyle.Bold),
                new Point(0, 10),
                true
            );
            labelGral = CrearLabel(
                "\"Medicina General\"",
                new Font("Eras Demi ITC", 15, FontStyle.Bold),
                new Point(0, 35),
                true
            );
            labelDireccion = CrearLabel(
                "Av. Hidalgo 67 Tequexquináhuac, Texcoco",
                new Font("Eras Demi ITC", 10),
                new Point(0, 60),
                true
            );

            labelNombre = CrearLabel(
                "Nombre*:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 90)
            );
            textBoxNombre = CrearTextBox(new Point(400, 120));
            textBoxNombre.Focus();

            labelApellidoPaterno = CrearLabel(
                "Apellido paterno*:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 170)
            );
            textBoxApellidoPaterno = CrearTextBox(new Point(400, 200));

            labelApellidoMaterno = CrearLabel(
                "Apellido materno:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 250)
            );
            textBoxApellidoMaterno = CrearTextBox(new Point(400, 280));

            labelFechaNacimiento = CrearLabel(
                "Fecha de nacimiento*:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 330)
            );
            dateTimePickerFechaNacimiento = CrearDateTimePicker(new Point(400, 360));

            labelSexo = CrearLabel(
                "Sexo:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(700, 330)
            );
            comboBoxSexo = CrearComboBox(new Point(700, 360), new[] { "Masculino", "Femenino" });

            miBoton = CrearButton("Registrar", new Point(400, 410), miBotonClick);
            buscar = CrearButton("Buscar", new Point(700, 410), buscarClick);
            botonRefresh = CrearButton("Limpiar", new Point(1050, 610), refreshClick);
            botonRefresh.Hide();
            botonRefresh.Enabled = false;

            labelConsultasAnteriores = CrearLabel(
                "Consultas anteriores:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 470)
            );

            dataGridViewConsultas = new DataGridView
            {
                Location = new Point(400, 500),
                Size = new Size(400, 120),
                BackColor = Color.White,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            dataGridViewConsultas.CellDoubleClick += dataGridViewConsultas_CellDoubleClick;

            Controls.Add(dataGridViewConsultas);
        }

        private Label CrearLabel(string texto, Font fuente, Point ubicacion, bool autoSize = true)
        {
            var label = new Label
            {
                Text = texto,
                Font = fuente,
                Location = ubicacion,
                AutoSize = autoSize
            };
            Controls.Add(label);
            return label;
        }

        private TextBox CrearTextBox(Point ubicacion)
        {
            var textBox = new TextBox { Location = ubicacion, Size = new Size(400, 40) };
            Controls.Add(textBox);
            return textBox;
        }

        private DateTimePicker CrearDateTimePicker(Point ubicacion)
        {
            var picker = new DateTimePicker
            {
                Location = ubicacion,
                Format = DateTimePickerFormat.Short,
                Width = 150
            };
            picker.ValueChanged += dateTimePickerFechaNacimiento_ValueChanged;
            Controls.Add(picker);
            return picker;
        }

        private ComboBox CrearComboBox(Point ubicacion, string[] items)
        {
            var comboBox = new ComboBox { Location = ubicacion, Width = 100 };
            foreach (var item in items)
            {
                comboBox.Items.Add(item);
            }
            Controls.Add(comboBox);
            return comboBox;
        }

        private Button CrearButton(string texto, Point ubicacion, EventHandler clickEvent)
        {
            var button = new Button
            {
                Text = texto,
                Location = ubicacion,
                Size = new Size(100, 40)
            };
            button.Click += clickEvent;
            Controls.Add(button);
            return button;
        }

        private void Principal_Layout(object sender, LayoutEventArgs e)
        {
            if (miLabel != null)
                CentrarControl(miLabel);
            if (labelGral != null)
                CentrarControl(labelGral);
            if (labelDireccion != null)
                CentrarControl(labelDireccion);
        }

        private void CentrarControl(Control control)
        {
            if (control != null)
            {
                control.Location = new Point(
                    (ClientSize.Width - control.Width) / 2,
                    control.Location.Y
                );
            }
        }

        private void miBotonClick(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(textBoxNombre.Text)
                || string.IsNullOrWhiteSpace(textBoxApellidoPaterno.Text)
                || (
                    comboBoxSexo.SelectedItem == null
                    || string.IsNullOrWhiteSpace(comboBoxSexo.SelectedItem.ToString())
                )
            )
            {
                MessageBox.Show(
                    "Por favor, llene todos los campos requeridos.",
                    "Campos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validar la fecha de nacimiento
            DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value.Date;
            DateTime currentDate = DateTime.Now;
            if (fechaNacimiento > currentDate)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no puede ser en el futuro.",
                    "Fecha de Nacimiento Inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int age = CalculateAge(fechaNacimiento);
            if (age > 120)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no es válida.",
                    "Fecha de Nacimiento Inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Clases.CPacientes objP = new Clases.CPacientes();

            string nombre = textBoxNombre.Text;
            string apellidoP = textBoxApellidoPaterno.Text;
            string apellidoM = textBoxApellidoMaterno.Text;
            fechaNacimiento = dateTimePickerFechaNacimiento.Value.Date;
            string sexo = comboBoxSexo.SelectedItem.ToString();

            int pacienteID = objP.GuardarPaciente(
                nombre,
                apellidoP,
                apellidoM,
                fechaNacimiento,
                sexo
            );
        }

        private void dateTimePickerFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime birthDate = dateTimePickerFechaNacimiento.Value;
            DateTime currentDate = DateTime.Now;

            if (birthDate > currentDate)
            {
                labelFechaNacimiento.Text = "La fecha de nacimiento no puede ser en el futuro.";
                return;
            }

            int age = CalculateAge(birthDate);

            if (age > 120)
            {
                labelFechaNacimiento.Text = "La fecha de nacimiento no es válida.";
            }
            else
            {
                labelFechaNacimiento.Text = "Edad: " + age.ToString() + " años";
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            var currentDate = DateTime.Now;
            var age = currentDate.Year - birthDate.Year;
            if (birthDate > currentDate.AddYears(-age))
                age--;
            return age;
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

        public void CargarDatosConsulta(int pacienteID, DateTime fechaConsulta) { }

        private void buscarClick(object sender, EventArgs e)
        {
            if (buscar.Text == "Buscar")
            {
                if (
                    string.IsNullOrWhiteSpace(textBoxNombre.Text)
                    || string.IsNullOrWhiteSpace(textBoxApellidoPaterno.Text)
                )
                {
                    string camposFaltantes = "";
                    if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
                    {
                        camposFaltantes += "Nombre, ";
                    }
                    if (string.IsNullOrWhiteSpace(textBoxApellidoPaterno.Text))
                    {
                        camposFaltantes += "Apellido Paterno, ";
                    }

                    camposFaltantes = camposFaltantes.TrimEnd(',', ' ');

                    MessageBox.Show(
                        $"Por favor, llene los siguientes campos: {camposFaltantes}.",
                        "Campos Incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                Clases.CPacientes objP = new Clases.CPacientes();

                string nombre = textBoxNombre.Text;
                string apellidoP = textBoxApellidoPaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;

                int pacienteID = objP.BuscarPaciente(nombre, apellidoP, fechaNacimiento);
                if (pacienteID != 0)
                {
                    botonRefresh.Enabled = true;
                    botonRefresh.Show();
                    var paciente = objP.ObtenerDatosPaciente(pacienteID);
                    MessageBox.Show("Paciente encontrado");
                    buscar.Size = new Size(150, 40);
                    buscar.Text = "Nueva Consulta";
                    buscar.Location = new Point(650, 415);
                    miBoton.Enabled = false;
                    textBoxApellidoMaterno.Text = paciente.ApellidoM;
                    comboBoxSexo.SelectedItem = paciente.Sexo;
                    DataTable consultas = objP.GetConsultasPorPaciente(pacienteID);
                    dataGridViewConsultas.DataSource = consultas;
                    dataGridViewConsultas.Columns["Nombre"].HeaderText = "Nombre del Paciente";
                    dataGridViewConsultas.Columns["FechaConsulta"].HeaderText =
                        "Fecha de la Consulta";
                    if (!dataGridViewConsultas.Columns.Contains("Imprimir"))
                    {
                        // Agrega la columna 'Imprimir' solo si no existe
                        DataGridViewLinkColumn imprimirColumn = new DataGridViewLinkColumn();
                        imprimirColumn.Name = "Imprimir";
                        imprimirColumn.HeaderText = "Imprimir";
                        imprimirColumn.Text = "PDF";
                        imprimirColumn.UseColumnTextForLinkValue = true;
                        dataGridViewConsultas.Columns.Add(imprimirColumn);
                    }

                    dataGridViewConsultas.CellContentClick -=
                        dataGridViewConsultas_CellContentClick;
                    dataGridViewConsultas.CellContentClick +=
                        dataGridViewConsultas_CellContentClick;
                    // Establecer estilos solo si son necesarios actualizar dinámicamente...


                    // Define el color #28ffd5 para usarlo en el diseño
                    Color customColor = ColorTranslator.FromHtml("#28ffd5");
                    Color alternateColor = Color.FromArgb(
                        customColor.A,
                        Math.Min(Byte.MaxValue, customColor.R / 2 + 127),
                        Math.Min(Byte.MaxValue, customColor.G / 2 + 127),
                        Math.Min(Byte.MaxValue, customColor.B / 2 + 127)
                    );

                    // Estilo de los encabezados de las columnas
                    dataGridViewConsultas.ColumnHeadersDefaultCellStyle.Font = new Font(
                        "Tahoma",
                        7.75F,
                        FontStyle.Bold
                    );
                    dataGridViewConsultas.ColumnHeadersDefaultCellStyle.BackColor = customColor; // Color personalizado
                    dataGridViewConsultas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewConsultas.EnableHeadersVisualStyles = false;
                    dataGridViewConsultas.ColumnHeadersHeight = 28;

                    // Estilo de las celdas por defecto
                    dataGridViewConsultas.DefaultCellStyle.Font = new Font("Tahoma", 7.75F);
                    dataGridViewConsultas.DefaultCellStyle.BackColor = Color.White;
                    dataGridViewConsultas.DefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewConsultas.DefaultCellStyle.SelectionBackColor = Color.Navy;
                    dataGridViewConsultas.DefaultCellStyle.SelectionForeColor = Color.White;

                    // Estilo de las filas alternas
                    dataGridViewConsultas.AlternatingRowsDefaultCellStyle.BackColor =
                        alternateColor; // Color más suave basado en el personalizado
                    dataGridViewConsultas.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewConsultas.RowHeadersVisible = false;
                    dataGridViewConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewConsultas.CellBorderStyle =
                        DataGridViewCellBorderStyle.SingleHorizontal;
                    dataGridViewConsultas.GridColor = Color.LightGray;
                }
                else
                {
                    MessageBox.Show("El Paciente no está Registrado");
                    miBoton.Enabled = true;
                }
            }
            else if (buscar.Text == "Nueva Consulta")
            {
                CPacientes objP = new CPacientes();

                string nombre = textBoxNombre.Text;
                string apellidoPaterno = textBoxApellidoPaterno.Text;
                string apellidoMaterno = textBoxApellidoMaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                string sexo = comboBoxSexo.SelectedItem.ToString();
                int edad = CalculateAge(fechaNacimiento);
                int pacienteID = objP.BuscarPaciente(nombre, apellidoPaterno, fechaNacimiento);

                MainForm nform = new MainForm
                {
                    PacienteID = pacienteID,
                    Nombre = nombre,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    Sexo = sexo,
                    Edad = edad,
                    FechaNac = fechaNacimiento,
                };

                nform.Show();
                textBoxNombre.Text = "";
                textBoxApellidoPaterno.Text = "";
                textBoxApellidoMaterno.Text = "";
                dateTimePickerFechaNacimiento.Value = DateTime.Now;
                comboBoxSexo.SelectedIndex = -1;
                buscar.Text = "Buscar";
                buscar.Location = new Point(700, 410);
                buscar.Width = 100;
                if (dataGridViewConsultas.DataSource != null)
                {
                    dataGridViewConsultas.DataSource = null;
                }
                else
                {
                    dataGridViewConsultas.Rows.Clear();
                }

                dataGridViewConsultas.Columns.Clear();
                miBoton.Enabled = true;
                botonRefresh.Enabled = false;
                botonRefresh.Hide();
                textBoxNombre.Focus();
                this.Hide();
                nform.FormClosed += (s, args) => this.Show();
            }
        }

        private void ReemplazarTextoEnHojaDeExcel(
            Microsoft.Office.Interop.Excel.Worksheet sheet,
            string placeholder,
            string text
        )
        {
            Microsoft.Office.Interop.Excel.Range range = sheet.UsedRange;
            Microsoft.Office.Interop.Excel.Range foundRange = range.Find(
                What: placeholder,
                LookIn: Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues,
                LookAt: Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
                SearchOrder: Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
                SearchDirection: Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext,
                MatchCase: false,
                MatchByte: false
            );

            while (foundRange != null)
            {
                foundRange.Value2 = text;
                foundRange = range.FindNext(foundRange);
            }
        }

        private void dataGridViewConsultas_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            // Asegúrate de que la columna "Imprimir" existe y que el clic fue en esa columna
            if (
                dataGridViewConsultas.Columns["Imprimir"] != null
                && e.ColumnIndex == dataGridViewConsultas.Columns["Imprimir"].Index
                && e.RowIndex >= 0
            )
            {
                CPacientes objP = new CPacientes();

                string nombre = textBoxNombre.Text;
                string apellidoPaterno = textBoxApellidoPaterno.Text;
                string apellidoMaterno = textBoxApellidoMaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                string sexo = comboBoxSexo.SelectedItem.ToString();
                int edad = CalculateAge(fechaNacimiento);

                int pacienteID = objP.BuscarPaciente(nombre, apellidoPaterno, fechaNacimiento);
                DateTime fechaConsulta = Convert.ToDateTime(
                    dataGridViewConsultas.Rows[e.RowIndex].Cells["FechaConsulta"].Value
                );

                string query =
                    "SELECT * FROM Consultas WHERE ID_Paciente = @ID_Paciente AND FechaConsulta = @FechaConsulta LIMIT 1";

                var cmd = PrepararComando(query);
                cmd.Parameters.AddWithValue("@ID_Paciente", pacienteID);
                cmd.Parameters.AddWithValue("@FechaConsulta", fechaConsulta);

                conexion.establecerConexion();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        idConsulta = int.Parse(reader["ID_Consulta"].ToString());
                        textBoxPresionArterial = reader["PresionArterial"].ToString();
                        textBoxTemperatura = reader["Temperatura"].ToString();
                        textBoxFrecuenciaCardiaca = reader["FrecuenciaCardiaca"].ToString();
                        textBoxFrecuenciaRespiratoria = reader["FrecuenciaRespiratoria"].ToString();
                        textBoxPeso = reader["Peso"].ToString();
                        textBoxTalla = reader["Talla"].ToString();
                        datoIMC = reader["IMC"].ToString();
                        textBoxCintura = reader["CircunferenciaCintura"].ToString();
                        textBoxSaturacion = reader["SaturacionOxigeno"].ToString();
                        textBoxGlucemia = reader["Glucemia"].ToString();
                        textBoxAlergias = reader["Alergias"].ToString();
                        textBoxEstadoN = reader["EstadoNutricional"].ToString();
                        textBoxPadecimientoActual = reader["PadecimientoActual"].ToString();
                        textBoxAntecedentesImportancia = reader[
                            "AntecedentesImportancia"
                        ].ToString();
                        textBoxHallazgos = reader["HallazgosExploracionFisica"].ToString();
                        textBoxPruebasDiag = reader["PruebasDiagnosticasRealizadas"].ToString();
                        textBoxDiagnostico = reader["Diagnostico"].ToString();
                        textBoxTratamiento = reader["Tratamiento"].ToString();
                        textBoxPronostico = reader["Pronostico"].ToString();
                    }
                    try
                    {
                        string plantillaPath = Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory,
                            @"Resources\PruebaFormato.xlsx"
                        );                        

                        // Verifica si el archivo de la plantilla existe
                        if (!File.Exists(plantillaPath))
                        {
                            MessageBox.Show(
                                "No se ha encontrado el archivo de la plantilla."
                            );
                            return;
                        }

                        var excelApp = new Microsoft.Office.Interop.Excel.Application
                        {
                            Visible = false // Hace visible la aplicación Excel
                        };

                        Microsoft.Office.Interop.Excel.Workbook workbook = null;
                        Microsoft.Office.Interop.Excel.Worksheet sheet = null;

                        try
                        {
                            workbook = excelApp.Workbooks.Open(plantillaPath);
                            sheet = workbook.Sheets[1];

                            MainForm nform = new MainForm
                            {
                                PacienteID = pacienteID,
                                Nombre = nombre,
                                ApellidoPaterno = apellidoPaterno,
                                ApellidoMaterno = apellidoMaterno,
                                Sexo = sexo,
                                Edad = edad,
                                FechaConsulta = fechaConsulta,
                                FechaNac = fechaNacimiento,
                            };

                            // Rellenar los datos en el documento
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{consulta}",
                                "EXPEDIENTE: " + pacienteID.ToString()
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{Nombre}",
                                textBoxNombre.Text
                                    + " "
                                    + textBoxApellidoPaterno.Text
                                    + " "
                                    + textBoxApellidoMaterno.Text
                            );
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Edad}", edad.ToString());
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Sexo}", comboBoxSexo.Text);
                            string formattedDate = fechaNacimiento.ToString("dd/MM/yyyy");
                            string formattedDate2 = fechaConsulta.ToString("dd/MM/yyyy");

                            ReemplazarTextoEnHojaDeExcel(sheet, "{fechaNacimiento}", formattedDate);
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{PA}",
                                textBoxPresionArterial + " mmHg"
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{TEMP}",
                                textBoxTemperatura + " °C"
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{FC}",
                                textBoxFrecuenciaCardiaca + " ppm"
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{FR}",
                                textBoxFrecuenciaRespiratoria + " rpm"
                            );
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Peso}", textBoxPeso + " kg");
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Talla}", textBoxTalla + " cm");
                            ReemplazarTextoEnHojaDeExcel(sheet, "{IMC}", datoIMC);
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{Cintura}",
                                textBoxCintura + " cm"
                            );
                            ReemplazarTextoEnHojaDeExcel(sheet, "{SAT}", textBoxSaturacion + " O2");
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{Glucosa}",
                                textBoxGlucemia + " mg/dl"
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{Al}",
                                "Alergias: " + textBoxAlergias
                            );
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Fecha}", formattedDate2);
                            ReemplazarTextoEnHojaDeExcel(sheet, "{eNutricional}", textBoxEstadoN);
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{PadecimientoActual}",
                                textBoxPadecimientoActual
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{AntecedentesImportancia}",
                                textBoxAntecedentesImportancia
                            );
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Hallazgos}", textBoxHallazgos);
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{PruebasDiag}",
                                textBoxPruebasDiag
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{Diagnostico}",
                                textBoxDiagnostico
                            );
                            ReemplazarTextoEnHojaDeExcel(
                                sheet,
                                "{Tratamiento}",
                                textBoxTratamiento
                            );
                            ReemplazarTextoEnHojaDeExcel(sheet, "{Pronostico}", textBoxPronostico);
                            string pdfPath = Path.Combine(
                                AppDomain.CurrentDomain.BaseDirectory,
                                @"Resources\ConsultaImpresa.pdf"
                            );
                            // Asegúrate de que el libro de trabajo y la hoja estén inicializados correctamente
                            if (workbook != null && sheet != null)
                            {
                                // Guardar la hoja actual como PDF
                                sheet.ExportAsFixedFormat(
                                    Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF,
                                    pdfPath
                                );

                                // Cerrar el libro y la aplicación de Excel adecuadamente
                                workbook.Close(false);
                                excelApp.Quit();

                                // Liberar los recursos de COM de Excel
                                Marshal.ReleaseComObject(sheet);
                                Marshal.ReleaseComObject(workbook);
                                Marshal.ReleaseComObject(excelApp);

                                // Abrir el archivo PDF con la aplicación predeterminada
                                ProcessStartInfo startInfo = new ProcessStartInfo
                                {
                                    FileName = pdfPath,
                                    UseShellExecute = true
                                };
                                Process.Start(startInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Ocurrió un error al imprimir el documento: " + ex.Message
                            );
                        }
                    }
                    finally
                    {
                        conexion.cerrarConexion();
                    }
                }
            }
        }

        private void dataGridViewConsultas_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
            if (e.RowIndex >= 0)
            {
                Clases.CPacientes objP = new Clases.CPacientes();

                string nombre = textBoxNombre.Text;
                string apellidoPaterno = textBoxApellidoPaterno.Text;
                string apellidoMaterno = textBoxApellidoMaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                string sexo = comboBoxSexo.SelectedItem.ToString();
                int edad = CalculateAge(fechaNacimiento);

                int pacienteID = objP.BuscarPaciente(nombre, apellidoPaterno, fechaNacimiento);
                DateTime fechaConsulta = Convert.ToDateTime(
                    dataGridViewConsultas.Rows[e.RowIndex].Cells["FechaConsulta"].Value
                );
                MainForm nform = new MainForm
                {
                    PacienteID = pacienteID,
                    Nombre = nombre,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    Sexo = sexo,
                    Edad = edad,
                    FechaConsulta = fechaConsulta,
                    FechaNac = fechaNacimiento,
                };

                nform.Show();
                this.Hide();
                nform.FormClosed += (s, args) => this.Show();
            }
        }

        private void refreshClick(object? sender, EventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxApellidoPaterno.Text = "";
            textBoxApellidoMaterno.Text = "";
            dateTimePickerFechaNacimiento.Value = DateTime.Now;
            comboBoxSexo.SelectedIndex = -1;
            buscar.Text = "Buscar";
            buscar.Location = new Point(700, 410);
            buscar.Width = 100;
            if (dataGridViewConsultas.DataSource != null)
            {
                dataGridViewConsultas.DataSource = null;
            }
            else
            {
                dataGridViewConsultas.Rows.Clear();
            }

            dataGridViewConsultas.Columns.Clear();
            miBoton.Enabled = true;
            botonRefresh.Enabled = false;
            botonRefresh.Hide();
            textBoxNombre.Focus();
        }
    }
}
