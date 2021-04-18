using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyrelaServices.DAL.Context;
using CyrelaServices.Model;
using Swashbuckle.AspNetCore.Annotations;
using CyrelaServices.Model.Helpers;

namespace CyrelaServices.Controllers
{
    /// <summary>
    /// Assistencias
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AssistenciasController : ControllerBase
    {
        private readonly CyrelaServicesContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AssistenciasController(CyrelaServicesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os registros paginados
        /// </summary>
        /// <param name="baseParametersPagination">Parametros da paginação: PageSize; PageIndex</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(PaginatedList<Assistencia>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BaseParametersPagination baseParametersPagination)
        {
            return Ok(await PaginatedList<Assistencia>.CreateAsync(_context.Assistencia, baseParametersPagination));
        }

        /// <summary>
        /// Retorna um registro com base no identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Assistencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var assistencia = await _context.Assistencia.FirstOrDefaultAsync(m => m.Id == id);
            if (assistencia == null)
            {
                return NotFound();
            }

            return Ok(assistencia);
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="assistencia">Modelo para inserção</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Assistencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpPost]
        public IActionResult Insert([FromBody] Model.Assistencia assistencia)
        {
            _context.Assistencia.Add(assistencia);
            _context.SaveChanges();
            return Ok(assistencia.Id);
        }

        /// <summary>
        /// Atualizar um registro
        /// </summary>
        /// <param name="assistencia">Modelo para atualização</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Assistencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpPut]
        public IActionResult Update([FromBody] Model.Assistencia assistencia)
        {
            var entity = _context.Assistencia.Find(assistencia.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Entry(entity).CurrentValues.SetValues(assistencia);
            _context.SaveChanges();

            return Ok(assistencia);
        }

        /// <summary>
        /// Remove um registro
        /// </summary>
        /// <param name="id">Identificador do registro</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Assistencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var assistencia = await _context.Assistencia.FirstOrDefaultAsync(m => m.Id == id);

            if (assistencia == null)
            {
                return NotFound();
            }

            _context.Assistencia.Remove(assistencia);
            _context.SaveChanges();
            return Ok();
        }
    }
}
