using System.Data.SqlClient;
using API_PIM.Domain.Models;

namespace API_PIM.Infrastructure
{
    public class UsuarioDAO
    {
        private readonly string _conexaoBD;

        public UsuarioDAO(string connectionString)
        {
            _conexaoBD = connectionString;
        }

        public Usuario? AuthenticateUsuario(string login, string senha)
        {
            using var connection = new SqlConnection(_conexaoBD);
            connection.Open();
            using var command = new SqlCommand("SELECT * FROM Usuario WHERE Login = @Login AND Senha = @Senha", connection);
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Senha", senha);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                return new Usuario(
                    (int)reader["Id"],
                    (int)reader["IdPessoa"],
                    (bool)reader["Ativo"],
                    (string)reader["Senha"],
                    (string)reader["Login"]
                );
            }
            return null;
    }
}
}

