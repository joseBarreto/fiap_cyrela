using CyrelaServices.DAL.Context;
using CyrelaServices.Model;
using CyrelaServices.Model.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace CyrelaServices.Controllers
{
    /// <summary>
    /// Ocorrências
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OcorrenciasController : ControllerBase
    {
        private readonly CyrelaServicesContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public OcorrenciasController(CyrelaServicesContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os registros paginados
        /// </summary>
        /// <param name="baseParametersPagination">Parâmetros da paginação: PageSize; PageIndex</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(PaginatedList<Ocorrencia>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BaseParametersPagination baseParametersPagination)
        {
            return Ok(await PaginatedList<Ocorrencia>.CreateAsync(_context.Ocorrencia, baseParametersPagination));
        }

        /// <summary>
        /// Retorna um registro com base no identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Ocorrencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var ocorrencia = await _context.Ocorrencia.FirstOrDefaultAsync(m => m.Id == id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            return Ok(ocorrencia);
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="ocorrencia">Modelo para inserção</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Ocorrencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpPost]
        public IActionResult Insert([FromBody] Model.Ocorrencia ocorrencia)
        {
            _context.Ocorrencia.Add(ocorrencia);
            _context.SaveChanges();
            return Ok(ocorrencia.Id);
        }

        /// <summary>
        /// Atualizar um registro
        /// </summary>
        /// <param name="ocorrencia">Modelo para atualização</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Ocorrencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpPut]
        public IActionResult Update([FromBody] Model.Ocorrencia ocorrencia)
        {
            var entity = _context.Ocorrencia.Find(ocorrencia.Id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Entry(entity).CurrentValues.SetValues(ocorrencia);
            _context.SaveChanges();

            return Ok(ocorrencia);
        }

        /// <summary>
        /// Remove um registro
        /// </summary>
        /// <param name="id">Identificador do registro</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Ocorrencia))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [SwaggerResponse(404, "Not Found", typeof(string))]
        [SwaggerResponse(500, "Internal Server error", typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var ocorrencia = await _context.Ocorrencia.FirstOrDefaultAsync(m => m.Id == id);

            if (ocorrencia == null)
            {
                return NotFound();
            }
            _context.Ocorrencia.Remove(ocorrencia);
            _context.SaveChanges();
            return Ok();
        }

    }
}
