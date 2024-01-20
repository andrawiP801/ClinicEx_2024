using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicEx_2024.Clases
{
    internal class CPacientes
    {
        public void guardarPacientes(TextBox textBoxnombrep, TextBox textBoxapellidop, TextBox textBoxedadp)
        {
            int edad = int.Parse(textBoxedadp.Text);
            try
            {
                CConexion obj = new CConexion();
                String query = "insert into Pacientes (Nombre,Apellido,Edad)" +
                    "values ('" + textBoxnombrep.Text + "','" + textBoxapellidop.Text + "','" + edad+ "');";
                MySqlCommand myComand = new MySqlCommand(query,obj.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("agregado");
                obj.cerrarConexion();
            }
            catch(Exception ex)
            {
                MessageBox.Show("error:" + ex.ToString());
            }
        }
    }
}
