using CyrelaServices.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CyrelaServices.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HealthCheckController : ControllerBase
    {
        private readonly CyrelaServicesContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public HealthCheckController(CyrelaServicesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                _ = _context.Assistencia.FirstOrDefault();
                _ = _context.Ocorrencia.FirstOrDefault();
                return Ok("Banco ok");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());

            }
        }
    }
}
