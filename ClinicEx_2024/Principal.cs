using System.Data;
using System.Windows.Forms;

namespace ClinicEx_2024
{
    public partial class Principal : Form
    {
        private Button buscar,
            miBoton;
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

        public Principal()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarControles();
        }

        private void ConfigurarFormulario()
        {
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.LightBlue;
            Size = new Size(1200, 700);
            Icon = Properties.Resources.Icono;
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
                new Font("Century", 16, FontStyle.Bold),
                new Point(0, 10),
                true
            );
            labelGral = CrearLabel(
                "\"Medicina General\"",
                new Font("Century", 16, FontStyle.Bold),
                new Point(0, 35),
                true
            );
            labelDireccion = CrearLabel(
                "Av. hidalgo 67 Tequexquináhuac, Texcoco",
                new Font("Century", 10),
                new Point(0, 60),
                true
            );

            labelNombre = CrearLabel(
                "Nombre*:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 90)
            );
            textBoxNombre = CrearTextBox(new Point(400, 120));

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

            labelConsultasAnteriores = CrearLabel(
                "Consultas anteriores:",
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                new Point(400, 470)
            );

            dataGridViewConsultas = new DataGridView
            {
                Location = new Point(400, 500),
                Size = new Size(400, 120),
                AllowUserToAddRows = false,
                ReadOnly = true
            };
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

            Clases.CPacientes objP = new Clases.CPacientes();

            string nombre = textBoxNombre.Text;
            string apellidoP = textBoxApellidoPaterno.Text;
            string apellidoM = textBoxApellidoMaterno.Text;
            DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value.Date;
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

        private void buscarClick(object sender, EventArgs e)
        {
            if (buscar.Text == "Buscar")
            {
                if (
                    string.IsNullOrWhiteSpace(textBoxNombre.Text)
                    || string.IsNullOrWhiteSpace(textBoxApellidoPaterno.Text)
                    || string.IsNullOrWhiteSpace(textBoxApellidoMaterno.Text)
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
                    if (string.IsNullOrWhiteSpace(textBoxApellidoMaterno.Text))
                    {
                        camposFaltantes += "Apellido Materno, ";
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
                string apellidoM = textBoxApellidoMaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;

                int pacienteID = objP.BuscarPaciente(nombre, apellidoP, apellidoM, fechaNacimiento);
                if (pacienteID != 0)
                {                    
                    var paciente = objP.ObtenerDatosPaciente(pacienteID);
                    MessageBox.Show("Paciente encontrado. ID: " + pacienteID);
                    buscar.Size = new Size(150, 40);
                    buscar.Text = "Nueva Consulta";
                    buscar.Location = new Point(650, 415);
                    miBoton.Enabled = false;
                    comboBoxSexo.SelectedItem = paciente.Sexo;
                    DataTable consultas = objP.GetConsultasPorPaciente(pacienteID);
                    dataGridViewConsultas.DataSource = consultas;
                    dataGridViewConsultas.Columns["Nombre"].HeaderText = "Nombre del Paciente";
                    dataGridViewConsultas.Columns["FechaConsulta"].HeaderText = "Fecha de la Consulta";
                    
                    //diseño tabla
                    dataGridViewConsultas.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 7.75F, FontStyle.Bold);
                    dataGridViewConsultas.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
                    dataGridViewConsultas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewConsultas.EnableHeadersVisualStyles = false;
                    dataGridViewConsultas.ColumnHeadersHeight = 28;

                    dataGridViewConsultas.DefaultCellStyle.Font = new Font("Tahoma", 7.75F);
                    dataGridViewConsultas.DefaultCellStyle.BackColor = Color.White;
                    dataGridViewConsultas.DefaultCellStyle.ForeColor = Color.Black;
                    dataGridViewConsultas.DefaultCellStyle.SelectionBackColor = Color.Navy;
                    dataGridViewConsultas.DefaultCellStyle.SelectionForeColor = Color.White;

                    dataGridViewConsultas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                    dataGridViewConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
                    dataGridViewConsultas.RowHeadersVisible = false;
                    dataGridViewConsultas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewConsultas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dataGridViewConsultas.GridColor = Color.LightGray;


                }
                else
                {
                    MessageBox.Show("El Paciente no está Registrado");
                }
            }
            else if (buscar.Text == "Nueva Consulta")
            {
                Clases.CPacientes objP = new Clases.CPacientes();

                string nombre = textBoxNombre.Text;
                string apellidoPaterno = textBoxApellidoPaterno.Text;
                string apellidoMaterno = textBoxApellidoMaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                string sexo = comboBoxSexo.SelectedItem.ToString();
                int edad = CalculateAge(fechaNacimiento);

                int pacienteID = objP.BuscarPaciente(
                    nombre,
                    apellidoPaterno,
                    apellidoMaterno,
                    fechaNacimiento
                );

                MainForm nform = new MainForm
                {
                    PacienteID = pacienteID,
                    Nombre = nombre,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    Sexo = sexo,
                    Edad = edad
                };

                nform.Show();
                this.Hide();
                nform.FormClosed += (s, args) => this.Show();
            }
        }
    }
}
