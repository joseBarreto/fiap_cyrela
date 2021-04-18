using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaServices.Model
{

    [Table("T_CYRELA_OCORRENCIA")]
    public class Ocorrencia

    {
        public Ocorrencia() { }
        public Ocorrencia(int id)
        {
            TicketNumber = id;
        }

        /// <summary>
        /// Numero da Ocorrencia
        /// </summary>        
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketNumber { get; set; }

        /// <summary>
        /// Cliente da Unidade
        /// </summary>
        [Column("PJOCLIENTEDAUNIDADE")]
        public int PjoClientedaunidade { get; set; }

        /// <summary>
        /// Empreendimento
        /// </summary>
        [Column("PJOEMPREENDIMENTOID")]
        public int PjoEmpreendimentoid { get; set; }

        /// <summary>
        /// Bloco
        /// </summary>
        [Column("PJOBLOCO")]
        public int PjoBloco { get; set; }

        /// <summary>
        /// Unidade
        /// </summary>
        [Column("PJOUNIDADE")]
        public int PjoUnidade { get; set; }

        /// <summary>
        /// Bandeira
        /// </summary>
        [Column("PJOBANDEIRA")]
        public int PjoBandeira { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [Column("DESCRICAO")]
        public string Description { get; set; }

    }
}
