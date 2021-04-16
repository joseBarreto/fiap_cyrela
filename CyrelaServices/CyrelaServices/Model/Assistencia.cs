using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaServices.Model
{
    [Table("T_CYRELA_ASSISTENCIA")]
    public class Assistencia
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Data de inicio
        /// </summary>
        [Column("ACTUALSTART")]
        public DateTime Actualstart { get; set; }

        /// <summary>
        /// Data de termino
        /// </summary>
        [Column("ACTUALEND")]
        public DateTime Actualend { get; set; }

        /// <summary>
        /// Tipo de atividade
        /// </summary>
        [Column("PJOTIPODEATIVIDADE")]
        public int PjoTipodeAtividade { get; set; }

        /// <summary>
        /// Assunto
        /// </summary>
        [Column("SUBJECT")]
        public string Subject { get; set; }

        /// <summary>
        /// Id do empreendimento 
        /// </summary>
        [Column("PJOEMPREENDIMENTOID")]
        public int PjoEmpreendimentoId { get; set; }

        /// <summary>
        /// Id do Bbloco
        /// </summary>
        [Column("PJOBLOCOID")]
        public int PjoBlocoId { get; set; }

        /// <summary>
        /// Id da unidade
        /// </summary>
        [Column("PJOUNIDADEID")]
        public int PjoUnidadeId { get; set; }

    }
}
