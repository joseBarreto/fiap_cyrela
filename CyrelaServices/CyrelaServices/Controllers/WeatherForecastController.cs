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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int idUsuario, string novoNome)
        {
            var ocorrencia = new Ocorrencia() { Description = "0" };

            return Ok($"idUsuario: {idUsuario} | novoNome: {novoNome}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast weatherForecast) {
            weatherForecast.Date = DateTime.MaxValue;

            return Ok(weatherForecast);
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

        [HttpGet]
        [Route("Andre")]
        public IEnumerable<WeatherForecast> Andre()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
