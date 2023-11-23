using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace API_PIM.Domain.Models
{
    public class Funcionario
    {
        public Funcionario(long idFuncionario, long idPessoa, string email, DateTime dataAdmissao, long idEmpresa, string cargo, decimal salarioBruto)
        {
            IdFuncionario = idFuncionario;
            IdPessoa = idPessoa;
            Email = email;
            DataAdmissao = dataAdmissao;
            IdEmpresa = idEmpresa;
            Cargo = cargo;
            SalarioBruto = salarioBruto;
        }

        public long IdFuncionario { get; set; }
        public long IdPessoa { get; set; }
        public string Email { get; set; }
        public DateTime DataAdmissao { get; set; }
        public long IdEmpresa { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioBruto { get; set; }






    }
}