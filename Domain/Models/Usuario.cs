using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PIM.Domain.Models
{
    public class Usuario
    {
        public Usuario(int idUsuario, int idPessoa, bool ativo, string senha, string login)
        {
            Id = idUsuario;
            IdPessoa = idPessoa;
            Ativo = ativo;
            Senha = senha;
            Login = login;

        }

        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public bool Ativo { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }






    }
}