using Gefun.Dominio.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Servico.Base
{
    public class PersistenciaException : Exception
    {
        public string EntidadeJson { get; }
        public string TipoEntidade { get; }
        public int? IdEntidade { get; }
        public string DescricaoEntidade { get; }

        private PersistenciaException(string mensagem, Exception ex, string tipo, string entidadeJson, int? id, string descricaoEntidade) : base(mensagem, ex)
        {
            EntidadeJson = entidadeJson;
            TipoEntidade = tipo;
            IdEntidade = id;
            DescricaoEntidade = descricaoEntidade;
        }

        public static PersistenciaException Criar<T>(string mensagem, Exception ex, T entidade) where T : EntidadeBase
        {
            if (entidade != null)
            {
                var entidadeJson = JsonConvert.SerializeObject(entidade, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                });
                return new PersistenciaException(mensagem, ex, typeof(T).Name, entidadeJson, entidade.Id, entidade.ToString());
            }
            return new PersistenciaException(mensagem, ex, typeof(T).Name, null, null, null);
        }



        public override string Message
        {
            get
            {
                var msg = base.Message;



                if (IdEntidade != null)
                    msg += $". Entidade '{DescricaoEntidade}', Id '{IdEntidade}'. Tipo da Entidade: '{TipoEntidade}'";
                else
                    msg += ". Entidade nula";



                return msg;
            }
        }
    }
}
