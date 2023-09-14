using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemuria.DAL
{
    public class Conexao
    {
        //variaveis
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlConnection conn;

        //metodos
        //Conectar
        protected void Conectar()
        {
            try
            {
                // conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=Lemuria;Integrated Security=True");
                conn = new SqlConnection(@"Server=tcp:lemuriati19roni.database.windows.net,1433;Initial Catalog=lemuria_ti19_roni;Persist Security Info=False;User ID=roni;Password=1234Tonto;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        //desconectar
        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
