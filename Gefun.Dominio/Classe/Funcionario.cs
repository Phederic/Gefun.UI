using Dapper.Contrib.Extensions;
using Gefun.Dominio.Base;
using Gefun.Dominio.Classe.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Dominio.Classe
{
    [Table("Funcionario")]
    public class Funcionario : EntidadeBase
    {
        public const int NomeTamanhoMax = 150;
        public const int ObservacaoTamanhoMax = 500;
        public const int EmailTamanhoMax = 150;
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }
        [DisplayName("CPF")]
        public string CPF { get; set; }
        [DisplayName("Sexo")]
        public ESexo Sexo { get; set; }
        [DisplayName("Estado civil")]
        public EEstadoCivil EstadoCivil { get; set; }
        [DisplayName("Formação")]
        public int FormacaoId { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [Computed]
        public List<Parentesco> Parentescos { get; set; } = new List<Parentesco>();
        [Computed]
        public List<TreinamentosRealizados> TreinamentosRealizados { get; set; } = new List<TreinamentosRealizados>();
        [Computed]
        public List<Anexo> Anexos { get; set; } = new List<Anexo>();
    }
}
