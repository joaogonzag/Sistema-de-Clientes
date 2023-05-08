using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using TesteConexão.Models;

namespace APICliente.Services
{
    public class ClienteServices
    {
        static string localdb = @"Data Source=localhost;Initial Catalog=db_cliente;Integrated Security=True";
        SqlConnection conexao = new SqlConnection(localdb);

        public string InserirCliente(ClienteModel cliente) 
        {
          try
            {
                
                conexao.Open();

                string sql = "INSERT INTO clientes (nome_completo, email, cpf, data_aniversario)" + 
                    "VALUES" + "('" + cliente.nome_completo + "','" + cliente.email + "','" + cliente.cpf + "', '" + cliente.aniversario + "')";
                SqlCommand cmd = new SqlCommand(sql, conexao);
                cmd.ExecuteNonQuery();
                return "Usuário Criado Com Sucesso!";
            }
           catch (Exception ex)
            {
                return "Não foi possível inserir:";
            }
           finally
            {
                conexao.Close();
            }
        }

        public string EditarCliente(ClienteModel cliente)
        {
            try
            {

                conexao.Open();

                string sql = "UPDATE clientes SET nome_completo = '" + cliente.nome_completo + "', email = '" + cliente.email + "', cpf = '" + cliente.cpf + "' WHERE ID = "+cliente.id+"";
                SqlCommand cmd = new SqlCommand(sql, conexao);
                cmd.ExecuteNonQuery();
                return "Usuário Editado Com Sucesso!";
            }
            catch (Exception ex)
            {
                return "Não foi possível Editar!";
            }
            finally
            {
                conexao.Close();
            }

        }

        public ClienteModel SelectCliente(int id)
        {
            try
            {
                conexao.Open();

                string sql = "SELECT * FROM clientes WHERE id =  " + id + "";
                SqlCommand cmd = new SqlCommand(sql, conexao);
                SqlDataReader result = cmd.ExecuteReader();
                Console.WriteLine("Olá Mundo!");
                Console.WriteLine(result);
                ClienteModel cliente = new ClienteModel();

                while (result.Read())
                {               
                    cliente.id = int.Parse(result["id"].ToString());
                    cliente.nome_completo = result["nome_completo"].ToString();
                    cliente.email = result["email"].ToString();
                    cliente.cpf = result["cpf"].ToString();
                    //cliente.aniversario = (DateTime)result["aniversario"];
                }


                return cliente;

            }
            finally
            {
                conexao.Close();                
            }
        }

        public List<ClienteModel> ListCliente()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            try
            {

                conexao.Open();

                string sql = "SELECT * FROM clientes";
                SqlCommand cmd = new SqlCommand(sql, conexao);
                SqlDataReader resultado = cmd.ExecuteReader();
                

                while (resultado.Read())
                {
                    ClienteModel model = new ClienteModel();
                    model.id = int.Parse(resultado["id"].ToString());
                    model.nome_completo = resultado["nome_completo"].ToString();
                    model.email = resultado["email"].ToString();
                    model.cpf = resultado["cpf"].ToString();
                    //model.aniversario = (DateOnly)resultado["aniversario"];
                    lista.Add(model);
                }
                return lista;

            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
