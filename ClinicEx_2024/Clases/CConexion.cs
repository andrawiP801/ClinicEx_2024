using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicEx_2024.Clases
{
    internal class CConexion
    {
        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "ClinicEx_2024";
        static string usuario = "root";
        static string password = "n0m3l0";
        static string puerto = "3308";

        string cadenaConexion = "server="+ servidor+";"+"port="+puerto+";"+"user id="+usuario+";"+"password="+password+";"+"database="+bd+";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
            }
            catch(Exception ex) 
            {
                MessageBox.Show("No se conecto a la base de datos, error:"+ex.ToString());
            }
            return conex;
        }
        public void cerrarConexion()
        {
            conex.Close();
        }
    }
}
