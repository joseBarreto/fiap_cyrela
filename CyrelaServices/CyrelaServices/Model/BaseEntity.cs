using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CyrelaServices.Model
{
    /// <summary>
    /// Dados comuns entre as Entidades
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Identificador
        /// </summary>
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
