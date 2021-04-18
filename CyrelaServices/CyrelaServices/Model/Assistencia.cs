using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyrelaServices.Model
{
    /// <summary>
    /// Assistencia
    /// </summary>
    [Table("T_CYRELA_ASSISTENCIA")]
    public class Assistencia : BaseEntity
    {

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
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
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
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoEmpreendimentoId { get; set; }

        /// <summary>
        /// Id do Bbloco
        /// </summary>
        [Column("PJOBLOCOID")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoBlocoId { get; set; }

        /// <summary>
        /// Id da unidade
        /// </summary>
        [Column("PJOUNIDADEID")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoUnidadeId { get; set; }

    }
}
