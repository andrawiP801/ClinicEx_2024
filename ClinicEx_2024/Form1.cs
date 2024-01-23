using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ClinicEx_2024.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.LinkLabel;

namespace ClinicEx_2024
{
    public partial class MainForm : Form
    {
        private Label labelnombre;
        private TextBox textBoxnombrep;
        private TextBox textBoxapellidop,
            textBoxapellidom;
        private TextBox textBoxSexo;
        private TextBox textBoxPeso;
        private TextBox textBoxTalla;
        private Label datoIMC;
        private TextBox textBoxPadecimientoActual;
        private TextBox textBoxAntecedentesImportancia;
        private TextBox textBoxHallazgos;
        private TextBox textBoxPruebasDiag;
        private TextBox textBoxDiagnostico,
            textBoxTratamiento,
            textBoxPronostico;
        private TextBox textBoxEdad;
        private Panel panelScroll;

        Image logoImage = Properties.Resources.Logo;

        public MainForm()
        {
            InitializeFormComponents();
            panelScroll.BackColor = Color.LightBlue;
            CambiarFuenteLabels(this, "Century", 10);
            labelnombre.Font = new Font("Century", 16, FontStyle.Bold);
            this.Icon = Properties.Resources.Icono;

            AjustarAnchoTextBox(textBoxPadecimientoActual);
            AjustarAnchoTextBox(textBoxAntecedentesImportancia);
            AjustarAnchoTextBox(textBoxHallazgos);
            AjustarAnchoTextBox(textBoxPruebasDiag);
            AjustarAnchoTextBox(textBoxDiagnostico);
            AjustarAnchoTextBox(textBoxTratamiento);
            AjustarAnchoTextBox(textBoxPronostico);

            this.Resize += MainForm_Resize;
        }

        private void InitializeFormComponents()
        {
            this.Size = new Size(1200, 700);
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
                Location = new Point((this.ClientSize.Width - 200) / 2-100, 30),                
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true
            };

            Label labelnombrep = new Label
            {
                Text = "Nombre",
                Location = new Point(300, 100),
                AutoSize = true
            };
            textBoxnombrep = new TextBox
            {
                Location = new Point(300, 120),
                Size = new Size(100, 50),
                Enabled = false
            };

            Label labelapellidop = new Label
            {
                Text = "Apellido Paterno",
                Location = new Point(420, 100),
                AutoSize = true
            };
            textBoxapellidop = new TextBox
            {
                Location = new Point(420, 120),
                Size = new Size(100, 50),
                Enabled = false
            };

            Label labelapellidom = new Label
            {
                Text = "Apellido Materno",
                Location = new Point(550, 100),
                AutoSize = true
            };
            textBoxapellidom = new TextBox
            {
                Location = new Point(550, 120),
                Size = new Size(100, 50),
                Enabled = false
            };

            Label labelEdad = new Label
            {
                Text = "Edad",
                Location = new Point(700, 100),
                AutoSize = true
            };
            textBoxEdad = new TextBox
            {
                Location = new Point(700, 120),
                Size = new Size(40, 50),
                Enabled = false
            };

            Label labelsexo = new Label
            {
                Text = "Sexo",
                Location = new Point(950, 100),
                AutoSize = true
            };
            textBoxSexo = new TextBox 
            { 
                Location = new Point(950, 120), 
                Width = 50,
                Enabled = false
            };

            Button selecciona = new Button
            {
                Text = "Selecciona paciente",
                Location = new Point(900, 50),
                AutoSize = true,
                BackColor = Color.FromArgb(128, 0, 32),
                ForeColor = Color.White
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
                Location = new Point(10, 120),
                Width = 120
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

            Label labelPresionArterial = new Label
            {
                Text = "Presión arterial",
                Location = new Point(15, 220),
                AutoSize = true
            };
            TextBox textBoxPresionArterial = new TextBox
            {
                Location = new Point(15, 240),
                Width = 90
            };

            Label temperaturalabel = new Label
            {
                Text = "Temperatura",
                Location = new Point(150, 220),
                AutoSize = true
            };
            TextBox textBoxtemperatura = new TextBox { Location = new Point(150, 240), Width = 70 };

            Label labelFrecuenciaCardiaca = new Label
            {
                Text = "Frecuencia Cardiaca",
                Location = new Point(270, 220),
                AutoSize = true
            };
            TextBox textBoxFrecuenciaCardiaca = new TextBox
            {
                Location = new Point(270, 240),
                Width = 115
            };

            Label labelFrecuenciaRespiratoria = new Label
            {
                Text = "Frecuencia Respiratoria",
                Location = new Point(435, 220),
                AutoSize = true
            };
            TextBox textBoxFrecuenciaRespiratoria = new TextBox
            {
                Location = new Point(435, 240),
                Width = 127
            };

            Label labelPeso = new Label
            {
                Text = "Peso (kg)",
                Location = new Point(620, 220),
                AutoSize = true
            };
            textBoxPeso = new TextBox { Location = new Point(620, 240), Width = 53 };

            Label labelTalla = new Label
            {
                Text = "Talla (cm)",
                Location = new Point(720, 220),
                AutoSize = true
            };
            textBoxTalla = new TextBox { Location = new Point(720, 240), Width = 55 };

            Label labelIMC = new Label
            {
                Text = "IMC",
                Location = new Point(820, 220),
                AutoSize = true
            };
            datoIMC = new Label
            {
                Text = "--",
                Location = new Point(820, 240),
                AutoSize = true
            };
            textBoxPeso.TextChanged += (sender, e) => CalcularIMC();
            textBoxTalla.TextChanged += (sender, e) => CalcularIMC();

            Label labelCintura = new Label
            {
                Text = "Circunferencia de cintura (cm)",
                Location = new Point(920, 220),
                AutoSize = true
            };
            TextBox textBoxCintura = new TextBox { Location = new Point(920, 240), Width = 165 };

            Label saturacionlabel = new Label
            {
                Text = "Saturación de oxígeno",
                Location = new Point(10, 320),
                AutoSize = true
            };
            TextBox textBoxsaturacion = new TextBox { Location = new Point(10, 340), Width = 105 };

            Label glucemialabel = new Label
            {
                Text = "Glucemia",
                Location = new Point(250, 320),
                AutoSize = true
            };
            TextBox textBoxglucemia = new TextBox { Location = new Point(250, 340), Width = 50 };

            Label alergiaslabel = new Label
            {
                Text = "Alergias",
                Location = new Point(350, 320),
                AutoSize = true
            };
            TextBox textBoxalergias = new TextBox { Location = new Point(350, 340), Width = 50 };

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
                Location = new Point(10, 440),
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
                Location = new Point(10, 580),
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
                Location = new Point(10, 720),
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
                Location = new Point(10, 860),
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
                Location = new Point(10, 1000),
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
                Location = new Point(10, 1140),
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
                Location = new Point(10, 1280),
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

            Button Agregar = new Button
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
            panelScroll.Controls.Add(pictureBox);
            panelScroll.Controls.Add(selecciona);
            panelScroll.Controls.Add(labelnombrep);
            panelScroll.Controls.Add(textBoxnombrep);
            panelScroll.Controls.Add(labelapellidop);
            panelScroll.Controls.Add(textBoxapellidop);
            panelScroll.Controls.Add(labelapellidom);
            panelScroll.Controls.Add(textBoxapellidom);
            panelScroll.Controls.Add(labelEdad);
            panelScroll.Controls.Add(textBoxEdad);
            panelScroll.Controls.Add(labelsexo);
            panelScroll.Controls.Add(textBoxSexo);
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

        private void MainForm_Load(object sender, EventArgs e) { }

        private void CalcularIMC()
        {
            if (
                double.TryParse(textBoxPeso.Text, out double peso)
                && double.TryParse(textBoxTalla.Text, out double talla)
            )
            {
                if (talla > 0)
                {
                    // La talla debe estar en metros para calcular el IMC
                    double tallaEnMetros = talla / 100;
                    double imc = peso / (Math.Pow(tallaEnMetros, 2));
                    datoIMC.Text = imc.ToString("0.00"); // Formatea a dos decimales
                }
            }
            else
            {
                // Si no se puede parsear, dejar el datoIMC con guiones o vacío.
                datoIMC.Text = "--";
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            
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

                // Si el control tiene controles hijos, busca Labels dentro de ellos también
                if (control.HasChildren)
                {
                    CambiarFuenteLabels(control, nombreFuente, nuevoTamano);
                }
            }
        }
        
        private string CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;
            int años = hoy.Year - fechaNacimiento.Year;
            int meses = hoy.Month - fechaNacimiento.Month;
            int dias = hoy.Day - fechaNacimiento.Day;

            if (dias < 0)
            {
                meses--;
                dias += DateTime.DaysInMonth(hoy.Year, hoy.Month - 1);
            }

            if (meses < 0)
            {
                años--;
                meses += 12;
            }

            return $"{años} años, {meses} meses y {dias} días";
        }

        private void MainForm_Load_1(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) { }

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
    }
}
