using CyrelaServices.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        /// 
        /// </summary>
        public string ConnectionString { get; private set; }
        
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options">DbContext para injeção</param>
        public CyrelaServicesContext(DbContextOptions<CyrelaServicesContext> options = null) : base(options)
        {
            var db = (Oracle.EntityFrameworkCore.Infrastructure.Internal.OracleOptionsExtension)options.Extensions.FirstOrDefault(x => x.GetType() == typeof(Oracle.EntityFrameworkCore.Infrastructure.Internal.OracleOptionsExtension));
            ConnectionString = db?.ConnectionString ?? "";
        }

    }
}
