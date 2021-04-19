using System;
using System.ComponentModel.DataAnnotations;

namespace CyrelaServices.Model.Helpers
{
    /// <summary>
    /// Parâmetros da paginação
    /// </summary>
    public class BaseParametersPagination
    {
        /// <summary>
        /// Maior valor que a paginação pode assumir
        /// </summary>
        public const int MaxPageSize = 100;

        /// <summary>
        /// Pagina atual
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "O valor para {0} deve estar entre {1} e {2}.")]
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// Tamanho de itens por pagina
        /// </summary>
        [Range(1, MaxPageSize, ErrorMessage = "O valor para {0} deve estar entre {1} e {2}.")]
        public int PageSize { get; set; } = 1;
    }
}
