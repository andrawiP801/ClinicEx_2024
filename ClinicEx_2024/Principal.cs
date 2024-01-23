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
        private TextBox textBoxFechaNacimiento;
        private Label labelSexo;
        private TextBox textBoxSexo;
        private Label labelConsultasAnteriores;
        private TextBox textBoxConsultasAnteriores;
        private DateTimePicker dateTimePickerFechaNacimiento;
        private ComboBox comboBoxSexo;
        Image logoImage = Properties.Resources.Logo;
        public Principal()
        {
            InitializeComponent();
            this.BackColor = Color.LightBlue;
            this.Width = 1200;
            this.Height = 700;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(5, 5);
            pictureBox.Size = new Size(75, 75);
            pictureBox.Image = logoImage;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBox);
       

            Label miLabel = new Label();
            miLabel.AutoSize = true;
            miLabel.Location = new Point(400, 10);
            miLabel.Text = "Consultorio San Francisco";
            miLabel.Font = new Font("Century", 16, FontStyle.Bold);
            this.Controls.Add(miLabel);

            Label labelNombre = new Label();
            labelNombre.Text = "Nombre*:";
            labelNombre.Location = new Point(400, 80);
            this.Controls.Add(labelNombre);

            textBoxNombre = new TextBox();
            textBoxNombre.Location = new Point(400, 110);
            textBoxNombre.Size = new Size(400, 40);
            this.Controls.Add(textBoxNombre);

            Label labelApellidoPaterno = new Label();
            labelApellidoPaterno.Text = "Apellido paterno*:";
            labelApellidoPaterno.Location = new Point(400, 160);
            labelApellidoPaterno.Size = new Size(400, 30);
            this.Controls.Add(labelApellidoPaterno);

            textBoxApellidoPaterno = new TextBox();
            textBoxApellidoPaterno.Location = new Point(400, 190);
            textBoxApellidoPaterno.Size = new Size(400, 40);
            this.Controls.Add(textBoxApellidoPaterno);

            Label labelApellidoMaterno = new Label();
            labelApellidoMaterno.Text = "Apellido materno*:";
            labelApellidoMaterno.Location = new Point(400, 240);
            labelApellidoMaterno.Size = new Size(400, 30);
            this.Controls.Add(labelApellidoMaterno);

            textBoxApellidoMaterno = new TextBox();
            textBoxApellidoMaterno.Location = new Point(400, 270);
            textBoxApellidoMaterno.Size = new Size(400, 40);
            this.Controls.Add(textBoxApellidoMaterno);

            Label labelFechaNacimiento = new Label();
            labelFechaNacimiento.Text = "Fecha de nacimiento*:";
            labelFechaNacimiento.Location = new Point(400, 320);
            labelFechaNacimiento.Size = new Size(200, 30);
            this.Controls.Add(labelFechaNacimiento);

            dateTimePickerFechaNacimiento = new DateTimePicker();
            dateTimePickerFechaNacimiento.Location = new Point(400, 350);
            this.Controls.Add(dateTimePickerFechaNacimiento);

            Label labelSexo = new Label();
            labelSexo.Text = "Sexo*:";
            labelSexo.Location = new Point(700, 320);
            this.Controls.Add(labelSexo);

            comboBoxSexo = new ComboBox();
            comboBoxSexo.Location = new Point(700, 350);
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
            MessageBox.Show("Botón presionado!");
        }
        private void buscarClick(object sender, EventArgs e)
        {
            if (buscar.Text == "Buscar")
            {
                buscar.Size = new Size(200, 40);
                buscar.Text = "Nueva consulta";
                miBoton.Enabled = false;
            }
            else if (buscar.Text == "Nueva consulta")
            {
                MainForm nform = new MainForm();
                nform.Show();
                this.Hide();
                nform.FormClosed += (s, args) => this.Show();
            }
        }
    }

}
