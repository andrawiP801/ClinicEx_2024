using System.Windows.Forms;

namespace ClinicEx_2024
{
    public partial class Principal : Form
    {
        private Button buscar;
        private Button miBoton;
        private Label labelNombre;
        private TextBox textBoxNombre;
        private Label labelApellidoPaterno;
        private TextBox textBoxApellidoPaterno;
        private Label labelApellidoMaterno;
        private TextBox textBoxApellidoMaterno;
        private Label labelFechaNacimiento;
        private Label labelSexo;
        private Label labelConsultasAnteriores;
        private DateTimePicker dateTimePickerFechaNacimiento;
        private ComboBox comboBoxSexo;
        Image logoImage = Properties.Resources.Logo;
        private PictureBox pictureBox;

        public Principal()
        {
            InitializeComponent();
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

            Label miLabel = new Label();
            miLabel.AutoSize = true;
            miLabel.Text = "Consultorio San Francisco";
            miLabel.Font = new Font("Century", 16, FontStyle.Bold);
            int centerX = (this.ClientSize.Width - miLabel.Width) / 2 - 100;
            miLabel.Location = new Point(centerX, 10);
            this.Controls.Add(miLabel);

            labelNombre = new Label();
            labelNombre.Text = "Nombre*:";
            labelNombre.Location = new Point(400, 80);
            labelNombre.Size = new Size(400, 30);
            labelNombre.Font = new Font(labelNombre.Font, FontStyle.Bold);
            this.Controls.Add(labelNombre);

            textBoxNombre = new TextBox();
            textBoxNombre.Location = new Point(400, 110);
            textBoxNombre.Size = new Size(400, 40);
            this.Controls.Add(textBoxNombre);

            labelApellidoPaterno = new Label();
            labelApellidoPaterno.Text = "Apellido paterno*:";
            labelApellidoPaterno.Location = new Point(400, 160);
            labelApellidoPaterno.Size = new Size(400, 30);
            labelApellidoPaterno.Font = new Font(labelApellidoPaterno.Font, FontStyle.Bold);
            this.Controls.Add(labelApellidoPaterno);

            textBoxApellidoPaterno = new TextBox();
            textBoxApellidoPaterno.Location = new Point(400, 190);
            textBoxApellidoPaterno.Size = new Size(400, 40);
            this.Controls.Add(textBoxApellidoPaterno);

            labelApellidoMaterno = new Label();
            labelApellidoMaterno.Text = "Apellido materno*:";
            labelApellidoMaterno.Location = new Point(400, 240);
            labelApellidoMaterno.Size = new Size(400, 30);
            labelApellidoMaterno.Font = new Font(labelApellidoMaterno.Font, FontStyle.Bold);
            this.Controls.Add(labelApellidoMaterno);

            textBoxApellidoMaterno = new TextBox();
            textBoxApellidoMaterno.Location = new Point(400, 270);
            textBoxApellidoMaterno.Size = new Size(400, 40);
            this.Controls.Add(textBoxApellidoMaterno);

            labelFechaNacimiento = new Label();
            labelFechaNacimiento.Text = "Fecha de nacimiento*:";
            labelFechaNacimiento.Location = new Point(400, 320);
            labelFechaNacimiento.Size = new Size(200, 30);
            labelFechaNacimiento.Font = new Font(labelFechaNacimiento.Font, FontStyle.Bold);
            this.Controls.Add(labelFechaNacimiento);

            dateTimePickerFechaNacimiento = new DateTimePicker();
            dateTimePickerFechaNacimiento.Location = new Point(400, 350);
            dateTimePickerFechaNacimiento.Format = DateTimePickerFormat.Short;
            dateTimePickerFechaNacimiento.Width = 150;
            this.Controls.Add(dateTimePickerFechaNacimiento);

            labelSexo = new Label();
            labelSexo.Text = "Sexo*:";
            labelSexo.Location = new Point(700, 320);
            labelSexo.Font = new Font(labelSexo.Font, FontStyle.Bold);
            this.Controls.Add(labelSexo);

            comboBoxSexo = new ComboBox();
            comboBoxSexo.Location = new Point(700, 350);
            comboBoxSexo.Width = 100;
            comboBoxSexo.Items.Add("Masculino");
            comboBoxSexo.Items.Add("Femenino");
            this.Controls.Add(comboBoxSexo);

            miBoton = new Button();
            miBoton.Size = new Size(100, 40);
            miBoton.Location = new Point(400, 400);
            miBoton.Text = "Registrar";
            miBoton.Click += new EventHandler(miBotonClick);
            this.Controls.Add(miBoton);

            buscar = new Button();
            buscar.Size = new Size(100, 40);
            buscar.Location = new Point(700, 400);
            buscar.Text = "Buscar";
            buscar.Click += new EventHandler(buscarClick);
            this.Controls.Add(buscar);

            labelConsultasAnteriores = new Label();
            labelConsultasAnteriores.Text = "Consultas anteriores:";
            labelConsultasAnteriores.Location = new Point(400, 460);
            labelConsultasAnteriores.Size = new Size(200, 30);
            this.Controls.Add(labelConsultasAnteriores);

            DataGridView dataGridViewConsultas = new DataGridView();
            dataGridViewConsultas.Location = new Point(400, 490);
            dataGridViewConsultas.Size = new Size(400, 120);
            dataGridViewConsultas.AllowUserToAddRows = false;
            dataGridViewConsultas.ReadOnly = true;
            this.Controls.Add(dataGridViewConsultas);
        }

        private void miBotonClick(object sender, EventArgs e)
        {
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

        private void buscarClick(object sender, EventArgs e)
        {
            if (buscar.Text == "Buscar")
            {
                Clases.CPacientes objP = new Clases.CPacientes();

                string nombre = textBoxNombre.Text;
                string apellidoP = textBoxApellidoPaterno.Text;
                string apellidoM = textBoxApellidoMaterno.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                string sexo = comboBoxSexo.SelectedItem.ToString();

                int pacienteID = objP.buscarPaciente(
                    nombre,
                    apellidoP,
                    apellidoM,
                    fechaNacimiento,
                    sexo
                );

                if (pacienteID != 0)
                {
                    MessageBox.Show("Paciente encontrado. ID: " + pacienteID);
                    // Guardar el pacienteID en una variable para usarlo más tarde
                    // Luego dirigir a la ventana de "Nueva Consulta"
                    buscar.Size = new Size(150, 40);
                    buscar.Text = "Nueva consulta";
                    buscar.Location = new Point(650, 400);
                    miBoton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El Paciente no está Registrado");
                }                
            }
            else if (buscar.Text == "Nueva Consulta")
            {
                MainForm nform = new MainForm();
                nform.Show();
                this.Hide();
                nform.FormClosed += (s, args) => this.Show();
            }
        }
    }
}
