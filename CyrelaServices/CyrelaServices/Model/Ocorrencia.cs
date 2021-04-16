using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaServices.Model
{

    public class Ocorrencia
    {

        /// <summary>
        /// Numero da Ocorrencia
        /// </summary>        
        public int TicketNumber { get; set; }

        /// <summary>
        /// Cliente da Unidade
        /// </summary>
        public int PjoClientedaunidade { get; set; }

        /// <summary>
        /// Empreendimento
        /// </summary>
        public int PjoEmpreendimentoid { get; set; }

        /// <summary>
        /// Bloco
        /// </summary>
        public int PjoBloco { get; set; }

        /// <summary>
        /// Unidade
        /// </summary>
        public int PjoUnidade { get; set; }

        /// <summary>
        /// Bandeira
        /// </summary>
        public int PjoBandeira { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }

    }
}
