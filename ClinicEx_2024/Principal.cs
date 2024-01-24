using System.Windows.Forms;

namespace ClinicEx_2024
{
    public partial class Principal : Form
    {
        private Button buscar;
        private Button miBoton;
        private Label miLabel, labelGral, labelDireccion;
        private Label labelNombre;
        public TextBox textBoxNombre;
        private Label labelApellidoPaterno;
        public TextBox textBoxApellidoPaterno;
        private Label labelApellidoMaterno;
        public TextBox textBoxApellidoMaterno;
        private Label labelFechaNacimiento;
        private Label labelSexo;
        private Label labelConsultasAnteriores;
        private DateTimePicker dateTimePickerFechaNacimiento;
        public ComboBox comboBoxSexo;
        Image logoImage = Properties.Resources.Logo;
        private PictureBox pictureBox;

        public Principal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightBlue;
            this.Width = 1200;
            this.Height = 700;
            this.Icon = Properties.Resources.Icono;            
            this.MaximizeBox = false;

            pictureBox = new PictureBox();
            pictureBox.Location = new Point(5, 5);
            pictureBox.Size = new Size(75, 75);
            pictureBox.Image = logoImage;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBox);

            miLabel = new Label();
            miLabel.AutoSize = true;
            miLabel.Text = "Consultorio San Francisco";
            miLabel.Font = new Font("Century", 16, FontStyle.Bold);
            miLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(miLabel);

            labelGral = new Label();
            labelGral.Text = "\"Medicina General\"";
            labelGral.Font = new Font("Century", 16, FontStyle.Bold);
            labelGral.TextAlign = ContentAlignment.MiddleCenter;
            labelGral.AutoSize = true;
            this.Controls.Add(labelGral);

            labelDireccion = new Label();
            labelDireccion.Text = "Av. hidalgo 67 Tequexquináhuac, Texcoco";
            labelDireccion.TextAlign = ContentAlignment.MiddleCenter;
            labelDireccion.Font = new Font("Century", 10, labelDireccion.Font.Style);
            labelDireccion.AutoSize = true;
            this.Controls.Add(labelDireccion);

            labelNombre = new Label();
            labelNombre.Text = "Nombre*:";
            labelNombre.Location = new Point(400, 90);
            labelNombre.Size = new Size(400, 30);
            labelNombre.Font = new Font(labelNombre.Font, FontStyle.Bold);
            this.Controls.Add(labelNombre);            

            textBoxNombre = new TextBox();
            textBoxNombre.Location = new Point(400, 120);
            textBoxNombre.Size = new Size(400, 40);
            this.Controls.Add(textBoxNombre);

            labelApellidoPaterno = new Label();
            labelApellidoPaterno.Text = "Apellido paterno*:";
            labelApellidoPaterno.Location = new Point(400, 170);
            labelApellidoPaterno.Size = new Size(400, 30);
            labelApellidoPaterno.Font = new Font(labelApellidoPaterno.Font, FontStyle.Bold);
            this.Controls.Add(labelApellidoPaterno);

            textBoxApellidoPaterno = new TextBox();
            textBoxApellidoPaterno.Location = new Point(400, 200);
            textBoxApellidoPaterno.Size = new Size(400, 40);
            this.Controls.Add(textBoxApellidoPaterno);

            labelApellidoMaterno = new Label();
            labelApellidoMaterno.Text = "Apellido materno:";
            labelApellidoMaterno.Location = new Point(400, 250);
            labelApellidoMaterno.Size = new Size(400, 30);
            labelApellidoMaterno.Font = new Font(labelApellidoMaterno.Font, FontStyle.Bold);
            this.Controls.Add(labelApellidoMaterno);

            textBoxApellidoMaterno = new TextBox();
            textBoxApellidoMaterno.Location = new Point(400, 280);
            textBoxApellidoMaterno.Size = new Size(400, 40);
            this.Controls.Add(textBoxApellidoMaterno);

            labelFechaNacimiento = new Label();
            labelFechaNacimiento.Text = "Fecha de nacimiento*:";
            labelFechaNacimiento.Location = new Point(400, 330);
            labelFechaNacimiento.Size = new Size(200, 30);
            labelFechaNacimiento.Font = new Font(labelFechaNacimiento.Font, FontStyle.Bold);
            this.Controls.Add(labelFechaNacimiento);

            dateTimePickerFechaNacimiento = new DateTimePicker();
            dateTimePickerFechaNacimiento.Location = new Point(400, 360);
            dateTimePickerFechaNacimiento.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaNacimiento.Width = 150;
            dateTimePickerFechaNacimiento.ValueChanged += new EventHandler(
                dateTimePickerFechaNacimiento_ValueChanged
            );
            this.Controls.Add(dateTimePickerFechaNacimiento);

            labelSexo = new Label();
            labelSexo.Text = "Sexo:";
            labelSexo.Location = new Point(700, 330);
            labelSexo.Font = new Font(labelSexo.Font, FontStyle.Bold);
            this.Controls.Add(labelSexo);

            comboBoxSexo = new ComboBox();
            comboBoxSexo.Location = new Point(700, 360);
            comboBoxSexo.Width = 100;
            comboBoxSexo.Items.Add("Masculino");
            comboBoxSexo.Items.Add("Femenino");
            this.Controls.Add(comboBoxSexo);

            miBoton = new Button();
            miBoton.Size = new Size(100, 40);
            miBoton.Location = new Point(400, 410);
            miBoton.Text = "Registrar";
            miBoton.Click += new EventHandler(miBotonClick);
            this.Controls.Add(miBoton);

            buscar = new Button();
            buscar.Size = new Size(100, 40);
            buscar.Location = new Point(700, 410);
            //buscar.Text = "Buscar";
            buscar.Text = "Nueva Consulta";
            buscar.Click += new EventHandler(buscarClick);
            this.Controls.Add(buscar);

            labelConsultasAnteriores = new Label();
            labelConsultasAnteriores.Text = "Consultas anteriores:";
            labelConsultasAnteriores.Location = new Point(400, 470);
            labelConsultasAnteriores.Size = new Size(200, 30);
            this.Controls.Add(labelConsultasAnteriores);

            DataGridView dataGridViewConsultas = new DataGridView();
            dataGridViewConsultas.Location = new Point(400, 500);
            dataGridViewConsultas.Size = new Size(400, 120);
            dataGridViewConsultas.AllowUserToAddRows = false;
            dataGridViewConsultas.ReadOnly = true;
            this.Controls.Add(dataGridViewConsultas);

            this.Layout += new LayoutEventHandler(Principal_Layout);
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

            int pacienteID = objP.guardarPacientes(
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
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;
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

                int pacienteID = objP.buscarPaciente(nombre, apellidoP, fechaNacimiento);
                if (pacienteID != 0)
                {
                    // Aquí asumimos que tienes un método que retorna los datos del paciente
                    var paciente = objP.obtenerDatosPaciente(pacienteID);

                    MessageBox.Show("Paciente encontrado. ID: " + pacienteID);
                    buscar.Size = new Size(150, 40);
                    buscar.Text = "Nueva consulta";
                    buscar.Location = new Point(650, 400);
                    miBoton.Enabled = false;

                    // Asumiendo que 'paciente' es un objeto con las propiedades 'ApellidoM' y 'Sexo'
                    textBoxApellidoMaterno.Text = paciente.ApellidoM;
                    comboBoxSexo.SelectedItem = paciente.Sexo;
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

                int pacienteID = objP.buscarPaciente(nombre, apellidoPaterno, fechaNacimiento);

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
        private void Principal_Layout(object sender, LayoutEventArgs e)
        {
            miLabel.Location = new Point((this.ClientSize.Width - miLabel.Width) / 2, 10);
            labelGral.Location = new Point((this.ClientSize.Width - labelGral.Width) / 2, 35);
            labelDireccion.Location = new Point((this.ClientSize.Width - labelDireccion.Width) / 2, 60);
        }
    }
}
