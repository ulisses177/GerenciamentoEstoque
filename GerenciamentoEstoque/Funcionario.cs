using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEstoque
{
    class Funcionario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool EGerente { get; set; }
        public Funcionario(string nome, string senha, bool egerente)
        {
            Nome = nome;
            Senha = senha;
            EGerente = egerente;
        }
        ~Funcionario() { }
    }
}
