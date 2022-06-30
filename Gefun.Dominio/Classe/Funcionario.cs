using Dapper.Contrib.Extensions;
using Gefun.Dominio.Base;
using Gefun.Dominio.Classe.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Description = "Nome do funcionario")]
        [DataType(DataType.Time), StringLength(150, MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }
        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get => DateTime.Now; set { } }
        [DisplayName("CPF")]
        [Required]
        public string CPF { get; set; }
        [DisplayName("Sexo")]
        public ESexo Sexo { get; set; }
        [DisplayName("Estado civil")]
        public EEstadoCivil EstadoCivil { get; set; }
        [DisplayName("Formação")]
        public int FormacaoId { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress), StringLength(150, MinimumLength = 3)]
        public string Email { get; set; }
        [DisplayName("Observação")]
        [DataType(DataType.Text)]
        public string Observacao { get; set; }

        [Computed]
        public List<Parentesco> Parentescos { get; set; } = new List<Parentesco>();
        [Computed]
        public List<TreinamentoRealizado> TreinamentosRealizados { get; set; } = new List<TreinamentoRealizado>();
        [Computed]
        public List<Anexo> Anexos { get; set; } = new List<Anexo>();
     
    }
}
