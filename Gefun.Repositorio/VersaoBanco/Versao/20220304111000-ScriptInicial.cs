using Gefun.Dominio.Base;
using Gefun.Dominio.Classe;
using Gefun.Dominio.Classe.Cadastro;
using Gefun.Repositorio.VersaoBanco.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.VersaoBanco.Versao
{
    public class _20220304111000_ScriptInicial : MigrationBase
    {
        public override string SQL()
        {
            string sql = $@"
    
    CREATE TABLE Formacao(
        [Id] int IDENTITY(1,1) not null,
        [Descricao] varchar({Formacao.MaxDescricao}) not NULL

        CONSTRAINT [PK_Formacao] PRIMARY KEY CLUSTERED ([Id])
);

    CREATE TABLE Cidades(
        [Id] int IDENTITY(1,1) not null,
        [Descricao] varchar({Cidades.MaxDescricao}) not NULL

        CONSTRAINT [PK_Cidades] PRIMARY KEY CLUSTERED ([Id])
);

    CREATE TABLE Treinamentos(
        [Id] int IDENTITY(1,1) not null,
        [Descricao] varchar({Treinamentos.MaxDescricao}) not NULL

        CONSTRAINT [PK_Treinamentos] PRIMARY KEY CLUSTERED ([Id])
);






    CREATE TABLE Funcionario (
        [Id] int IDENTITY(1,1) not null,
        [Nome] varchar({Funcionario.NomeTamanhoMax}) not null,
        [DataNascimento] DATETIME not null,
        [CPF] varchar(20) not null,
        [Sexo] int,
        [EstadoCivil] int,
        [FormacaoId] int not null,
        [Email] varchar({Funcionario.EmailTamanhoMax}) ,
        [Observacao] {Funcionario.ObservacaoTamanhoMax},

        CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([Id]),
        CONSTRAINT [PK_Funcionario_FormacaoId] FOREIGN KEY ([FormacaoId]) REFERENCES [Formacao]([Id])
);



    CREATE TABLE TreinamentosRealizados(
        [Id] int IDENTITY(1,1) Not null,
        [FuncionarioId] int not null,
        [TreinamentosId] int not NULL,

        CONSTRAINT [PK_TreinamentosRealizados] PRIMARY KEY CLUSTERED ([Id]),
        CONSTRAINT [PK_TreinamentosRealizados_FuncionarioId] FOREIGN key ([FuncionarioId]) REFERENCES [Funcionario]([Id]),
        CONSTRAINT [PK_TreinamentosRealizados_TreinamentosId] FOREIGN KEY ([TreinamentosId]) REFERENCES [Treinamentos]([Id])
);
    CREATE table Parentesco(
        [Id] int IDENTITY(1,1) not null,
        [FuncionarioId] int not null,
        [Nome] varchar({Parentesco.NomeTamanhoMax}) not null,
        [Tipo] int,
        [CidadeId] int not null,

        CONSTRAINT [PK_Parentesco] PRIMARY KEY CLUSTERED ([Id]),
        CONSTRAINT [PK_Parentesco_FuncionarioId] FOREIGN key ([FuncionarioId]) REFERENCES [Funcionario]([Id]),
        CONSTRAINT [PK_Parentesco_CidadeId] FOREIGN key ([CidadeId]) REFERENCES [Cidades]([Id])
);  

    CREATE table Anexo(
        [Id] int IDENTITY(1,1) not null,
        [FuncionarioId] int not null,
        [Arquivo] varbinary(MAX),

        CONSTRAINT [PK_Anexo] PRIMARY key CLUSTERED ([Id]),
        CONSTRAINT [PK_Anexo_FuncionarioId] FOREIGN key ([FuncionarioId]) REFERENCES [Funcionario]([Id])
);
        ";
            return sql;
        }
    }
}
