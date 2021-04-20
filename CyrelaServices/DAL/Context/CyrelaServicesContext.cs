using CyrelaServices.Model;
using Microsoft.EntityFrameworkCore;

namespace CyrelaServices.DAL.Context
{
    /// <summary>
    /// Contexto do banco Oracle
    /// </summary>
    public class CyrelaServicesContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Assistencia> Assistencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options">DbContext para injeção</param>
        public CyrelaServicesContext(DbContextOptions<CyrelaServicesContext> options = null) : base(options)
        {
        }

    }
}
