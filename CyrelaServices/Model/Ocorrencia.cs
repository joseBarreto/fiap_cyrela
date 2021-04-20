using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyrelaServices.Model
{

    /// <summary>
    /// Ocorrência
    /// </summary>
    [Table("T_CYRELA_OCORRENCIA")]
    public class Ocorrencia : BaseEntity
    {

        /// <summary>
        /// Cliente da Unidade
        /// </summary>
        [Column("PJOCLIENTEDAUNIDADE")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoClientedaunidade { get; set; }

        /// <summary>
        /// Empreendimento
        /// </summary>
        [Column("PJOEMPREENDIMENTOID")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoEmpreendimentoid { get; set; }

        /// <summary>
        /// Bloco
        /// </summary>
        [Column("PJOBLOCO")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoBloco { get; set; }

        /// <summary>
        /// Unidade
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        [Column("PJOUNIDADE")]
        public int PjoUnidade { get; set; }

        /// <summary>
        /// Bandeira
        /// </summary>
        [Column("PJOBANDEIRA")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} não pode ser menor ou igual a zero.")]
        public int PjoBandeira { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [Column("DESCRICAO")]
        public string Description { get; set; }

    }
}
