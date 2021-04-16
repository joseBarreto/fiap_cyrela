using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaServices.Model
{
    public class Assistencia
    {
        /// <summary>
        /// Data de inicio
        /// </summary>
        public DateTime Actualstart { get; set; }

        /// <summary>
        /// Data de termino
        /// </summary>
        public DateTime Actualend { get; set; }

        /// <summary>
        /// Tipo de atividade
        /// </summary>
        public int PjoTipodeAtividade { get; set; }

        /// <summary>
        /// Assunto
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Id do empreendimento 
        /// </summary>
        public int PjoEmpreendimentoId { get; set; }

        /// <summary>
        /// Id do Bbloco
        /// </summary>
        public int PjoBlocoId { get; set; }

    
        /// <summary>
        /// Id da unidade
        /// </summary>
        public int PjoUnidadeId { get; set; }

    }
}
