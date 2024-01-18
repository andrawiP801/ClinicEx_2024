using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicEx_2024
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeFormComponents();
        }

        private void InitializeFormComponents()
        {
            this.Size = new Size(1200, 700);
            this.Text = "Registro de Expediente Médico";


            Label labelFechaConsulta = new Label
            {
                Text = "Fecha de consulta",
                Location = new Point(10, 20),
                AutoSize = true
            };
            DateTimePicker dateTimePickerConsulta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(120, 20)
            };


            Label labelServicio = new Label
            {
                Text = "Servicio",
                Location = new Point(10, 50),
                AutoSize = true
            };
            ComboBox comboBoxServicio = new ComboBox
            {
                Location = new Point(120, 50),
                Width = 200
            };
            comboBoxServicio.Items.AddRange(new string[] { "Servicio 1", "Servicio 2", "Servicio 3" });


            Label labelPeso = new Label
            {
                Text = "Peso (kg)",
                Location = new Point(10, 80),
                AutoSize = true
            };
            TextBox textBoxPeso = new TextBox
            {
                Location = new Point(120, 80),
                Width = 60
            };


            Label labelTalla = new Label
            {
                Text = "Talla (cm)",
                Location = new Point(190, 80),
                AutoSize = true
            };
            TextBox textBoxTalla = new TextBox
            {
                Location = new Point(260, 80),
                Width = 60
            };

            // IMC se calcularía automáticamente basado en el peso y la talla


            Label labelCintura = new Label
            {
                Text = "Circunferencia de cintura (cm)",
                Location = new Point(10, 110),
                AutoSize = true
            };
            TextBox textBoxCintura = new TextBox
            {
                Location = new Point(200, 110),
                Width = 60
            };


            Label labelPresionSistolica = new Label
            {
                Text = "Presión arterial sistólica",
                Location = new Point(10, 140),
                AutoSize = true
            };
            TextBox textBoxPresionSistolica = new TextBox
            {
                Location = new Point(200, 140),
                Width = 60
            };


            Label labelPresionDiastolica = new Label
            {
                Text = "Presión arterial diastólica",
                Location = new Point(270, 140),
                AutoSize = true
            };
            TextBox textBoxPresionDiastolica = new TextBox
            {
                Location = new Point(430, 140),
                Width = 60
            };

            
            Label labelNotaMedica = new Label
            {
                Text = "Nota médica",
                Location = new Point(10, 170),
                AutoSize = true
            };
            TextBox textBoxNotaMedica = new TextBox
            {
                Multiline = true,
                Location = new Point(120, 170),
                Size = new Size(650, 100) 
            };

            
            Label labelFecha = new Label
            {
                Text = "Fecha",
                Location = new Point(10, 280),
                AutoSize = true
            };
            DateTimePicker dateTimePickerFecha = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(120, 280)
            };

            
            Label labelHora = new Label
            {
                Text = "Hora",
                Location = new Point(270, 280),
                AutoSize = true
            };
            DateTimePicker dateTimePickerHora = new DateTimePicker
            {
                Format = DateTimePickerFormat.Time,
                Location = new Point(310, 280),
                Size = new Size(70, 20) 
            };

            
            Label labelPadecimientoActual = new Label
            {
                Text = "Padecimiento actual",
                Location = new Point(10, 310),
                AutoSize = true
            };
            TextBox textBoxPadecimientoActual = new TextBox
            {
                Multiline = true,
                Location = new Point(120, 310),
                Size = new Size(650, 100)
            };


            Label labelAntecedentesImportancia = new Label
            {
                Text = "Antecedentes de importancia",
                Location = new Point(10, 420),
                AutoSize = true
            };
            TextBox textBoxAntecedentesImportancia = new TextBox
            {
                Multiline = true,
                Location = new Point(120, 420),
                Size = new Size(650, 100) 
            };

            Label labelHallazgos = new Label
            {
                Text = "Hallazgos en exploración física",
                Location = new Point(10, 530), 
                AutoSize = true
            };
            TextBox textBoxHallazgos = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 550), 
                Size = new Size(760, 100)
            };

            
            Label labelPruebasDiag = new Label
            {
                Text = "Pruebas diagnósticas realizadas",
                Location = new Point(10, 660), 
                AutoSize = true
            };
            TextBox textBoxPruebasDiag = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 680),
                Size = new Size(760, 100)
            };


            Panel panelScroll = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill 
            };

            panelScroll.SuspendLayout();

            panelScroll.Controls.Add(labelFechaConsulta);
            panelScroll.Controls.Add(dateTimePickerConsulta);
            panelScroll.Controls.Add(labelServicio);
            panelScroll.Controls.Add(comboBoxServicio);
            panelScroll.Controls.Add(labelPeso);
            panelScroll.Controls.Add(textBoxPeso);
            panelScroll.Controls.Add(labelTalla);
            panelScroll.Controls.Add(textBoxTalla);
            panelScroll.Controls.Add(labelCintura);
            panelScroll.Controls.Add(textBoxCintura);
            panelScroll.Controls.Add(labelPresionSistolica);
            panelScroll.Controls.Add(textBoxPresionSistolica);
            panelScroll.Controls.Add(labelPresionDiastolica);
            panelScroll.Controls.Add(textBoxPresionDiastolica);
            panelScroll.Controls.Add(labelNotaMedica);
            panelScroll.Controls.Add(textBoxNotaMedica);
            panelScroll.Controls.Add(labelFecha);
            panelScroll.Controls.Add(dateTimePickerFecha);
            panelScroll.Controls.Add(labelHora);
            panelScroll.Controls.Add(dateTimePickerHora);
            panelScroll.Controls.Add(labelPadecimientoActual);
            panelScroll.Controls.Add(textBoxPadecimientoActual);
            panelScroll.Controls.Add(labelAntecedentesImportancia);
            panelScroll.Controls.Add(textBoxAntecedentesImportancia);
            panelScroll.Controls.Add(labelHallazgos);
            panelScroll.Controls.Add(textBoxHallazgos);
            panelScroll.Controls.Add(labelPruebasDiag);
            panelScroll.Controls.Add(textBoxPruebasDiag);

            panelScroll.ResumeLayout(false);
            this.Controls.Add(panelScroll);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new Size(1200, 700);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
