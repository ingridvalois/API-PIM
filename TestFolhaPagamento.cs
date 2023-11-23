using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace API_PIM.Controllers
{
    public class TestFolhaPagamento

    {
        private readonly IConfiguration _configuration;

        public TestFolhaPagamento(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool TestDatabaseConnection()
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            bool isConnected = false; // Inicialize isConnected com false

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    isConnected = true; // A conexão foi estabelecida com sucesso.
                }
                catch (SqlException)
                {
                    // Não foi possível estabelecer a conexão. isConnected permanece como false.
                }
            }

            return isConnected;
        }
    }
}