using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicEx_2024
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            
            InitializeFormComponents();
        }

        private void InitializeFormComponents()
        {
            this.Size = new Size(1200, 700);
            this.Text = "Registro de Expediente Médico";
            
            Label labelnombre = new Label
            {
                Text = "Consultorio San Francisco",
                Location = new Point((this.ClientSize.Width - 200) / 2, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            Label labelFechaConsulta = new Label
            {
                Text = "Fecha de consulta",
                Location = new Point(10, 80),
                AutoSize = true
            };
            DateTimePicker dateTimePickerConsulta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(170, 80)
            };


            Label labelServicio = new Label
            {
                Text = "Servicio",
                Location = new Point(10, 150),
                AutoSize = true
            };
            ComboBox comboBoxServicio = new ComboBox
            {
                Location = new Point(120, 150),
                Width = 200
            };
            comboBoxServicio.Items.AddRange(new string[] { "Servicio 1", "Servicio 2", "Servicio 3" });


            Label labelPeso = new Label
            {
                Text = "Peso (kg)",
                Location = new Point(10, 220),
                AutoSize = true
            };
            TextBox textBoxPeso = new TextBox
            {
                Location = new Point(30, 250),
                Width = 50
            };


            Label labelTalla = new Label
            {
                Text = "Talla (cm)",
                Location = new Point(110, 220),
                AutoSize = true
            };
            TextBox textBoxTalla = new TextBox
            {
                Location = new Point(120, 250),
                Width = 50
            };

            // IMC se calcularía automáticamente basado en el peso y la talla
            Label labelIMC = new Label
            {
                Text = "IMC",
                Location = new Point(210, 220),
                AutoSize = true
            };
            Label datoIMC = new Label
            {
                Text = "--",
                Location = new Point(220, 250),
                AutoSize = true
            };

            Label labelCintura = new Label
            {
                Text = "Circunferencia de cintura (cm)",
                Location = new Point(300, 220),
                AutoSize = true
            };
            TextBox textBoxCintura = new TextBox
            {
                Location = new Point(380, 250),
                Width = 50
            };


            Label labelPresionSistolica = new Label
            {
                Text = "Presión arterial sistólica",
                Location = new Point(600, 220),
                AutoSize = true
            };
            TextBox textBoxPresionSistolica = new TextBox
            {
                Location = new Point(680, 250),
                Width = 50
            };


            Label labelPresionDiastolica = new Label
            {
                Text = "Presión arterial diastólica",
                Location = new Point(800, 220),
                AutoSize = true
            };
            TextBox textBoxPresionDiastolica = new TextBox
            {
                Location = new Point(880, 250),
                Width = 50
            };
            Label temperaturalabel = new Label
            {
                Text = "Temperatura",
                Location = new Point(10, 320),
                AutoSize = true
            };
            TextBox textBoxtemperatura = new TextBox
            {
                Location = new Point(40, 350),
                Width = 50
            };
            Label saturacionlabel = new Label
            {
                Text = "Saturación de oxígeno",
                Location = new Point(300, 320),
                AutoSize = true
            };
            TextBox textBoxsaturacion = new TextBox
            {
                Location = new Point(370, 350),
                Width = 50
            };
            Label glucemialabel = new Label
            {
                Text = "Glucemia",
                Location = new Point(600, 320),
                AutoSize = true
            };
            TextBox textBoxglucemia = new TextBox
            {
                Location = new Point(620, 350),
                Width = 50
            };

            Label labelNotaMedica = new Label
            {
                Text = "Nota médica",
                Location = new Point(10, 400),
                AutoSize = true
            };
            TextBox textBoxNotaMedica = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 440),
                Size = new Size(650, 100)
            };


            Label labelPadecimientoActual = new Label
            {
                Text = "Padecimiento actual",
                Location = new Point(10, 540),
                AutoSize = true
            };
            TextBox textBoxPadecimientoActual = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 580),
                Size = new Size(650, 100)
            };


            Label labelAntecedentesImportancia = new Label
            {
                Text = "Antecedentes de importancia",
                Location = new Point(10, 680),
                AutoSize = true
            };
            TextBox textBoxAntecedentesImportancia = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 720),
                Size = new Size(650, 100)
            };

            Label labelHallazgos = new Label
            {
                Text = "Hallazgos en exploración física",
                Location = new Point(10, 820),
                AutoSize = true
            };
            TextBox textBoxHallazgos = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 860),
                Size = new Size(760, 100)
            };


            Label labelPruebasDiag = new Label
            {
                Text = "Pruebas diagnósticas realizadas",
                Location = new Point(10, 960),
                AutoSize = true
            };
            TextBox textBoxPruebasDiag = new TextBox
            {
                Multiline = true,
                Location = new Point(10, 1000),
                Size = new Size(760, 100)
            };


            Panel panelScroll = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            panelScroll.SuspendLayout();
            panelScroll.Controls.Add(labelnombre);
            panelScroll.Controls.Add(labelFechaConsulta);
            panelScroll.Controls.Add(dateTimePickerConsulta);
            panelScroll.Controls.Add(labelServicio);
            panelScroll.Controls.Add(comboBoxServicio);
            panelScroll.Controls.Add(labelPeso);
            panelScroll.Controls.Add(textBoxPeso);
            panelScroll.Controls.Add(labelTalla);
            panelScroll.Controls.Add(textBoxTalla);
            panelScroll.Controls.Add(labelIMC);
            panelScroll.Controls.Add(datoIMC);
            panelScroll.Controls.Add(labelCintura);
            panelScroll.Controls.Add(textBoxCintura);
            panelScroll.Controls.Add(labelPresionSistolica);
            panelScroll.Controls.Add(textBoxPresionSistolica);
            panelScroll.Controls.Add(labelPresionDiastolica);
            panelScroll.Controls.Add(textBoxPresionDiastolica);
            panelScroll.Controls.Add(temperaturalabel);
            panelScroll.Controls.Add(textBoxtemperatura);
            panelScroll.Controls.Add(saturacionlabel);
            panelScroll.Controls.Add(textBoxsaturacion);
            panelScroll.Controls.Add(glucemialabel);
            panelScroll.Controls.Add(textBoxglucemia);
            panelScroll.Controls.Add(labelNotaMedica);
            panelScroll.Controls.Add(textBoxNotaMedica);
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

        

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private Label label1;

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
