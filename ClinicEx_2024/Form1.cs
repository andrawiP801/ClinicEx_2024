using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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
                Location = new Point(10, 100),
                AutoSize = true
            };
            DateTimePicker dateTimePickerConsulta = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(10, 120)
            };


            Label labelSignosVitales = new Label
            {
                Text = "Signos vitales",
                Location = new Point(10, 170),
                AutoSize = true
            };
            Label lineSV = new Label();
            lineSV.AutoSize = false;
            lineSV.Height = 2;
            lineSV.BorderStyle = BorderStyle.Fixed3D;
            lineSV.Width = this.Width;
            lineSV.Location = new Point(0, 180);
            lineSV.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;


            Label labelPeso = new Label
            {
                Text = "Peso (kg)",
                Location = new Point(10, 220),
                AutoSize = true
            };
            TextBox textBoxPeso = new TextBox
            {
                Location = new Point(10, 240),
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
                Location = new Point(110, 240),
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
                Location = new Point(220, 240),
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
                Location = new Point(300, 240),
                Width = 50
            };


            Label labelPresionArterial = new Label
            {
                Text = "Presión arterial",
                Location = new Point(600, 220),
                AutoSize = true
            };
            TextBox textBoxPresionArterial = new TextBox
            {
                Location = new Point(600, 240),
                Width = 50
            };


            Label labelFrecuenciaCardiaca = new Label
            {
                Text = "Frecuencia Cardiaca",
                Location = new Point(800, 220),
                AutoSize = true
            };
            TextBox textBoxFrecuenciaCardiaca = new TextBox
            {
                Location = new Point(800, 240),
                Width = 50
            };

            Label labelFrecuenciaRespiratoria = new Label
            {
                Text = "Frecuencia Respiratoria",
                Location = new Point(1000, 220),
                AutoSize = true
            };
            TextBox textBoxFrecuenciaRespiratoria = new TextBox
            {
                Location = new Point(1000, 240),
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
                Location = new Point(10, 340),
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
                Location = new Point(300, 340),
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
                Location = new Point(600, 340),
                Width = 50
            };


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