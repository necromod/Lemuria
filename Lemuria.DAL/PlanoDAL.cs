using Lemuria.DTO;
using System.Data.SqlClient;
using System.Numerics;

namespace Lemuria.DAL
{
    public class PlanoDAL : Conexao
    {
        public void Cadastrar(PlanoDTO plano)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Plano (Nome, Preco, Armazenamento, Subdominios, Emails, Recomendado) VALUES (@Nome, @Preco, @Armazenamento, @Subdominios, @Emails, @Recomendado);", conn);
                cmd.Parameters.AddWithValue("@Nome", plano.Nome);
                cmd.Parameters.AddWithValue("@Preco", plano.Preco);
                cmd.Parameters.AddWithValue("@Armazenamento", plano.Armazenamento);
                cmd.Parameters.AddWithValue("@Subdominios", plano.Subdominios);
                cmd.Parameters.AddWithValue("@Emails", plano.Emails);
                cmd.Parameters.AddWithValue("@Recomendado", plano.Recomendado);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastrar Plano");
            }
            finally
            {
                Desconectar();
            }
        }

        public void Editar(PlanoDTO plano)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Plano SET Nome = @Nome, Preco = @Preco, Armazenamento = @Armazenamento, Subdominios = @Subdominios, Emails = @Emails, Recomendado = @Recomendado WHERE Id = @IdPlano;", conn);
                cmd.Parameters.AddWithValue("@Nome", plano.Nome);
                cmd.Parameters.AddWithValue("@Preco", plano.Preco);
                cmd.Parameters.AddWithValue("@Armazenamento", plano.Armazenamento);
                cmd.Parameters.AddWithValue("@Subdominios", plano.Subdominios);
                cmd.Parameters.AddWithValue("@Emails", plano.Emails);
                cmd.Parameters.AddWithValue("@Recomendado", plano.Recomendado);
                cmd.Parameters.AddWithValue("@IdPlano", plano.Id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Plano");
            }
            finally
            {
                Desconectar();
            }
        }

        public void Excluir(int idPlano)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE Plano WHERE Id = @IdPlano;", conn);
                cmd.Parameters.AddWithValue("@IdPlano", idPlano);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Plano");
            }
            finally
            {
                Desconectar();
            }
        }

        public PlanoDTO Selecionar(int idPlano)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Plano WHERE Id = @IdPlano;", conn);
                cmd.Parameters.AddWithValue("@IdPlano", idPlano);
                
                dr = cmd.ExecuteReader();
                
                PlanoDTO plano = new PlanoDTO();
                if (dr.Read())
                {
                    plano.Id = Convert.ToInt32(dr["Id"]);
                    plano.Nome = dr["Nome"].ToString();
                    plano.Preco = Convert.ToDecimal(dr["Preco"]);
                    plano.Armazenamento = Convert.ToInt32(dr["Armazenamento"]);
                    plano.Subdominios = Convert.ToInt32(dr["Subdominios"]);
                    plano.Emails = Convert.ToInt32(dr["Emails"]);
                    plano.Recomendado = Convert.ToBoolean(dr["Recomendado"]);
                }
                return plano;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar Plano");
            }
            finally
            {
                Desconectar();
            }
        }

        public List<PlanoDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Plano;", conn);
                dr = cmd.ExecuteReader();
                
                List<PlanoDTO> listaPlanos = new List<PlanoDTO>();
                
                while (dr.Read())
                {
                    PlanoDTO plano = new PlanoDTO();
                    plano.Id = Convert.ToInt32(dr["Id"]);
                    plano.Nome = dr["Nome"].ToString();
                    plano.Preco = Convert.ToDecimal(dr["Preco"]);
                    plano.Armazenamento = Convert.ToInt32(dr["Armazenamento"]);
                    plano.Subdominios = Convert.ToInt32(dr["Subdominios"]);
                    plano.Emails = Convert.ToInt32(dr["Emails"]);
                    plano.Recomendado = Convert.ToBoolean(dr["Recomendado"]);
                    
                    listaPlanos.Add(plano);
                }

                return listaPlanos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar Planos");
            }
            finally
            {
                Desconectar();
            }

        }

    }
}