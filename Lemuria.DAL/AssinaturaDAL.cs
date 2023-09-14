using Lemuria.DTO;
using System.Data.SqlClient;

namespace Lemuria.DAL
{
    public class AssinaturaDAL : Conexao
    {
        public void Cadastrar(AssinaturaDTO assinatura)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Assinatura(Cliente, Cpf, Email, Telefone, Preco, DataAssinatura, IdPlano) VALUES (@Cliente, @Cpf, @Email, @Telefone, @Preco, @DataAssinatura, @IdPlano)", conn);

                cmd.Parameters.AddWithValue("@Cliente", assinatura.Cliente);
                cmd.Parameters.AddWithValue("@Cpf", assinatura.Cpf);
                cmd.Parameters.AddWithValue("@Email", assinatura.Email);
                cmd.Parameters.AddWithValue("@Telefone", assinatura.Telefone);
                cmd.Parameters.AddWithValue("@Preco", assinatura.Preco);
                cmd.Parameters.AddWithValue("@DataAssinatura", DateTime.Now);
                cmd.Parameters.AddWithValue("@IdPlano", assinatura.IdPlano);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar a assinatura." + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        // Read
        public List<AssinaturaDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Assinatura", conn);

                dr = cmd.ExecuteReader();

                List<AssinaturaDTO> lista = new List<AssinaturaDTO>();

                while (dr.Read())
                {
                    AssinaturaDTO obj = new AssinaturaDTO();

                    obj.Id = Convert.ToInt32(dr["Id"]);
                    obj.Cliente = dr["Cliente"].ToString();
                    obj.Cpf = dr["Cpf"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Telefone = dr["Telefone"].ToString();
                    obj.Preco = Convert.ToDecimal(dr["Preco"]);
                    obj.DataAssinatura = Convert.ToDateTime(dr["DataAssinatura"]);
                    obj.IdPlano = Convert.ToInt32(dr["IdPlano"]);

                    lista.Add(obj);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar assinaturas." + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Editar(AssinaturaDTO assinatura)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Assinatura SET Cliente = @Cliente, Cpf = @Cpf, Email = @Email, Telefone = @Telefone, Preco = @Preco, IdPlano = @IdPlano WHERE Id = @Id", conn);

                cmd.Parameters.AddWithValue("@Id", assinatura.Id);
                cmd.Parameters.AddWithValue("@Cliente", assinatura.Cliente);
                cmd.Parameters.AddWithValue("@Cpf", assinatura.Cpf);
                cmd.Parameters.AddWithValue("@Email", assinatura.Email);
                cmd.Parameters.AddWithValue("@Telefone", assinatura.Telefone);
                cmd.Parameters.AddWithValue("@Preco", assinatura.Preco);
                cmd.Parameters.AddWithValue("@IdPlano", assinatura.IdPlano);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar a assinatura." + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Deletar(int idAssinatura)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Assinatura WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", idAssinatura);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir a assinatura." + ex);
            }
            finally
            {
                Desconectar();
            }
        }

        public AssinaturaDTO Selecionar(int idPlano)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Assinatura WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@IdAssinatura", idPlano);

                dr = cmd.ExecuteReader();

                AssinaturaDTO assinatura = new AssinaturaDTO();

                if (dr.Read())
                {
                    assinatura.Id = Convert.ToInt32(dr["Id"]);
                    assinatura.Cliente = dr["Cliente"].ToString();
                    assinatura.Cpf = dr["Cpf"].ToString();
                    assinatura.Email = dr["Email"].ToString();
                    assinatura.Telefone = dr["Telefone"].ToString();
                    assinatura.Preco = Convert.ToDecimal(dr["Preco"]);
                    assinatura.DataAssinatura = Convert.ToDateTime(dr["DataAssinatura"]);
                    assinatura.IdPlano = Convert.ToInt32(dr["IdPlano"]);
                }

                return assinatura;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar a assinatura." + ex);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
