using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyrelaServices.Model.Helpers
{
    /// <summary>
    /// Paginação padrão
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T>  where T : BaseEntity
    {
        /// <summary>
        /// Pagina atual
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Total de paginas
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Se existe anterior
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        /// <summary>
        /// Se existe uma pagina a frente
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        /// <summary>
        /// Total de registros
        /// </summary>
        public int TotalRecords { get; private set; }

        /// <summary>
        /// Registros 
        /// </summary>
        public List<T> Records { get; private set; } = new List<T>();

        /// <summary>
        /// Cria uma paginação padrão
        /// </summary>
        /// <param name="items">Lista de objs a serem paginados</param>
        /// <param name="count">Total de registros</param>
        /// <param name="pageIndex">Indice da pagina atual</param>
        /// <param name="pageSize">Tamanho das paginas</param>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalRecords = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Records.AddRange(items);
        }


        /// <summary>
        /// Cria uma nova paginação a partir de um IQuerable
        /// </summary>
        /// <param name="source">Consulta a ser realizada</param>
        /// <param name="baseParametersPagination">Parametros da paginação: PageSize; PageIndex</param>
        /// <returns></returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source,  BaseParametersPagination baseParametersPagination)
        {
            var count = await source.CountAsync();
            var items = await source                
                .OrderBy(x => x.Id)
                .Skip((baseParametersPagination.PageIndex - 1) * baseParametersPagination.PageSize)
                .Take(baseParametersPagination.PageSize)
                .ToListAsync();

            return new PaginatedList<T>(items, count, baseParametersPagination.PageIndex, baseParametersPagination.PageSize);
        }
    }
}
