
using System.Data.SqlClient;
using API_PIM.Domain.Models;

namespace API_PIM.Infrastructure.DAO
{
    public class FolhaPagamentoDAO
    {
        private readonly IConfiguration _configuration;
        public FolhaPagamentoDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<FolhaPagamento> ListFolhaPagamento()
        {
            List<FolhaPagamento> folhaPagamento = new List<FolhaPagamento>();
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            string selectFolhaPagamento = "SELECT (select Nome from Pessoa p where p.Id = f.IdPessoa) as Nome , fp.DataFechamento, fp.DataPagamento, fp.ListaBDFuncionario, fp.ValorFGTS, fp.SalarioINSS, fp.TotalDescontos, fp.TotalLiquido from FolhaPagamento fp inner join Funcionario f on f.Id = fp.IdFuncionario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open ();
                SqlCommand comando = new SqlCommand(selectFolhaPagamento, connection);
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    folhaPagamento.Add(new FolhaPagamento(leitor.GetString(0), leitor.GetDateTime(1), leitor.GetDateTime(2), leitor.GetDouble(6), leitor.GetDouble(7), leitor.GetDouble(5), leitor.GetDouble(4), leitor.GetString(3)));
                }
                leitor.Close();
            }
            return folhaPagamento;
        }

        public List<FolhaPagamento> ListFolhaPagamentoU(int IdPessoa){

              List<FolhaPagamento> folhaPagamento = new List<FolhaPagamento>();
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            string selectFolhaPagamento = "SELECT (select Nome from Pessoa p where p.Id = f.IdPessoa) as Nome , fp.DataFechamento, fp.DataPagamento, fp.ListaBDFuncionario, fp.ValorFGTS, fp.SalarioINSS, fp.TotalDescontos, fp.TotalLiquido from FolhaPagamento fp inner join Funcionario f on f.Id = fp.IdFuncionario WHERE f.IdPessoa = @IdPessoa";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open ();
                SqlCommand comando = new SqlCommand(selectFolhaPagamento, connection);
                comando.Parameters.AddWithValue("@IdPessoa", IdPessoa);
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    folhaPagamento.Add(new FolhaPagamento(leitor.GetString(0), leitor.GetDateTime(1), leitor.GetDateTime(2), leitor.GetDouble(6), leitor.GetDouble(7), leitor.GetDouble(5), leitor.GetDouble(4), leitor.GetString(3)));
                }
                leitor.Close();
            }
            return folhaPagamento;
        }

    }

}