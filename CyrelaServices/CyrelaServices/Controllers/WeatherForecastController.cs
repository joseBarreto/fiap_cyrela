using CyrelaServices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrelaServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DAL.Context.CyrelaServicesContext _cyrelaServicesContext;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _cyrelaServicesContext = new DAL.Context.CyrelaServicesContext();

        }

        [HttpPost]
        [Route("Assistencia")]
        public IActionResult AssistenciaInsert([FromBody]Model.Assistencia assistencia)
        {            
            _cyrelaServicesContext.Assistencia.Add(assistencia);
            _cyrelaServicesContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("Ocorrencia")]
        public IActionResult OcorrenciaInsert([FromBody]Model.Ocorrencia ocorrencia)
        {
            _cyrelaServicesContext.Ocorrencia.Add(ocorrencia);
            _cyrelaServicesContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Assistencia")]
        public IActionResult AssistenciaGetAll()
        {
            var assistencias = _cyrelaServicesContext.Assistencia
                .OrderByDescending(x => x.Subject)
                .ToList();

            return Ok(assistencias);
        }

        [HttpGet]
        [Route("Assistenciabyid")]
        public IActionResult AssistenciaGetById(int id)
        {
            var assistencias = _cyrelaServicesContext.Assistencia
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return Ok(assistencias);
        }

        [HttpDelete]
        [Route("Ocorrencia")]
        public IActionResult DeleteOcorrencia([FromBody]Model.Ocorrencia ocorrencia)
        {
      
            try
            {
                _cyrelaServicesContext.Ocorrencia.Remove(ocorrencia);
                _cyrelaServicesContext.SaveChanges();

                return Ok($"Item: {ocorrencia.TicketNumber} excluido com sucesso");
            }
            catch (Exception)
            {
                return NotFound("Item inexistente");
            }
            
        }

        [HttpPut]
        [Route("Ocorrencia")]
        public IActionResult AlterarOcorrencia([FromBody]Model.Ocorrencia ocorrencia)
        {
            try
            {
                _cyrelaServicesContext.Ocorrencia.Update(ocorrencia);
                _cyrelaServicesContext.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Ocorrencia")]
        public IActionResult OcorrenciaGetAll()
        {
            try
            {
                var ocorrencias = _cyrelaServicesContext.Ocorrencia
                .OrderBy(x => x.TicketNumber)
                .ToList();

                return Ok(ocorrencias);
            }
            catch (Exception)
            {
                return Ok("Objeto inexistente");
            }
        }

        [HttpGet]
        [Route("Perfil")]
        public IActionResult GetPerfil()
        {
            // STRING DE CONEXAO
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("CyrelaServicesContext");
            // CONEXAO COM O BANCO DE DADOS
            OracleConnection Connection = new OracleConnection(connectionString);
            Connection.Open();
            // EXECUTANDO A QUERY
            OracleCommand Command = new OracleCommand("SELECT *  FROM t_perfil", Connection);
            OracleDataReader Reader = Command.ExecuteReader();

            StringBuilder stringBuilder = new StringBuilder();
            while (Reader.Read())
            {
                stringBuilder.AppendLine($"ID_PERFIL: {Reader[0]}");
                stringBuilder.AppendLine($"CODIGO: {Reader[1]}");
                stringBuilder.AppendLine($"NOME: {Reader[2]}");
                stringBuilder.AppendLine($"DESCRICAO: {Reader[3]}");
                stringBuilder.AppendLine($"DATA_CADASTRO: {Reader[4]}");
            }

            // Fechando as Conexões
            Reader.Close();

            return Ok(stringBuilder.ToString());
        }
    }
}
