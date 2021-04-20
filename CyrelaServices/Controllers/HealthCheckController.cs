using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CyrelaServices.Controllers
{
    /// <summary>
    /// Retorno do estato da API
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// Check padrão
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            return Ok(new { xmlFile, xmlPath });
        }
    }
}
