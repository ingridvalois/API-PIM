using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PIM.Domain.Models
{
    public class FolhaPagamento
    {
        public FolhaPagamento(string nome, DateTime dataFechamento, DateTime dataPagamento, double totalDescontos, double totalLiquido, double salarioINSS, double valorFGTS, string listaBDFuncionário)
        {
            Nome = nome;
            DataFechamento = dataFechamento;
            DataPagamento = dataPagamento;
            TotalDescontos = totalDescontos;
            TotalLiquido = totalLiquido;
            SalarioINSS = salarioINSS;
            ValorFGTS = valorFGTS;
            ListaBDFuncionário = listaBDFuncionário;
        }

        public string Nome {get; set;}
        public  DateTime DataFechamento { get; set; }
        public  DateTime DataPagamento { get; set; }
        public double TotalDescontos { get; set; }
        public double TotalLiquido { get; set; }

        public double SalarioINSS { get; set; }
        public double ValorFGTS { get; set; }
        public string ListaBDFuncionário { get; set; }
        

    }
}